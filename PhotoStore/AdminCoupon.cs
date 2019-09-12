using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.UtilityServices.Constants;
using PhotoStore.BusinessLogic;
namespace PhotoStore
{
    public partial class AdminCoupon : Form
    {
        #region Declarations
        //declare an entity
        List<Entity.Coupon> _CouponList = new List<PhotoStore.Entity.Coupon>();
        private string _errorMessage = "";
        bool _isFromTransaction = false;
        long _statusId=-1;
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
                        //gvCoupon.Rows[cell.RowIndex].Selected = true;
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
            foreach (DataGridViewRow row1 in gvDataEntry.Rows)
            {
                if (row1.Cells["colId"].Value == null) return true;
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

        public AdminCoupon()
        {
            InitializeComponent();
            ucImportExport1._importingComplete+=new PhotoStore.BusinessLogic.UserControls.ImportingComplete(ucImportExport1__importingComplete);
        }
        bool _canTransact = false;

        public AdminCoupon(bool cantransact)
        {
            _canTransact = cantransact;
            InitializeComponent();
            ucImportExport1._importingComplete+=new PhotoStore.BusinessLogic.UserControls.ImportingComplete(ucImportExport1__importingComplete);
        }
        long _productListId;
        public AdminCoupon(bool isfromtransaction, long statusid,long productlistid)
        {
            InitializeComponent();
            _isFromTransaction=isfromtransaction;
            _statusId=statusid;
            _productListId = productlistid;
            ucImportExport1._importingComplete+=new PhotoStore.BusinessLogic.UserControls.ImportingComplete(ucImportExport1__importingComplete);
        }
        public void ucImportExport1__importingComplete()
        {
            LoadCoupons();
        }
        private void LoadCouponByStatus()
        {
            _CouponList = blCoupon.retrieveByStatusId(_statusId,_productListId);
            if (_CouponList.Count > 0)
            {
                gvDataEntry.DataSource = null;
                gvDataEntry.AutoGenerateColumns = false;
                gvDataEntry.DataSource = UI.BindSource(_CouponList, false);
                gvDataEntry.AllowUserToAddRows = false;
                foreach (DataGridViewRow dgvr in gvDataEntry.Rows)
                {
                    dgvr.ReadOnly = true;
                }
            }
            else
            {
                gvDataEntry.ReadOnly = true;
            }
           
        }
        string _branchCode;
        private void CouponManagement_Load(object sender, EventArgs e)
        {
            ucImportExport1.Type = this.Name;
            ucSearch1.TagLabel = "Coupon Code:";
            ucSearch1._Search += new EventHandler<EventArgs>(ucSearch1__Search);
            _branchCode = System.Configuration.ConfigurationManager.AppSettings["BranchCode"].ToString();
            pageControl1.SortedDirection = Direction.ASC;
            pageControl1.ColumnToBeSelected = "*";
            pageControl1.ColumnToBeSorted = "Code";
            pageControl1.DelegatedTotalCount = new TotalCount(
              blCoupon.GetCount);
            pageControl1.DelegatedRetrieveData = new PhotoStore.BusinessLogic.RetrieveData(
              PhotoStore.BusinessLogic.blCoupon.PagingRetrieve);
            pageControl1.ParamDic.Add(Constant.CPStatusId, null);
            pageControl1.ParamDic.Add(Constant.CPProductListId, null);
            pageControl1.ParamDic.Add(Constant.Code, null);
            if (!_isFromTransaction)
            {
                //LoadCoupons();
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
                    pageControl1.ParamDic[Constant.CPStatusId] = _statusId;

              
                if (_productListId > 0)
                    pageControl1.ParamDic[Constant.CPProductListId] = _productListId;
                //LoadCouponByStatus();
            }
            pageControl1.LoadData();
        }

        void ucSearch1__Search(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ucSearch1.SearchCode))
                pageControl1.ParamDic[Constant.Code]=null;
            else
                pageControl1.ParamDic[Constant.Code]=ucSearch1.SearchCode;
            pageControl1.LoadData();
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

