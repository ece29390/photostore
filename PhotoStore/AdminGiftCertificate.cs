using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.BusinessLogic;
using System.Configuration;
using PhotoStore.BusinessLogic.Paging;
using PhotoStore.UtilityServices.Constants;
using PhotoStore.Entity;
namespace PhotoStore
{
    public partial class AdminGiftCertificate : Form
    {
        #region Declarations
        //declare an entity
        List<Entity.GiftCertificate> _GiftCertificateList = new List<PhotoStore.Entity.GiftCertificate>();
        //create the business layer to populate the entity
        private string _errorMessage = "";
        bool _isFromTransaction = false;//Tag that identifies that the owner that invoke this module is the transaction
        #endregion

        #region Methods
        public bool checkRequiredFields()
        {
            //initialize
            foreach (DataGridViewColumn col in gvDataEntry.Columns)
            {
                col.HeaderCell.Style.ForeColor = DataGridView.DefaultForeColor;
            }

            //check
            foreach (DataGridViewRow row in gvDataEntry.Rows)
            {
                if (row.Cells["colId"].Value == null) return true;
                //exclude nullable fields
                if (row.Cells["colExpirationDate"].Value == null) return true;
                //look for null columns and empty data
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        _errorMessage = gvDataEntry.Columns[cell.ColumnIndex].HeaderText + " is a required field.";
                        gvDataEntry.Columns[cell.ColumnIndex].HeaderCell.Style.ForeColor = Color.Red;
                        //gvGiftCertificate.Rows[cell.RowIndex].Selected = true;
                        gvDataEntry.Focus();
                        cell.Selected = true;
                        return false;
                    }

                    if (cell.Value.ToString().Trim() == "")
                    {
                        _errorMessage = gvDataEntry.Columns[cell.ColumnIndex].HeaderText + " is a required field.";
                        gvDataEntry.Columns[cell.ColumnIndex].HeaderCell.Style.ForeColor = Color.Red;

                        gvDataEntry.Focus();
                        cell.Selected = true;
                        return false;
                    }
                }


            }

