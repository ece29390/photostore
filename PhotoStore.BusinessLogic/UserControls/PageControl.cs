using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PhotoStore.BusinessLogic.Paging;
namespace PhotoStore.BusinessLogic.UserControls
{
    public delegate void OnDataLoading(PageArgs e);
    public partial class PageControl : UserControl
    {
        Page _page;
        RetrieveData _retrieveData;
        TotalCount _totalCount;
        public event OnDataLoading OnDataLoad;
        string _columnToBeSorted, _columnToBeSelected;
        Direction _direction;
        public string ColumnToBeSorted
        {
            get { return _columnToBeSorted; }
            set { _columnToBeSorted = value; }
        }
        public string ColumnToBeSelected
        {
            get { return _columnToBeSelected; }
            set { _columnToBeSelected = value; }
        }
        public RetrieveData DelegatedRetrieveData
        {
            get { return _retrieveData; }
            set { _retrieveData = value; }
        }
        public TotalCount DelegatedTotalCount
        {
            get { return _totalCount; }
            set { _totalCount = value; }
        }
        public Direction SortedDirection
        {
            get { return _direction; }
            set { _direction = value; }
        }
        public PageControl()
        {
            InitializeComponent();
           
            
        }
        Dictionary<string, object> _paramDic;
        public Dictionary<string, object> ParamDic
        {
            get 
            {
                if (_paramDic == null)
                    _paramDic = new Dictionary<string, object>();

                return _paramDic; 
            }
            set { _paramDic = value; }
        }


        private void btnRight_Click(object sender, EventArgs e)
        {
            int currentIndex = Convert.ToInt32(lblPage.Text.Trim());
            _page.Move(++currentIndex, _direction, _columnToBeSorted, _columnToBeSelected,
                _paramDic);
            lblPage.Text = _page.State.CurrentIndex.ToString();
            btnLeft.Enabled = _page.PagingArgument.EnableBackward;
            btnRight.Enabled = _page.PagingArgument.EnableForward;
            if (OnDataLoad != null)
            {
                OnDataLoad(_page.PagingArgument);
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            int currentIndex = Convert.ToInt32(lblPage.Text.Trim());
            _page.Move(--currentIndex, _direction, _columnToBeSorted, _columnToBeSelected, _paramDic);
            lblPage.Text = _page.State.CurrentIndex.ToString();
            btnLeft.Enabled = _page.PagingArgument.EnableBackward;
            btnRight.Enabled = _page.PagingArgument.EnableForward;
            if (OnDataLoad != null)
            {
                OnDataLoad(_page.PagingArgument);
            }
        }
        private void GetData()
        {
            if (OnDataLoad != null)
            {

                OnDataLoad(_page.PagingArgument);
                btnLeft.Enabled = _page.PagingArgument.EnableBackward;
                btnRight.Enabled = _page.PagingArgument.EnableForward;
                if (_page.PagingArgument.BindingSourceObject.Count == 0)
                {
                    lblPage.Text = string.Empty;
                    lblCount.Text = string.Empty;
                    return;              
                }

                lblPage.Text = _page.State.CurrentIndex.ToString();
                lblCount.Text = string.Format(" of {0}",
                    _page.State.MaximumPage);
            }
        }
        public void LoadData()
        {
            _page = new Page(_retrieveData, _totalCount);
            _page.GetSource(_direction,
                _columnToBeSorted,
                _columnToBeSelected,
               _paramDic);
            lblPage.Text = "";
            lblCount.Text = "";
            btnLeft.Enabled = false;
            GetData();
        }
        public void LoadData(string sortColumn)
        {
            _direction = (_direction == Direction.ASC) ? Direction.DESC : Direction.ASC;           
                _columnToBeSorted = sortColumn;
                _page.State.CurrentIndex = 1;
                _page.GetSource(_direction,
                    _columnToBeSorted,
                    _columnToBeSelected,
                    ParamDic);

                GetData();
                btnLeft.Enabled = false;

        }
        private void PageControl_Load(object sender, EventArgs e)
        {
          
        }
    }
}