        private void LoadCoupons()
        {

            _CouponList = BusinessLogic.blCoupon.retrieve();

            gvDataEntry.DataSource = null;
            gvDataEntry.AutoGenerateColumns = false;

 
            gvDataEntry.DataSource = UI.BindSource(_CouponList, false); ////bs;

         

        }
        private void LoadCoupons(BindingSource bs)
        {


            gvDataEntry.DataSource = null;
            gvDataEntry.AutoGenerateColumns = false;


            gvDataEntry.DataSource = bs;



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // VerifyPassword verifyPassword = new VerifyPassword("CouponAdmin", null);
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

                _CouponList = BusinessLogic.blCoupon.updateList(_CouponList);
                //LoadCoupons();
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
            DataGridViewRow row = gvDataEntry.Rows[rowindex];
            btnAdd.Enabled = (row.Cells["colCouponStatusId"].Value.ToString() != "-1")
                            && (row.Cells["colDescription"].Value.ToString() != System.Configuration.ConfigurationManager.AppSettings["defaultdescription"].ToString());
        }
        private void gvDataEntry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (_isFromTransaction)
                {
                    string nextStatus = "";
                    if (_statusId == 1)
                        nextStatus = "Issued";
                    else if (_statusId == 2)
                        nextStatus = "Redeemed";
                    _id = Convert.ToInt64(gvDataEntry.Rows[e.RowIndex].Cells["colId"].Value);
                    _code = string.Concat(gvDataEntry.Rows[e.RowIndex].Cells["colCode"].Value.ToString(),
                      string.Format("-{0}", gvDataEntry.Rows[e.RowIndex].Cells["colDescription"].Value.ToString()),
                      string.Format("({0})", nextStatus));
                    if (gvDataEntry.Rows[e.RowIndex].Cells["colExpirationDate"].Value != null)
                    {
                        DateTime.TryParse(gvDataEntry.Rows[e.RowIndex].Cells["colExpirationDate"].Value.ToString(), out _dt);

                    }
                    Close();
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
                    string colName = gvDataEntry.Columns[e.ColumnIndex].Name;
                    switch (colName)
                    {
                        case "colCode":
                            Edit frm = new Edit("AdminCoupon", gvDataEntry.Rows[e.RowIndex].DataBoundItem);
                            frm.ShowDialog();
                            frm.Dispose();
                            frm = null;
                            LoadCoupons();
                            break;
                        //case "colCouponStatusCode":
                          
                        //    long couponStatusId = Convert.ToInt64(gvDataEntry.Rows[e.RowIndex].Cells["colCouponStatusId"].Value);
                        //    LookUp lookupCoupon = new LookUp(couponStatusId, "CouponStatus");
                        //    lookupCoupon.ShowDialog();
                        //    if (lookupCoupon.Id > 0)
                        //    {
                        //        gvDataEntry.Rows[e.RowIndex].Cells["colCouponStatusId"].Value = lookupCoupon.Id;
                        //        gvDataEntry.Rows[e.RowIndex].Cells["colCouponStatusCode"].Value = lookupCoupon.Code;
                                
                        //        ControlSaveButton(e.RowIndex);
                        //    }

                        //    lookupCoupon.Dispose();
                        //    lookupCoupon = null;
                        //    break;
                        //case "colDescription":
                          
                           
                        //        LookUp couponDescLookUp = new LookUp(Convert.ToInt64(gvDataEntry.Rows[e.RowIndex].Cells["colProductListId"].Value),
                        //            "CouponProducts");
                        //        couponDescLookUp.ShowDialog();
                        //        if (couponDescLookUp.Id > 0)
                        //        {
                        //            gvDataEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = couponDescLookUp.Code;
                        //            gvDataEntry.Rows[e.RowIndex].Cells["colProductListId"].Value = couponDescLookUp.Id;
                        //        }
                        //        ControlSaveButton(e.RowIndex);
                        //        couponDescLookUp.Dispose();
                        //        couponDescLookUp = null;
                         
                        //    break;
                    }
                  
                        
                    
                }
            }
        }
        long _id = -1;
        string _code;
        public long Id
        {
            get { return _id; }
        }
        public string Code
        {
            get { return _code; }
        }
        DateTime _dt = DateTime.Now.AddMonths(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["autocouponadd"]));
        public DateTime ExpirationDate
        {
            get { return _dt; }
        }
        private void gvDataEntry_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (gvDataEntry.Rows[e.RowIndex].Cells["colId"].Value != null)
            {
                if (gvDataEntry.Rows[e.RowIndex].Cells["colId"].Value.ToString() == "-1")
                {
                    if (gvDataEntry.Rows[e.RowIndex].Cells["colCouponStatusId"].Value != null)
                    {
                        if (gvDataEntry.Rows[e.RowIndex].Cells["colCouponStatusId"].Value.ToString() == "-1")
                            gvDataEntry.Rows[e.RowIndex].Cells["colCouponStatusCode"].Value = "-Set Coupon Status-";
                    }
                    else
                    {
                        gvDataEntry.Rows[e.RowIndex].Cells["colCouponStatusCode"].Value = "-Set Coupon Status-";
                    }

                    if (gvDataEntry.Rows[e.RowIndex].Cells["colCode"].Value == null ||
                       string.IsNullOrEmpty(
                       gvDataEntry.Rows[e.RowIndex].Cells["colCode"].Value.ToString()))
                    {
                        gvDataEntry.Rows[e.RowIndex].Cells["colCode"].Value =
                            System.Configuration.ConfigurationManager.AppSettings["BranchCodeCP"].ToString();
                            
                    }

                   

                    if (gvDataEntry.Rows[e.RowIndex].Cells["colCouponStatusCode"].Value.ToString() == "-Set Coupon Status-"
                        )
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
            Edit frm = new Edit("AdminCoupon");
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
            pageControl1.LoadData();
        }

        private void gvDataEntry_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pageControl1.LoadData(gvDataEntry.Columns[e.ColumnIndex].DataPropertyName);
        }

        private void pageControl1_OnDataLoad(PhotoStore.BusinessLogic.Paging.PageArgs e)
        {
            LoadCoupons(e.BindingSourceObject);
          
            if (!_canTransact)
            {
                btnAdd.Enabled = false;
                btnCancel.Enabled = false;
                //gvDataEntry.Enabled = false;
            }
        }

        private void btnPrintPage_Click(object sender, EventArgs e)
        {
            PrintForm form = new PrintForm(gvDataEntry.DataSource,
            "PhotoStore.CouponReport.rdlc", "Report_Coupon_Report");
            form.ShowDialog();
            form.Dispose();
            form = null;
        }





    }
}