            return true;
        }


        public bool checkEncodedData()
        {

            gvDataEntry.Columns["colCode"].HeaderCell.Style.ForeColor = DataGridView.DefaultForeColor;
            long PhotoGCId = BusinessLogic.blGiftCertificateType.retrieve("PGC").Id;
            foreach (DataGridViewRow row1 in gvDataEntry.Rows)
            {

                if (row1.Cells["colId"].Value == null) return true;
             
                if (row1.Cells["colExpirationDate"].Value != null)
                {
                    if (row1.Cells["colExpirationDate"].Value.ToString().Length > 0)
                    {
                        DateTime expirationDate;
                        if (!DateTime.TryParse(row1.Cells["colExpirationDate"].Value.ToString(), out expirationDate))
                        {
                            _errorMessage = "Invalid Expiration Date Format,it should be MM/DD/YYYY";
                            return false;
                        }
                    }
                }
                foreach (DataGridViewRow row2 in gvDataEntry.Rows)
                {
                    if (row1.Index > row2.Index)
                    {
                        //check for duplicates
                        if ((row1.Cells["colCode"].Value.ToString().Trim() == row2.Cells["colCode"].Value.ToString().Trim()))
                        {
                            _errorMessage = "Duplicate " + gvDataEntry.Columns["colCode"].HeaderText + " found.";
                            gvDataEntry.Columns["colCode"].HeaderCell.Style.ForeColor = Color.Red;
                            gvDataEntry.Focus();
                            row1.Cells["colCode"].Selected = true;
                            return false;
                        }

                    }
                }
            }

            return true;
        }
        #endregion
        long _statusId = -1, _typeId = -1;
        bool _isComplementary=false;
        public AdminGiftCertificate()
        {
            InitializeComponent();
            ucImportExport1._importingComplete+=new PhotoStore.BusinessLogic.UserControls.ImportingComplete(ucImportExport1__importingComplete);
            
            
        }

        void ucSearch1__Search(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ucSearch1.SearchCode))
                pageControl1.ParamDic[Constant.Code] = null;
            else
                pageControl1.ParamDic[Constant.Code] = ucSearch1.SearchCode; 
            pageControl1.LoadData();
        }
        bool _canTransact = false;
        public AdminGiftCertificate(bool cantransact)
        {
            InitializeComponent();
            _canTransact = cantransact;
            ucImportExport1._importingComplete += new PhotoStore.BusinessLogic.UserControls.ImportingComplete(ucImportExport1__importingComplete);
        }
        public AdminGiftCertificate(bool isfromtransaction, long statusid, long typeid
           )
        {
            _isFromTransaction = isfromtransaction;
            _statusId = statusid;
            _typeId = typeid;
          
            InitializeComponent();
            ucImportExport1._importingComplete += new PhotoStore.BusinessLogic.UserControls.ImportingComplete(ucImportExport1__importingComplete);
        }
        long _productlistid;

        public AdminGiftCertificate(bool isfromtransaction,long statusid,long typeid
            ,long productlistid)
        {
            _isFromTransaction = isfromtransaction;
            _statusId = statusid;
            _typeId = typeid;
            _productlistid = productlistid;
            InitializeComponent();
        }
        public void ucImportExport1__importingComplete()
        {
            //LoadGiftCertificates();
            pageControl1.LoadData();
        }
        string _branchCode;
        private void GiftCertificateManagement_Load(object sender, EventArgs e)
        {
            ucSearch1.TagLabel = "GC Code:";
            ucImportExport1.Type = this.Name;
            ucSearch1._Search += new EventHandler<EventArgs>(ucSearch1__Search);
            _branchCode = System.Configuration.ConfigurationManager.AppSettings["BranchCode"].ToString();
            pageControl1.OnDataLoad += new PhotoStore.BusinessLogic.UserControls.OnDataLoading(pageControl1_OnDataLoad);
            pageControl1.SortedDirection=Direction.ASC;
            pageControl1.ColumnToBeSelected = "*";
            pageControl1.ColumnToBeSorted="Code";

            pageControl1.DelegatedTotalCount = new TotalCount(
                blGiftCertificate.GetCount);
            pageControl1.DelegatedRetrieveData = new PhotoStore.BusinessLogic.RetrieveData(
               PhotoStore.BusinessLogic.blGiftCertificate.PagingRetrieve);
            pageControl1.ParamDic.Add(Constant.GCStatusId, null);
            pageControl1.ParamDic.Add(Constant.GCTypeId, null);
            pageControl1.ParamDic.Add(Constant.GCProductListId, null);
            pageControl1.ParamDic.Add(Constant.Code, null);
            if (!_isFromTransaction)
            {
                
                if (!_canTransact)
                {
                    btnAdd.Enabled = false;
                    btnCancel.Enabled = false;
                    gvDataEntry.Enabled = false;
                }
              
            }
            else
            {
                ucImportExport1.Visible = false;
                btnAdd.Enabled = false;
                btnCancel.Enabled = false;
                
                if (_statusId > 0)
                    pageControl1.ParamDic[Constant.GCStatusId] = _statusId;                
                
                if (_typeId > 0)
                    pageControl1.ParamDic[Constant.GCTypeId] = _typeId;
                //pageControl1.StatusId = _statusId;
                //pageControl1.TypeId = _typeId;
               
                if (_productlistid > 0)
                {
                    pageControl1.ParamDic[Constant.GCProductListId]= _productlistid;
                   // pageControl1.ProductListId = _productlistid;
                }
                //LoadCertificatesByTypeAndStatus();
            }
            pageControl1.LoadData();


         
        }

        void pageControl1_OnDataLoad(PageArgs e)
        {
            LoadGiftCertificates(e.BindingSourceObject);
            if (!_canTransact)
            {
                btnAdd.Enabled = false;
                btnCancel.Enabled = false;
                //gvDataEntry.Enabled = false;
            }
        }

        private void BindDataGridViewComboBox(DataGridViewComboBoxColumn col, object dataSource, string dataPropertyName, string displayMember, string valueMember, Type valueType)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;
            bs.ResetBindings(false);

            col.DataSource = bs;
            col.DataPropertyName = dataPropertyName;
            col.DisplayMember = displayMember;
            col.ValueMember = valueMember;
            col.ValueType = valueType;
        }
        private void LoadCertificatesByTypeAndStatus()
        {

            _GiftCertificateList = BusinessLogic.blGiftCertificate.retrieveGiftCertificatesByStatusAndType(
                _statusId, _typeId,_productlistid);
               
            if (_GiftCertificateList.Count > 0)
            {
                gvDataEntry.DataSource = null;
                gvDataEntry.AutoGenerateColumns = false;
                gvDataEntry.AllowUserToAddRows = false;

                //this will prevent the "Index -1 does not have a value" message

                gvDataEntry.DataSource = UI.BindSource(_GiftCertificateList, false);//bs;

                //set the dropdown columns data
                //BindDataGridViewComboBox((DataGridViewComboBoxColumn)gvDataEntry.Columns["colGiftCertificateType"]
                //            , BusinessLogic.blGiftCertificateType.retrieveForComboBox(), "GiftCertificateTypeId", "Description", "Id", typeof(int));

                //BindDataGridViewComboBox((DataGridViewComboBoxColumn)gvDataEntry.Columns["colGiftCertificateStatus"]
                //            , BusinessLogic.blGiftCertificateStatus.retrieveForComboBox(), "GiftCertificateStatusId", "Description", "Id", typeof(int));

                foreach (DataGridViewRow dgvr in gvDataEntry.Rows)
                {
                    dgvr.ReadOnly = true;
                    dgvr.Selected = false;
                }
            }
            else
            {
                gvDataEntry.ReadOnly = true;
            }


        }
        private void LoadGiftCertificates()
        {

           _GiftCertificateList = BusinessLogic.blGiftCertificate.retrieve();


            gvDataEntry.DataSource = null;
            gvDataEntry.AutoGenerateColumns = false;


          gvDataEntry.DataSource = UI.BindSource(_GiftCertificateList, false);//bs;

            
               

        }
        private void LoadGiftCertificates(BindingSource bs)
        {

           // _GiftCertificateList = BusinessLogic.blGiftCertificate.retrieve();


            gvDataEntry.DataSource = null;
            gvDataEntry.AutoGenerateColumns = false;


            gvDataEntry.DataSource = bs;




        }
        private void LoadGiftCertificates(DataGridViewColumn gColumn)
        {

            _GiftCertificateList = BusinessLogic.blGiftCertificate.retrieve();


            gvDataEntry.DataSource = null;
            gvDataEntry.AutoGenerateColumns = false;


            gvDataEntry.DataSource = UI.BindSource(_GiftCertificateList, false);//bs;
            gvDataEntry.Sort(gColumn, ListSortDirection.Descending);


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //VerifyPassword verifyPassword = new VerifyPassword("GCAdmin", null);
            //verifyPassword.ShowDialog();
            //bool isCanceled = verifyPassword.Canceled;
            //verifyPassword.Dispose();
            //verifyPassword = null;
            //if (!isCanceled)
            //{
                #region validation routines
                //validate required data
                if (!checkRequiredFields())
                {
                    MessageBox.Show("Please fill in the required fields.\r\n"
                        + _errorMessage);
                    return;
                }

                //validate invalid data
                if (!checkEncodedData())
                {
                    MessageBox.Show("Invalid data found.\r\n"
                        + _errorMessage);
                    return;
                }
                #endregion

                _GiftCertificateList = BusinessLogic.blGiftCertificate.updateList(_GiftCertificateList, _isFromTransaction);
                //LoadGiftCertificates();
                pageControl1.LoadData();
                MessageBox.Show("Save Succeeded!");
            //}

          
        }

        private void gvDataEntry_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
           
        }
        private void ControlSaveButton(int rowindex)
        {
            DataGridViewRow row=gvDataEntry.Rows[rowindex];
            btnAdd.Enabled = (row.Cells["colGiftCertificateStatusId"].Value.ToString() != "-1")
                            && (row.Cells["colGiftCertificateTypeId"].Value.ToString() != "-1")
                            && (row.Cells["colDescription"].Value.ToString() !=
                            System.Configuration.ConfigurationManager.AppSettings["defaultdescription"].ToString());
        }
        double? _denomAmount = null;
        public double? DenominationAmount
        {
            get { return _denomAmount; }
        }
        public bool Complementary
        {
            get { return _isComplementary; }
        }

        private void gvDataEntry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_isFromTransaction)
            {
                if (e.RowIndex != -1)
                {
                    string nextStatus = "";
                    if (_statusId == 1)
                        nextStatus = "Issued";
                    else if (_statusId == 2)
                        nextStatus = "Redeemed";

                    Entity.GiftCertificate giftCertificate = (Entity.GiftCertificate)gvDataEntry.Rows[e.RowIndex].DataBoundItem;

                    _id = giftCertificate.Id; //Convert.ToInt64(gvDataEntry.Rows[e.RowIndex].Cells["colId"].Value);
                    _code = string.Concat(giftCertificate.Code, string.Format("-{0}", giftCertificate.Description),
                        string.Format("({0})", nextStatus));                   
                    _denomAmount = giftCertificate.UnitPrice;                       
                    if (gvDataEntry.Rows[e.RowIndex].Cells["colExpirationDate"].Value != null)
                    {
                        DateTime.TryParse(gvDataEntry.Rows[e.RowIndex].Cells["colExpirationDate"].Value.ToString(), out dt);

                    }
                    _isComplementary=Convert.ToBoolean(gvDataEntry.Rows[e.RowIndex].Cells["IsComplementary"].Value);
                    giftCertificate=null;
                    Close();
                }
            }
            else
            {

                if (e.RowIndex != -1)
                {
                    bool allowEdit = true;
                    if (gvDataEntry.Rows[e.RowIndex].Cells["colCode"].Value != null)
                    {
                        string colCodeValue = gvDataEntry.Rows[e.RowIndex].Cells["colCode"].Value.ToString().ToUpper();
                        if (!colCodeValue.StartsWith(_branchCode))
                        {
                            allowEdit = false;
                        }
                    }
                    if (!allowEdit)
                    {
                        MessageBox.Show("Modifying Imported GC is not allowed",
                            "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (gvDataEntry.Rows[e.RowIndex].Cells["colId"].Value.ToString() != "-1")
                    {
                        if (!BusinessLogic.blOrderTransactionDetail.AllowModifiy(
                            gvDataEntry.Rows[e.RowIndex].Cells["colCode"].Value.ToString()))
                        {
                            MessageBox.Show("Selected GC is already included on the order transaction\r\nAny modification is prohibited",
                                  "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    string colName = gvDataEntry.Columns[e.ColumnIndex].Name;
                    switch (colName)
                    {
                        case "colCode":
                            Edit edit = new Edit("AdminGiftCertificate",
                                gvDataEntry.Rows[e.RowIndex].DataBoundItem);
                            edit.ShowDialog();
                            edit.Dispose();
                            edit = null;
                            //LoadGiftCertificates();
                            pageControl1.LoadData();
                            break;
                        
                    }
                }
            }
        }
        long _id = -1;
        public long Id
        {
            get { return _id; }
        }
        string _code;
        public string Code
        {
            get { return _code; }
        }
        DateTime dt = DateTime.Now.AddMonths(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["autogcadd"]));
        public DateTime ExpirationDate
        {
            get { return dt; }
        }

        private void gvDataEntry_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (gvDataEntry.Rows[e.RowIndex].Cells["colId"].Value != null)
            {
                if (gvDataEntry.Rows[e.RowIndex].Cells["colId"].Value.ToString() == "-1")
                {
                    if (gvDataEntry.Rows[e.RowIndex].Cells["colGiftCertificateTypeId"].Value != null)
                    {
                        if (gvDataEntry.Rows[e.RowIndex].Cells["colGiftCertificateTypeId"].Value.ToString() == "-1")
                            gvDataEntry.Rows[e.RowIndex].Cells["colGiftCertificateType"].Value = "-Set GC Type";
                    }
                    else
                    {
                        gvDataEntry.Rows[e.RowIndex].Cells["colGiftCertificateType"].Value = "-Set GC Type";
                    }
                    if (gvDataEntry.Rows[e.RowIndex].Cells["colGiftCertificateStatusId"].Value != null)
                    {
                        if (gvDataEntry.Rows[e.RowIndex].Cells["colGiftCertificateStatusId"].Value.ToString() == "-1")
                            gvDataEntry.Rows[e.RowIndex].Cells["colGiftCertificateStatus"].Value = "-Set Statuc-";
                    }
                    else
                    {
                        gvDataEntry.Rows[e.RowIndex].Cells["colGiftCertificateStatus"].Value = "-Set Statuc-";
                    }

                    if (gvDataEntry.Rows[e.RowIndex].Cells["colCode"].Value == null ||
                        string.IsNullOrEmpty(
                            gvDataEntry.Rows[e.RowIndex].Cells["colCode"].Value.ToString()))
                    {

                        gvDataEntry.Rows[e.RowIndex].Cells["colCode"].Value =
                                System.Configuration.ConfigurationManager.AppSettings["BranchCodeGC"].ToString();
                       
                    }
                    
                    if(gvDataEntry.Rows[e.RowIndex].Cells["colGiftCertificateType"].Value.ToString() == "-Set GC Type"
                        &&gvDataEntry.Rows[e.RowIndex].Cells["colGiftCertificateStatus"].Value.ToString() == "-Set Statuc-")
                        btnAdd.Enabled = false;
                }
                else
                {
                    bool allowEdit = true;
                    if (gvDataEntry.Rows[e.RowIndex].Cells["colCode"].Value != null)
                    {
                        string colCodeValue = gvDataEntry.Rows[e.RowIndex].Cells["colCode"].Value.ToString().ToUpper();
                        if (!colCodeValue.StartsWith(_branchCode))
                        {
                            allowEdit = false;
                        }
                    }
                    if (!allowEdit)
                    {
                        MessageBox.Show("Modifying Imported GC is not allowed",
                            "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (gvDataEntry.Rows[e.RowIndex].Cells["colId"].Value.ToString() != "-1")
                    {
                        if (!BusinessLogic.blOrderTransactionDetail.AllowModifiy(
                            gvDataEntry.Rows[e.RowIndex].Cells["colCode"].Value.ToString()))
                        {
                            MessageBox.Show("Selected GC is already included on the order transaction\r\nAny modification is prohibited",
                                  "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    btnAdd.Enabled = true;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Edit frm = new Edit("AdminGiftCertificate");
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
            pageControl1.LoadData();
        }

        private void gvDataEntry_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pageControl1.LoadData(gvDataEntry.Columns[e.ColumnIndex].DataPropertyName);
        }

        private void btnPrintPage_Click(object sender, EventArgs e)
        {
            PrintForm form = new PrintForm(gvDataEntry.DataSource,
                "PhotoStore.GCReport.rdlc", "Report_GC_Report");
            form.ShowDialog();
            form.Dispose();
            form = null;
        }

      
       

      

       

      
       



    }
}