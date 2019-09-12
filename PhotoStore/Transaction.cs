using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.Entity;
using PhotoStore.BusinessLogic;
using System.Configuration;
using PhotoStore.UtilityServices.Printing;
namespace PhotoStore
{
    public partial class Transaction : Form
    {
        #region Declarations
        Entity.OrderTransaction _OrderTransactionEntity;
        bool _hasDiscount = false;
        private bool _isLoaded = false;
        private bool _forceClose = false;
        //private string _errorMessage = "";
        List<OrderTransactionDetail> _orderTransactionDetails = new List<OrderTransactionDetail>();
        blUtility _blUtility = new blUtility();
        List<vwParticularsForRejection> _particularsForRejection = new List<vwParticularsForRejection>();
        
        #endregion

        #region Properties

        private Entity.OrderTransactionDetail _OrderTransactionDetailEntity = null;
        public Entity.OrderTransactionDetail OrderTransactionDetailEntity
        {
            get { return _OrderTransactionDetailEntity; }
            set { _OrderTransactionDetailEntity = value; }
        }

        private Entity.OrderTransactionPayment _OrderTransactionPaymentEntity = null;
        public Entity.OrderTransactionPayment OrderTransactionPaymentEntity
        {
            get { return _OrderTransactionPaymentEntity; }
            set { _OrderTransactionPaymentEntity = value; }
        }

        private Entity.OrderStatus _OrderStatusEntity = BusinessLogic.blOrderStatus.retrieve("Original");
        public Entity.OrderStatus OrderStatusEntity
        {
            get { return _OrderStatusEntity; }
            set { _OrderStatusEntity = value; }
        }

        private Entity.Employee _ModifiedByEmployeeEntity = null;
        public Entity.Employee ModifiedByEmployeeEntity
        {
            get { return _ModifiedByEmployeeEntity; }
            set { _ModifiedByEmployeeEntity = value; }
        }

        private Entity.Employee _PreparedByEmployeeEntity = null;
        public Entity.Employee PreparedByEmployeeEntity
        {
            get { return _PreparedByEmployeeEntity; }
            set { _PreparedByEmployeeEntity = value; }
        }

        private Entity.Customer _CustomerEntity = null;
        public Entity.Customer CustomerEntity
        {
            get { return _CustomerEntity; }
            set { _CustomerEntity = value; }
        }

        private long _OrderTransactionId = -1;
        public long OrderTransactionId
        {
            get { return _OrderTransactionId; }
            set { _OrderTransactionId = value; }
        }

        #endregion

        #region Other Methods
        public void setButtonState(string buttonState)
        {
            bool IsRejectedOrder = false;

            if (_OrderTransactionEntity.OrderStatusEntity != null)
                IsRejectedOrder = _OrderTransactionEntity.OrderStatusEntity.Code == "RejectedOrder";

            btnSave.Enabled = buttonState.Substring(0, 1) == "1";
            btnEdit.Enabled = buttonState.Substring(1, 1) == "1";
            btnReject.Enabled = buttonState.Substring(2, 1) == "1" & !IsRejectedOrder;
            btnCancel.Enabled = buttonState.Substring(3, 1) == "1" & !IsRejectedOrder;
            btnPrint.Enabled = buttonState.Substring(4, 1) == "1";
            btnExit.Enabled = buttonState.Substring(5, 1) == "1";
            lnkRemoveItems.Enabled = buttonState.Substring(6, 1) == "1";
            lnkAddPayment.Enabled = buttonState.Substring(7, 1) == "1";
        }

        public void setControlState(string ControlState)
        {
            bool IsRejectedOrder = false;

            if (_OrderTransactionEntity.OrderStatusEntity != null)
                IsRejectedOrder = _OrderTransactionEntity.OrderStatusEntity.Code == "RejectedOrder";

            gvOrderTransactionDetail.Enabled = ControlState.Substring(0, 1) == "1";

            //gvOrderTransactionDetail.AllowUserToAddRows = gvOrderTransactionDetail.Enabled & !IsRejectedOrder;
            //gvOrderTransactionDetail.AllowUserToDeleteRows = gvOrderTransactionDetail.Enabled & !IsRejectedOrder;
            
            //btnFreebies.Enabled = ControlState.Substring(1, 1) == "1";
            //txtFreebies.ReadOnly = ControlState.Substring(2, 1) == "0";

            gvOrderTransactionPayment.Enabled = ControlState.Substring(3, 1) == "1";
            //gvOrderTransactionPayment.AllowUserToAddRows = gvOrderTransactionPayment.Enabled & !IsRejectedOrder;
            //gvOrderTransactionPayment.AllowUserToDeleteRows = gvOrderTransactionPayment.Enabled & !IsRejectedOrder;

            txtRemarks.ReadOnly = ControlState.Substring(4, 1) == "0";
            gbItemDataEntry.Enabled = ControlState.Substring(5, 1) == "1";
        }
        #endregion

        #region Validation
        public bool checkRequiredFields()
        {

            //lblCode.ForeColor = Label.DefaultForeColor;
            //lblMothersName.ForeColor = Label.DefaultForeColor;

            //if (txtCode.Text.Trim() == "") { lblCode.ForeColor = Color.Red; _errorMessage = "Customer Id is a required field."; return false; }
            //if (txtMothersName.Text.Trim() == "") { lblMothersName.ForeColor = Color.Red; _errorMessage = "Mother's Name is a required field."; return false; }

            //gvOrderTransactionModifiedBy.Columns["colChildsName"].HeaderCell.Style.ForeColor = DataGridView.DefaultForeColor;
            //gvOrderTransactionModifiedBy.Columns["colBirthDate"].HeaderCell.Style.ForeColor = DataGridView.DefaultForeColor;
            //foreach (DataGridViewRow row in gvOrderTransactionModifiedBy.Rows)
            //{
            //    if (row.Cells["colId"].Value == null) return true;
            //    if ((row.Cells["colChildsName"].Value.ToString().Trim() == "")
            //        | (row.Cells["colBirthDate"].Value.ToString().Trim() == ""))
            //    {
            //        _errorMessage = "Child's Name and Birth Date are required fields.";
            //        gvOrderTransactionModifiedBy.Columns["colChildsName"].HeaderCell.Style.ForeColor = Color.Red;
            //        gvOrderTransactionModifiedBy.Columns["colBirthDate"].HeaderCell.Style.ForeColor = Color.Red;
            //        return false;
            //    }
            //}

            return true;
        }

        public bool checkEncodedData()
        {

            //lblMothersBirthDate.ForeColor = Label.DefaultForeColor;
            //lblFathersBirthDate.ForeColor = Label.DefaultForeColor;

            //DateTime dt;
            //if (!DateTime.TryParse(txtMothersBirthDate.Text, out dt)) { lblMothersBirthDate.ForeColor = Color.Red; _errorMessage = "Invalid Father's birth date."; return false; }
            //if (!DateTime.TryParse(txtFathersBirthDate.Text, out dt)) { lblFathersBirthDate.ForeColor = Color.Red; _errorMessage = "Invalid Mother's birth date."; return false; }

            //gvOrderTransactionModifiedBy.Columns["colChildsName"].HeaderCell.Style.ForeColor = DataGridView.DefaultForeColor;
            //gvOrderTransactionModifiedBy.Columns["colBirthDate"].HeaderCell.Style.ForeColor = DataGridView.DefaultForeColor;
            //foreach (DataGridViewRow row1 in gvOrderTransactionModifiedBy.Rows)
            //{
            //    if (row1.Cells["colId"].Value == null) return true;
            //    foreach (DataGridViewRow row2 in gvOrderTransactionModifiedBy.Rows)
            //    {
            //        if (row1.Index > row2.Index)
            //        {
            //            //check for duplicates
            //            if ((row1.Cells["colChildsName"].Value.ToString().Trim() == row2.Cells["colChildsName"].Value.ToString().Trim()))
            //            {
            //                _errorMessage = "Duplicate child names found.";
            //                gvOrderTransactionModifiedBy.Columns["colChildsName"].HeaderCell.Style.ForeColor = Color.Red;
            //                return false;
            //            }
            //        }
            //    }
            //}

            return true;
        }
        #endregion

        #region DataGridView Methods
        /// <summary>bind a gridview to a datasource</summary>
        private void BindToGridView(DataGridView dgv, object dataSource)
        {
            //BindingSource bs = new BindingSource();//this will prevent the "Index -1 does not have a value" message
            //bs.DataSource = dataSource;
            //bs.ResetBindings(false);

            dgv.DataSource = null;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = UI.BindSource(dataSource, false);//bs;
            switch (dgv.Name)
            {
                case "gvOrderTransactionDetail":
                    //foreach (DataGridViewRow row in dgv.Rows)
                    //{
                    //    if (row.Cells["colOrderDetailsId"].Value.ToString() == "-1")
                    //    {
                    //        row.Cells["colChk"].ReadOnly = true;
                    //    }
                    //}
                    break;
                case "gvOrderTransactionPayment":
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells["colOrderPaymentId"].Value.ToString() != "-1"
                            &&row.Cells["colPaymentTypeId"].Value.ToString()!="-1")
                            row.ReadOnly = true;
                        else
                            row.ReadOnly = false;
                    }
                    break;
            }
           

        }

        /// <summary>bind a datasource to a datagridview combobox column</summary>
        private void BindDataGridViewComboBox(DataGridViewComboBoxColumn col, object dataSource, string dataPropertyName, string displayMember, string valueMember, Type valueType)
        {
            col.DataSource = null;
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;
            bs.ResetBindings(false);

            col.DataSource = bs;

            col.DataPropertyName = dataPropertyName;
            col.DisplayMember = displayMember;
            col.ValueMember = valueMember;
            col.ValueType = valueType;

        }

        /// <summary>Bind Data Sources for gvOrderTransactionDetail </summary>
        private void BindGVDetails()
        {
            BindToGridView(gvOrderTransactionDetail, _OrderTransactionEntity.OrderTransactionDetailList);
            //BindDataGridViewComboBox((DataGridViewComboBoxColumn)gvOrderTransactionDetail.Columns["colParticularTypeCode"]
            //            , blParticularType.retrieveForComboBox(), "ParticularTypeCode", "Code", "Code", typeof(string));

            if (_OrderTransactionEntity.OrderStatusEntity != null)
            {
                if (_OrderTransactionEntity.OrderStatusEntity.Code == "Revised")
                {
                    gvOrderTransactionDetail.Columns["colUnitPrice"].ReadOnly = false;
                    gvOrderTransactionDetail.Columns["colUnitPrice"].DefaultCellStyle.BackColor = Color.White;
                }
            }

        }

        /// <summary>Bind Data Sources for gvOrderTransactionDetail CUSTOM combobox </summary>
        private void BindGVDetailsComboBox(object dataSource, string cellStateColumnName)
        {
            //default at cellStateColumnName="colParticularCode"
            string DisplayMember = "Code";
            string ValueMember = "Code";

            if (cellStateColumnName == "colParticulars")
            {
                DisplayMember = "Description";
                ValueMember = "Code";
            }

            cboParticulars.DataSource = null;
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;
            bs.ResetBindings(false);

            cboParticulars.DataSource = bs;

            cboParticulars.DisplayMember = DisplayMember;
            cboParticulars.ValueMember = ValueMember;

        }

        /// <summary>Bind Data Sources for gvOrderTransactionPayment </summary>
        private void BindGVPayments()
        {
            BindToGridView(gvOrderTransactionPayment, _OrderTransactionEntity.OrderTransactionPaymentList);
            
        }
        private void DisableSavePayment()
        {
            foreach (DataGridViewRow row in gvOrderTransactionPayment.Rows)
            {
                if (row.Cells["colOrderPaymentId"].Value.ToString() != "-1")
                {
                    row.ReadOnly = true;
                    
                }
            }
        }
        /// <summary>Compute for the Total Amount Due and Balance </summary>
        private void UpdateDataGridViewTotals()
        {
            DataGridViewCellCollection CurrentCells;
           
            double totalAmountDue = 0;
            foreach (DataGridViewRow row in gvOrderTransactionDetail.Rows)
            {
                totalAmountDue += Convert.ToDouble(row.Cells["colAmount"].Value);
            }
            txtTotalAmountDue.Text = totalAmountDue.ToString("#,###.00");

            //gvOrderTransactionPayment
            if (gvOrderTransactionPayment.CurrentRow != null)
            {
                
                UpdateDataGridViewTotals(gvOrderTransactionPayment.CurrentRow);
               
            }
            double totalAmountReceived = 0;
            foreach (DataGridViewRow row in gvOrderTransactionPayment.Rows)
            {
                totalAmountReceived += Convert.ToDouble(row.Cells["colAmountReceived"].Value);
            }

            if (_OrderStatusEntity.Id != 3)//check if the order status is cancelled
                txtBalance.Text = (totalAmountDue - totalAmountReceived).ToString("#,###.00");
            else
            {
              
                    if (totalAmountReceived == 0)
                        txtBalance.Text = "0.0";
                    else
                        txtBalance.Text = (totalAmountDue - totalAmountReceived).ToString("#,###.00");


               
            }
        }
       
        private void UpdateDataGridViewTotals(DataGridViewRow dgvr)
        {
            BLService.ComputeBankFee(dgvr, _hasDiscount, gvOrderTransactionPayment);
        }
        #endregion

        #region Button Methods
        /// <summary>Create a new transaction</summary>
        private void NewTransaction()
        {
            
            _OrderTransactionEntity = new PhotoStore.Entity.OrderTransaction();
          
            //initialize the controls
            _OrderTransactionId = -1;
            txtCode.Text = blOrderTransaction.retrieveNextCode();
            txtDateCreated.Text = DateTime.Now.ToString("MM/dd/yyyy");
            //BusinessLogic.blCustomerEntity
            txtOrderStatus.Text = _OrderStatusEntity.Description;
            txtPrivilegeCardCode.Text = _CustomerEntity.PrivilegeCardCode;
            txtMothersName.Text = _CustomerEntity.MothersName;
            txtMothersLandLine.Text = _CustomerEntity.MothersLandLine;
            txtMothersCellNumber.Text = _CustomerEntity.MothersCellNumber;
            //txtFreebies.Text = "";
            txtPreparedByFullName.Text = _PreparedByEmployeeEntity.FullName;

            lnkAddItem.Enabled = true;
            //BindGVDetails();
           // BindGVPayments();

            //BindToGridView(gvOrderTransactionModifiedBy, _OrderTransactionEntity.OrderTransactionModifiedByList);
        }

        private void BindParticularType()
        {
            List<ParticularType> particularTypes=blParticularType.retrieveAllForTransaction();
            cboProductType.ValueMember = "Id";
            cboProductType.DisplayMember = "Description";
            cboProductType.DataSource = UI.BindSource(particularTypes, false);
            //BindParticular(particularTypes[0].Id);
            
        }
        private void BindParticular(long id)
        {
            List<ProductList> productLists = blProductList.retrieveByParticularTypeId(id);
            if (cboProductDescription.DataSource != null)
            {
                //cboProductDescription.Items.Clear();
                cboProductDescription.DataSource = null;
            }
            cboProductDescription.ValueMember = "Id";
            cboProductDescription.DisplayMember = "Description";
            cboProductDescription.DataSource = UI.BindSource(productLists, false);

            //txtGiftChequeNumber.Enabled = _allGCAndCouponIds.Contains(Convert.ToInt64(cboProductType.SelectedValue))&&
            //    cboProductDescription.Items.Count>0;
            btnGiftChequeLookUp.Enabled =_allGCAndCouponIds.Contains(Convert.ToInt64(cboProductType.SelectedValue))&&
                 cboProductDescription.Items.Count > 0;
            //lnkAddGCCoupon.Enabled = btnGiftChequeLookUp.Enabled;
            long productId = Convert.ToInt64(cboProductType.SelectedValue);
            lnkAddGCCoupon.Enabled = false;
            foreach (long gcId in _gcIds)
            {
                if (gcId == productId)
                {
                    lnkAddGCCoupon.Enabled = true;
                    break;
                }
            }
            if (!lnkAddGCCoupon.Enabled)
            {
                foreach (long productCouponId in _productCouponIds)
                {
                    if (productCouponId == productId)
                    {
                        lnkAddGCCoupon.Enabled = true;
                        break;
                    }
                }
            }

        }
        private void AttachRecordId()
        {
            for (int i = 0; i < _OrderTransactionEntity.OrderTransactionDetailList.Count; i++)
            {
                _OrderTransactionEntity.OrderTransactionDetailList[i].RecordId = i + 1;
            }
        }
        private void BindParticular()
        {
            BindParticular(Convert.ToInt64(cboProductType.SelectedValue));
        }
        /// <summary>Search for a particular transaction</summary>
        private void SearchTransaction()
        {
            try
            {
                
                _OrderTransactionEntity = blOrderTransaction.retrieve(_OrderTransactionId);

                //Attach Record Id to the ordertransactiondetail
                AttachRecordId();
                
                _PreparedByEmployeeEntity = _OrderTransactionEntity.PreparedByEmployeeEntity;
                _OrderStatusEntity = _OrderTransactionEntity.OrderStatusEntity;
                _CustomerEntity = _OrderTransactionEntity.CustomerEntity;

                //use the entity properties to populate the form
                txtCode.Text = _OrderTransactionEntity.Code;
                txtPrivilegeCardCode.Text = _OrderTransactionEntity.CustomerEntity.PrivilegeCardCode;
                txtMothersName.Text = _OrderTransactionEntity.CustomerEntity.MothersName;
                txtDateCreated.Text = _OrderTransactionEntity.DateCreated.ToString("MM/dd/yyyy");
                txtMothersLandLine.Text = _OrderTransactionEntity.CustomerEntity.MothersLandLine;
                txtMothersCellNumber.Text = _OrderTransactionEntity.CustomerEntity.MothersCellNumber;

                //the revised transaction means it came from a cancelled transaction
                if (_OrderTransactionEntity.OrderStatusEntity.Code == "Revised")
                    txtOrderStatus.Text = _OrderStatusEntity.Description + " - [Cancelled #" + _OrderTransactionEntity.CancelledCode + "]";

                //Note that the "RejectedOrder" status does NOT mean that the current transaction is rejected
                //it means that the current transaction is a replacement for a previous transaction with rejected items
                //note that the status of the previous transaction will be set to "Modified" (with the rejected items checked and read only)
                //the user can no longer add or remove a detail
                //the payment details are no longer available
                else if (_OrderTransactionEntity.OrderStatusEntity.Code == "RejectedOrder")
                    txtOrderStatus.Text = _OrderStatusEntity.Description + " - [Rejected #" + _OrderTransactionEntity.RejectedCode + "]";
                else
                    txtOrderStatus.Text = _OrderStatusEntity.Code;

                //txtFreebies.Text = _OrderTransactionEntity.Freebies;
                if(_OrderTransactionEntity.PreparedByEmployeeEntity!=null)
                    txtPreparedByFullName.Text = _OrderTransactionEntity.PreparedByEmployeeEntity.FullName;

                BindGVDetails();
                BindGVPayments();
                
                if(_OrderTransactionEntity.OrderTransactionModifiedByList!=null)
                    BindToGridView(gvOrderTransactionModifiedBy, _OrderTransactionEntity.OrderTransactionModifiedByList);

              
               


                txtModifiedByFullName.Text = "";//_ModifiedByEmployeeEntity.FullName;
                txtRemarks.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("code not found!" + ex.Message);
            }

        }
     
        private void RejectTransaction()
        {
            _OrderTransactionEntity.Code = txtCode.Text;
            _OrderTransactionEntity.DateCreated = Convert.ToDateTime(txtDateCreated.Text);
            _OrderTransactionEntity.CustomerId = _CustomerEntity.Id;
            _OrderTransactionEntity.OrderStatusId = _OrderStatusEntity.Id;
            _OrderTransactionEntity.PriviledgeCard = txtPrivilegeCardCode.Text;
            //_OrderTransactionEntity.Freebies = txtFreebies.Text;
            if(_PreparedByEmployeeEntity!=null)
            _OrderTransactionEntity.PreparedByEmployeeId = _PreparedByEmployeeEntity.Id;

            //OrderTransactionModifiedBy: prepare the modifier entity - on edit only
           
            //set the order status and rejection remarks
            //rejecting the items on this transaction will only set it to "Modified"
            RejectOrderTransaction frm = new RejectOrderTransaction(
                _orderPackageDetailIdRejection
                , _orderDetailIdForRejection
                , _OrderTransactionEntity
                ,_PreparedByEmployeeEntity
                ,false);
            frm.ShowDialog();
            frm.Dispose();
            if (frm.IsSave)
            {
                _OrderTransactionEntity.OrderTransactionModifiedByList = blOrderTransactionModifiedBy.retrieveByOrderTransactionId(
                                    _OrderTransactionEntity.Id);
                if (_ModifiedByEmployeeEntity != null)
                {
                    Entity.OrderTransactionModifiedBy modifiedBy = new PhotoStore.Entity.OrderTransactionModifiedBy();
                    modifiedBy.ModifiedByEmployee = _ModifiedByEmployeeEntity;
                    modifiedBy.ModifiedByEmployeeId = _ModifiedByEmployeeEntity.Id;
                    modifiedBy.OrderTransactionId = _OrderTransactionId;
                    modifiedBy.Remarks = txtRemarks.Text;
                    _OrderTransactionEntity.OrderTransactionModifiedByList.Add(modifiedBy);
                }
                _OrderStatusEntity = BusinessLogic.blOrderStatus.retrieve("Modified");
                txtOrderStatus.Text = _OrderStatusEntity.Description;
                txtRemarks.Text = frm.RejectRemarks;

                if (_OrderTransactionEntity.Id == -1)
                    _OrderTransactionEntity = blOrderTransaction.create(_OrderTransactionEntity);
                else
                    _OrderTransactionEntity = blOrderTransaction.update(_OrderTransactionEntity);

                MessageBox.Show("Rejection successful!");

                SearchTransaction();
                setButtonState("10001111");
                setControlState("111111");
            }
            frm = null;
           
        }
        /// <summary>Save the transaction</summary>
        private void SaveTransaction()
        {
            //pass the form values onto the entity
            _OrderTransactionEntity.Code = txtCode.Text;
            _OrderTransactionEntity.DateCreated = Convert.ToDateTime(txtDateCreated.Text);
            _OrderTransactionEntity.CustomerId = _CustomerEntity.Id;
            _OrderTransactionEntity.OrderStatusId = _OrderStatusEntity.Id;
            _OrderTransactionEntity.PriviledgeCard = txtPrivilegeCardCode.Text;
            //_OrderTransactionEntity.Freebies = txtFreebies.Text;
            if(_PreparedByEmployeeEntity!=null)
            _OrderTransactionEntity.PreparedByEmployeeId = _PreparedByEmployeeEntity.Id;

            //OrderTransactionModifiedBy: prepare the modifier entity - on edit only
            if (_ModifiedByEmployeeEntity != null)
            {
                Entity.OrderTransactionModifiedBy modifiedBy = new PhotoStore.Entity.OrderTransactionModifiedBy();
                modifiedBy.ModifiedByEmployee = _ModifiedByEmployeeEntity;
                modifiedBy.ModifiedByEmployeeId = _ModifiedByEmployeeEntity.Id;
                modifiedBy.OrderTransactionId = _OrderTransactionId;
                modifiedBy.Remarks = txtRemarks.Text;
                _OrderTransactionEntity.OrderTransactionModifiedByList.Add(modifiedBy);
            }
         
            if (_OrderTransactionEntity.Id == -1)
                _OrderTransactionEntity = blOrderTransaction.create(_OrderTransactionEntity);
            else
                _OrderTransactionEntity = blOrderTransaction.update(_OrderTransactionEntity);

            
            
            _OrderTransactionId = _OrderTransactionEntity.Id;

        }

        
        #endregion

        public Transaction()
        {
            InitializeComponent();
        }
        List<long> _gcIds = new List<long>();
        List<long> _redemptionGcIds = new List<long>();
        List<long> _productCouponIds = new List<long>();
        List<long> _redemptionCouponIds = new List<long>();
        private void CollectProductDenominationGC()
        {
            string[] gcIdsStr = ConfigurationManager.AppSettings["gcids"].ToString().Split(new char[1] { ';' },
                StringSplitOptions.RemoveEmptyEntries);
            foreach (string gcIdStr in gcIdsStr)
            {
                _gcIds.Add(Convert.ToInt64(gcIdStr));
            }
        }

        private void CollectRedemptionGC()
        {
            string[] gcRedemptionIdStr = ConfigurationManager.AppSettings["redemptiongcids"].ToString().Split(
                new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string gcRedemptionStr in gcRedemptionIdStr)
            {
                _redemptionGcIds.Add(Convert.ToInt64(gcRedemptionStr));
            }
        }
        private void CollectProductCoupon()
        {
            string[] prodCouponIdsStr = ConfigurationManager.AppSettings["productcouponids"].ToString().Split(
                new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string prodCouponIdStr in prodCouponIdsStr)
            {
                _productCouponIds.Add(Convert.ToInt64(prodCouponIdStr));
            }

        }
        private void CollectRedemptionCouponIds()
        {
            string[] redemptionCouponIdsStr = ConfigurationManager.AppSettings["redemptioncouponids"].ToString().Split(
                new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string redemptionCouponIdStr in redemptionCouponIdsStr)
            {
                _redemptionCouponIds.Add(Convert.ToInt64(redemptionCouponIdStr));
            }
        }
        List<long> _allGCAndCouponIds = new List<long>();
        private void CollectAllGcAndCoupons()
        {
            //List<long> gcIds = new List<long>();
            //List<long> redemptionGcIds = new List<long>();
            //List<long> productCouponIds = new List<long>();
            //List<long> redemptionCouponIds = new List<long>();
            foreach (long gcId in _gcIds)
            {
                _allGCAndCouponIds.Add(gcId);
            }
            foreach (long redemptionGcId in _redemptionGcIds)
            {
                _allGCAndCouponIds.Add(redemptionGcId);
            }
            foreach (long productCouponId in _productCouponIds)
            {
                _allGCAndCouponIds.Add(productCouponId);
            }
            foreach (long redemptionCouponId in _redemptionCouponIds)
            {
                _allGCAndCouponIds.Add(redemptionCouponId);
            }
        }
        private void GetJobOrderForReject()
        {
            _particularsForRejection = BLService.RetrieveParticularAllowedForRejection(txtCode.Text.Trim());

        }
        private int _autogcadd = Convert.ToInt32(ConfigurationManager.AppSettings["autogcadd"]);
        private int _autocouponadd = Convert.ToInt32(ConfigurationManager.AppSettings["autocouponadd"]);
        private void Transaction_Load(object sender, EventArgs e)
        {
            _isLoaded = false;
            CollectProductCoupon();
            CollectProductDenominationGC();
            CollectRedemptionCouponIds();
            CollectRedemptionGC();
            CollectAllGcAndCoupons();
            BindParticularType();
            if (_OrderTransactionId == -1)
            {
                NewTransaction();
                setButtonState("10000111");
                //setControlState("11110");
                setControlState("111101");
            }
            else
            {
                SearchTransaction();

                if (_OrderStatusEntity.Code == "RejectedOrder")
                    setButtonState("01001100");
                else if (_OrderStatusEntity.Code != "Original" & _OrderStatusEntity.Code != "Modified" & _OrderStatusEntity.Code != "Revised")
                    setButtonState("00001101");
                else
                    setButtonState("01011100");

                if (_OrderTransactionEntity.OrderStatusId != 3)
                    setControlState("000000");
                else
                    setControlState("000100");
            }
            //if (_OrderStatusEntity.Code == "Original" | _OrderStatusEntity.Code == "Modified") 
                UpdateDataGridViewTotals();

            _isLoaded = true;
            GetJobOrderForReject();
            
           //lnkAddPayment.Enabled = _OrderTransactionId > -1 ? true : false;
           
            

        }
        private bool ValidatePayment()
        {
            bool isValid = true;
            if (gvOrderTransactionPayment.RowCount > 0)
            {
                foreach (DataGridViewRow gRow in gvOrderTransactionPayment.Rows)
                {
                    if(Convert.ToInt64(gRow.Cells["colPaymentTypeId"].Value)==-1)
                    {
                        isValid=false;
                        break;
                    }
                    if(!isValid)
                        return false;
                }
            }
            return isValid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {             
                if (!ValidatePayment())
                {
                    MessageBox.Show("Please input the details on the payment details or \r\n remove the row with incomplete details");
                    return;
                }              
                SaveTransaction();
                MessageBox.Show("save successful!");
               
                setButtonState("10111111");
                _hasDiscount = BLService.HasDiscount(gvOrderTransactionDetail);
                this.SearchTransaction();
                //BindGVDetails();
                //BindGVPayments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //verify the password of the employee that will modify the transaction
            VerifyPassword frmVP = new VerifyPassword();
            frmVP.ShowDialog();

            if (frmVP.Canceled)
            {
                frmVP.Dispose();
                frmVP = null;
                return;
            }
            else
            {
                _ModifiedByEmployeeEntity = frmVP.Employee;
                frmVP.Dispose();
                frmVP = null;
            }


            if (_ModifiedByEmployeeEntity == null) return;
            txtModifiedByFullName.Text = _ModifiedByEmployeeEntity.FullName;


            if (_OrderTransactionEntity.OrderStatusEntity.Code == "Revised")
                txtOrderStatus.Text = _OrderStatusEntity.Description + " - [Cancelled #" + _OrderTransactionEntity.CancelledCode + "]";
            else if (_OrderTransactionEntity.OrderStatusEntity.Code == "RejectedOrder")
                txtOrderStatus.Text = _OrderStatusEntity.Description + " - [Rejected #" + _OrderTransactionEntity.RejectedCode + "]";
            else
            {
                _OrderStatusEntity = BusinessLogic.blOrderStatus.retrieve("Modified");
                txtOrderStatus.Text = _OrderStatusEntity.Description; 
            }
            setButtonState("10111111");
            setControlState("111111");
            foreach (DataGridViewRow row in gvOrderTransactionDetail.Rows)
            {
                if (row.Cells["colOrderDetailsId"].Value.ToString() == "-1")
                {
                    row.Cells["colChk"].ReadOnly = false;
                }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (_particularsForRejection.Count == 0)
            {
                MessageBox.Show("All item(s) is/are not yet printed");
                return;
            }
            RejectOrderTransaction frm = new RejectOrderTransaction(
                _OrderTransactionEntity,
                _PreparedByEmployeeEntity
                , _particularsForRejection);
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (_particularsForRejection.Count > 0)
                {
                    MessageBox.Show("Atleast one item had already been printed.\r\nIf you want to remove an unprinted number select the item \r\nand click the remove item link",
                        "Operation Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to cancel? order can't be modified anymore.", "Order Transaction", MessageBoxButtons.YesNo) == DialogResult.No) return;

                //verify the password of the employee that will cancel the transaction
                Entity.Employee adminEmployee = null;
                string cancelRemarks = "";
                VerifyPassword frmVP = new VerifyPassword();
                frmVP.WithRemarks = true;
                frmVP.ShowDialog();

                if (frmVP.Canceled)
                {
                    frmVP.Dispose();
                    frmVP = null;
                    return;
                }
                else
                {
                    adminEmployee = frmVP.Employee;
                    cancelRemarks = frmVP.Remarks;
                    frmVP.Dispose();
                    frmVP = null;
                }



                if (adminEmployee.EmployeeGroup.Code != "ADMIN")
                {
                    MessageBox.Show("Only administrators are allowed to cancel this transaction", "Order Transaction");
                    return;
                }
                if (adminEmployee == null) return;

                //set the order status and cancelation remarks
                _OrderStatusEntity = BusinessLogic.blOrderStatus.retrieve("Cancelled");
                txtOrderStatus.Text = _OrderStatusEntity.Description;
                txtRemarks.Text = cancelRemarks;

                //set the person who canceled be the last modifier
                Entity.OrderTransactionModifiedBy modifiedBy = new PhotoStore.Entity.OrderTransactionModifiedBy();
                modifiedBy.ModifiedByEmployee = adminEmployee;
                modifiedBy.ModifiedByEmployeeId = adminEmployee.Id;
                modifiedBy.OrderTransactionId = _OrderTransactionId;
                modifiedBy.Remarks = cancelRemarks;
                _OrderTransactionEntity.OrderTransactionModifiedByList.Add(modifiedBy);
                //txtBalance.Text = "0.0";
                //save the cancelation
                SaveTransaction();

                //prompt if the user want to revise this cancelled transaction
                DialogResult diagResult = MessageBox.Show("Cancelation successful! Proceed to revise this transaction?", "Order Transaction", MessageBoxButtons.YesNo);
                if ( diagResult== DialogResult.Yes)
                {
                    long oldOrderTransactionId = _OrderTransactionId;
                    _OrderTransactionId = blOrderTransaction.revise(_OrderTransactionId);
                    blOrderTransactionPayment.DeletePaymentByOrderTransactionId(oldOrderTransactionId);
                    SearchTransaction();

                    setButtonState("10111111");
                    setControlState("111111");
                   

                    //txtOrderStatus.Text = _OrderStatusEntity.Description + " - [Cancelled #" + _OrderTransactionEntity.CancelledCode + "]";
                }
                else
                {
                    if(gvOrderTransactionPayment.RowCount>0&&(
                        Convert.ToDouble(txtBalance.Text.Trim())==
                        Convert.ToDouble(txtTotalAmountDue.Text.Trim())))
                    {
                        return;
                    }
                     
   
                    
                    diagResult = MessageBox.Show("Cancellation of Payment!Did the customer ask for a refund?", "Order Transaction", MessageBoxButtons.YesNo);
                    
                    if (diagResult == DialogResult.Yes)
                    {
                        if (!blOrderTransactionPayment.RefundAll(_OrderTransactionId))
                        {
                            MessageBox.Show("Unable to cancel all the payments automatically since the transaction date\r\nis the same as the current date\r\nPlease cancel the payments manually\r\nas you proceed to the refunding steps");
                            return;
                        }

                        if (blOrderTransactionPayment.HasCheckPayment(_OrderTransactionId))
                        {
                            MessageBox.Show("All payments made thru check should be cancelled manually");

                        }

                        blOrderTransactionPayment.AutoCancelPayment(gvOrderTransactionPayment, _OrderTransactionId);
                        _OrderTransactionEntity.OrderTransactionPaymentList = blOrderTransactionPayment.retrieveByOrderTransactionId(_OrderTransactionId);
                        BindGVPayments();
                        UpdateDataGridViewTotals();
                    }


                    _forceClose = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //private void btnFreebies_Click(object sender, EventArgs e)
        //{
        //    TransactionFreebie frm = new TransactionFreebie();
        //    frm.ShowDialog();

        //    if (frm.SelectedFreebieList == null) return;
        //    if (frm.SelectedFreebieList.Count == 0) return;

        //    //foreach (Entity.Freebie freebie in frm.SelectedFreebieList)
        //    //{
        //    //    txtFreebies.Text = txtFreebies.Text.Replace(freebie.Code + " - " + freebie.Description + "; ", "");
        //    //    txtFreebies.Text += freebie.Code + " - " + freebie.Description + "; ";
        //    //}

        //    frm.Dispose();
        //    frm = null;

        //}

        private void cboParticulars_Leave(object sender, EventArgs e)
        {
            //cboParticulars.Visible = false;
            if (cboParticulars.SelectedValue == null) return;
            if (cboParticulars.SelectedValue.ToString() == "--") return;

            string CurrentColumnName = gvOrderTransactionDetail.CurrentCell.OwningColumn.Name;
            if (CurrentColumnName != "colParticulars" & CurrentColumnName != "colParticularCode") return;

            string ParticularTypeCode = ((Entity.OrderTransactionDetail)gvOrderTransactionDetail.CurrentCell.OwningRow.DataBoundItem).ParticularTypeCode;
            Entity.IParticularEntity particularEntity;
            switch (ParticularTypeCode)
            {
                case "PRD": particularEntity = BusinessLogic.blProduct.retrieve(cboParticulars.SelectedValue.ToString()); break;
                case "PKG": particularEntity = BusinessLogic.blPackage.retrieve(cboParticulars.SelectedValue.ToString()); break;
                case "PGC": particularEntity = BusinessLogic.blGiftCertificate.retrieve(cboParticulars.SelectedValue.ToString()); break;
                case "DGC": particularEntity = BusinessLogic.blGiftCertificate.retrieve(cboParticulars.SelectedValue.ToString()); break;
                case "CPN": particularEntity = BusinessLogic.blCoupon.retrieve(cboParticulars.SelectedValue.ToString()); break;
                default: particularEntity = null; break;
            }
            DataGridViewCellCollection CurrentCells = gvOrderTransactionDetail.CurrentRow.Cells;
            if (particularEntity != null)
            {
                CurrentCells["colParticularCode"].Value = particularEntity.Code;
                CurrentCells["colParticulars"].Value = particularEntity.Description;
                if (CurrentCells["colUnitPrice"].ReadOnly)
                    CurrentCells["colUnitPrice"].Value = particularEntity.UnitPrice;
                
                UpdateDataGridViewTotals();
            }
            cboParticulars.Visible = false;
        }

        private void gvOrderTransactionDetail_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gvOrderTransactionDetail.ReadOnly) return;
                if (gvOrderTransactionDetail.CurrentCell.OwningRow.DataBoundItem == null) return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        private void Transaction_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (_OrderTransactionEntity.OrderStatusId == 3)//it means cancelled transaction
            //{
            //    if (Convert.ToDouble(txtBalance.Text.Trim()) > 0)
            //    {
            //        MessageBox.Show("Exiting the transaction without cancelling all the payments is not allowed");
            //        e.Cancel = true;
            //        return;
            //    }
            //}
            if (_forceClose) return;
           
            e.Cancel = (MessageBox.Show("Are you sure you want to exit?", "Order Transaction", MessageBoxButtons.YesNo) == DialogResult.No);
        }

        private void gvOrderTransactionDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (gvOrderTransactionDetail.ReadOnly) return;
            if (gvOrderTransactionDetail.CurrentCell==null) return;
            string ModifiedColumnName = gvOrderTransactionDetail.CurrentCell.OwningColumn.Name;

            //if (ModifiedColumnName != "colUnitPrice" & ModifiedColumnName != "colAdjustment" & ModifiedColumnName != "colAmount") return;
            if (ModifiedColumnName != "colQuantity" & ModifiedColumnName != "colUnitPrice" & ModifiedColumnName != "colAdjustment") return;
            
            UpdateDataGridViewTotals();
        }

       
        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
            OrderReport orderReport = new OrderReport(_OrderTransactionId);
            orderReport.ShowDialog();
            orderReport.Dispose();
            orderReport = null;
            btnPrint.Enabled = true;
            
        }

        private void gvOrderTransactionDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(gvOrderTransactionDetail.Columns[e.ColumnIndex].Name!="colParticularTypeCode") return;
            gvOrderTransactionDetail.Rows[e.RowIndex].Cells["colParticularCode"].Value = "";
            gvOrderTransactionDetail.Rows[e.RowIndex].Cells["colParticulars"].Value = "";
        }

        private void gvOrderTransactionDetail_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            cboParticulars.Visible = false;
            if (gvOrderTransactionDetail.ReadOnly) return;
            if (gvOrderTransactionDetail.CurrentRow.ReadOnly) return;
            if (gvOrderTransactionDetail.CurrentRow.DataBoundItem == null) return;
            if (gvOrderTransactionDetail.Columns[e.ColumnIndex].Name != "colParticulars" & gvOrderTransactionDetail.Columns[e.ColumnIndex].Name != "colParticularCode") return;

            //populate the dropdown boxes depending on the type
            Entity.OrderTransactionDetail selectedDetail = ((Entity.OrderTransactionDetail)gvOrderTransactionDetail.CurrentRow.DataBoundItem);

            object dataSource = null;
            switch (selectedDetail.ParticularTypeCode)
            {
                case "PRD": dataSource = BusinessLogic.blProduct.retrieveForComboBox(); break;
                case "PKG": dataSource = BusinessLogic.blPackage.retrieveForComboBox(); break;
                // only pending Photo GC's should be selected
                case "PGC": dataSource = BusinessLogic.blGiftCertificate.retrieveForComboBox(
                    BusinessLogic.blGiftCertificateType.retrieve("PGC").Id
                    , BusinessLogic.blGiftCertificateStatus.retrieve("PEN").Id);
                    break;
                // only pending Denomination GC's should be selected
                case "DGC": dataSource = BusinessLogic.blGiftCertificate.retrieveForComboBox(
                    BusinessLogic.blGiftCertificateType.retrieve("DGC").Id
                    , BusinessLogic.blGiftCertificateStatus.retrieve("PEN").Id);
                    break;
                case "CPN": dataSource = BusinessLogic.blCoupon.retrieveForComboBox(); break;
                default: dataSource = BusinessLogic.blParticularType.retrieveEmptyComboBox(); break;

            }

            //add the current particular code on the datasource if not existing.  
            //this is to keep the issued GC Code be available on the dropdown.
            if (selectedDetail.ParticularCode != "")
            {
                if (selectedDetail.ParticularTypeCode == "PGC" | selectedDetail.ParticularTypeCode == "DGC")
                {
                    Entity.GiftCertificate partCode = BusinessLogic.blGiftCertificate.retrieve(selectedDetail.ParticularCode);
                    if (partCode != null)
                    {
                        ((List<Entity.GiftCertificate>)dataSource).Insert(0, partCode);
                    }
                }
            }

            BindGVDetailsComboBox(dataSource, gvOrderTransactionDetail.Columns[e.ColumnIndex].Name);


            cboParticulars.Visible = true;
            Rectangle recPos = gvOrderTransactionDetail.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            cboParticulars.Top = recPos.Top + gvOrderTransactionDetail.Top;
            cboParticulars.Left = recPos.Left + gvOrderTransactionDetail.Left;
            cboParticulars.Width = recPos.Width;

            if (gvOrderTransactionDetail.CurrentRow.Cells[e.ColumnIndex].Value != null) cboParticulars.Text = gvOrderTransactionDetail.CurrentRow.Cells[e.ColumnIndex].Value.ToString();//get the current value of the cell

            cboParticulars.Focus();
        }

        private void gvOrderTransactionDetail_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Entity.OrderTransactionDetail detail = ((Entity.OrderTransactionDetail)e.Row.DataBoundItem);
            e.Cancel = detail.IsRejectedOrder;
        }

        private void gvOrderTransactionDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception == null) return;
            Console.Write(e.Exception.Message);
            //e.Cancel = true;
            //MessageBox.Show("Invalid Data Entered. Cancelling Input", "Transaction");
            //gvOrderTransactionDetail.ca.CancelEdit();
            //gvOrderTransactionDetail.EndEdit();
            //gvOrderTransactionDetail.Refresh();
            gvOrderTransactionDetail.RefreshEdit();
            //gvOrderTransactionDetail.Rows.Remove(gvOrderTransactionDetail.Rows[e.RowIndex]);

        }

        private void gvOrderTransactionDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2 | e.ColumnIndex == 7)
            {
                //double x=0;
                //if (!double.TryParse(e.FormattedValue.ToString(), out x))
                //{
                //    gvOrderTransactionDetail.CancelEdit();
                //    e.Cancel = true;
                //}
            }
            if (e.FormattedValue.GetType() != gvOrderTransactionDetail.CurrentCell.ValueType)
            {
                //e.Cancel = true;
            }
            
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            Customer frm = new Customer();
            frm.CustomerId = _CustomerEntity.Id;
            frm.ShowDialog();
            frm.Dispose();
            frm = null;

            _CustomerEntity = BusinessLogic.blCustomer.retrieve(_CustomerEntity.Id);

            txtPrivilegeCardCode.Text = _CustomerEntity.PrivilegeCardCode;
            txtMothersName.Text = _CustomerEntity.MothersName;
            txtMothersLandLine.Text = _CustomerEntity.MothersLandLine;
            txtMothersCellNumber.Text = _CustomerEntity.MothersCellNumber;
        }

      
        private void cboProductType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindParticular();
            ControlLinkAdd();
            txtGiftChequeNumber.Text = "";
            dtpExpirationDate.Text = "";
        }
        private void NumericEntry(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57)) //|| e.KeyChar != 8)
            {
                if(e.KeyChar!=8)
                    e.Handled = true;
            }
        }
        private void ControlLinkAdd()
        {
            //if(!txtGiftChequeNumber.Enabled)
            //    lnkAddItem.Enabled = cboProductDescription.Items.Count > 0 &&
            //        cboProductType.Items.Count>0 && txtQuantity.TextLength > 0 && txtDiscount.TextLength > 0;
            //else
            //    lnkAddItem.Enabled = cboProductDescription.Items.Count > 0 &&
            //       cboProductType.Items.Count > 0 && txtQuantity.TextLength > 0 && txtDiscount.TextLength > 0&&
            //       txtGiftChequeNumber.TextLength>0;

            if (!btnGiftChequeLookUp.Enabled)//check if not a gift cheque
            {
                lnkAddItem.Enabled = cboProductDescription.Items.Count > 0 &&
                    cboProductType.Items.Count > 0 && txtQuantity.TextLength > 0 && txtDiscount.TextLength > 0;
            }
            else//gift cheque
            {
                lnkAddItem.Enabled = cboProductDescription.Items.Count > 0 &&
                  cboProductType.Items.Count > 0 && txtQuantity.TextLength > 0 && txtDiscount.TextLength > 0 &&
                  txtGiftChequeNumber.TextLength > 0;
            }
        }
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {

            NumericEntry(sender, e);
           
        }

       

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            ControlLinkAdd();
        }

        private void cboProductDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtGiftChequeNumber_TextChanged(object sender, EventArgs e)
        {
            ControlLinkAdd();
        }

        private void lnkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cboProductType.SelectedIndex = 0;
            txtQuantity.Clear();
            txtGiftChequeNumber.Clear();
            dtpExpirationDate.Text = "";
        }
        private void GetTypeAndStatus(out long statusid, out long typeid)
        {
            statusid = -1;
            typeid = -1;
            switch (Convert.ToInt64(cboProductType.SelectedValue))
            {
                case 3://Product GC
                case 23://Package Product GC
                    typeid = 3;
                    statusid = 1;
                    //SetExpirationDate("GC");
                    break;
                case 4://Denomination GC
                    typeid = 4;
                    statusid = 1;
                    //SetExpirationDate("GC");
                    break;
                case 21://Package Redemption Gift Cheque
                case 22://Upgrace redemption Gift Cheque
                case 10://Redemption Gift Cheque
                    //typeid = 3;
                    //statusid = 2;
                    ////SetExpirationDate("GC");
                   // break;
                case 11://Update Redemption Gift Cheque
                    statusid = 2;
                    typeid = 3;
                    //SetExpirationDate("GC");
                    break;
                case 5://Coupon
                    statusid = 1;
                    typeid = 4;
                    //SetExpirationDate("Coupon");
                    break;
                case 13://Redemption Coupon
                    statusid = 2;
                    typeid = 4;
                    //SetExpirationDate("Coupon");
                    break;
                case 14://Update Redemption Coupon
                    statusid = 2;
                    typeid = 4;
                    //SetExpirationDate("Coupon");
                    break;
            }
        }
        private void SetExpirationDate(string expirationtype)
        {
            DateTime dt = DateTime.Now;
            int addParam = 0;
            switch (expirationtype)
            {
                case "GC":
                    addParam = _autogcadd;//Convert.ToInt32(ConfigurationManager.AppSettings["autogcadd"]);
                    break;
                case "Coupon":
                    addParam = _autocouponadd;//Convert.ToInt32(ConfigurationManager.AppSettings["autocouponadd"]);
                    break;
                default:
                    addParam = 0;
                    break;
            }
            dtpExpirationDate.Value = dt.AddMonths(addParam);
            
            
        }
        private bool CheckIfNonProductExist(string code)
        {
            bool retValue = true;
            foreach (OrderTransactionDetail otd in _OrderTransactionEntity.OrderTransactionDetailList)
            {
                if (otd.Particulars.Equals(code))
                {
                    retValue = false;
                    break;
                }
            }
            return retValue;
        }
        private bool ValidateExpirationDate(DateTime expirationdate)
        {
            bool retValue = false;
            DateTime endExpirationDate = Convert.ToDateTime(
                string.Format("{0} 11:59:59 PM",
                expirationdate.ToString("MM/dd/yyyy")));
            if (DateTime.Now <= endExpirationDate)
            {
                retValue = true;
            }

            return retValue;
        }
        private void btnGiftChequeLookUp_Click(object sender, EventArgs e)
        {
            bool? isGiftCheque = null;
            long statusId=0, typeId=0;
            //bool isFound = false;
            long productType = Convert.ToInt64(cboProductType.SelectedValue);
            #region Check if Coupon
            if (_productCouponIds.Contains(productType))
            {
                isGiftCheque = false;
                typeId = Convert.ToInt64(ConfigurationManager.AppSettings["CPPCP"]);
            }
            if (!isGiftCheque.HasValue)
            {
                if (_redemptionCouponIds.Contains(productType))
                {
                    isGiftCheque = false;
                }
            }
                
               
            #endregion

            #region Check if GiftCheque
            if (!isGiftCheque.HasValue)
            {
                if (_redemptionGcIds.Contains(productType))
                    isGiftCheque = true;

                if (!isGiftCheque.HasValue)
                {
                    if (_gcIds.Contains(productType))
                        isGiftCheque = true;
                }
            }
            #endregion
            if (!isGiftCheque.HasValue)
            {
                MessageBox.Show("Unable to Identify if coupon of gift check");
                return;
            }
            GetTypeAndStatus(out statusId,out typeId);
            long productListId = Convert.ToInt64(cboProductDescription.SelectedValue);
            if (_blUtility.EnableParentGCCoupon(productType))
            {
                List<RedemptionGCCoupon> redemptionGCCoupons = blProductList.GetRetrieveParentProductId(
                    productListId);
                if (redemptionGCCoupons.Count == 0)
                {
                    MessageBox.Show("Redemption GC or Coupon should be mapped to\r\ntheir parent gc or coupon type");
                    return;
                }

                productListId = redemptionGCCoupons[0].ParentProductListId;
            }

            if (isGiftCheque.Value)
            {
                AdminGiftCertificate frm = new AdminGiftCertificate(true,
                    statusId, typeId, productListId);
                frm.ShowDialog();
                frm.Dispose();
                if (frm.Id > -1)
                {
                    //Validate if GC Code already exist
                    if (!CheckIfNonProductExist(frm.Code))
                    {
                        MessageBox.Show("GC is already included in the list");
                        return;
                    }
                    //check if complementary
                    if (!frm.Complementary)
                    {
                        //Validate expiration date
                        if (!ValidateExpirationDate(frm.ExpirationDate))
                        {
                            DialogResult diag = MessageBox.Show("GC is already expired.\r\nDo you still want to accept?",
                                                            "Expired GC", MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);
                            if (diag == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }

                    txtGiftChequeNumber.Text = frm.Code;
                    dtpExpirationDate.Value = frm.ExpirationDate;
                    if(txtQuantity.TextLength>0&&
                        cboProductDescription.Items.Count>0)
                        lnkAddItem.Enabled = true;
                }
                else
                {
                    lnkAddItem.Enabled = false;
                }
                frm = null;
            }
            else
            {
                AdminCoupon frm = new AdminCoupon(true, statusId,productListId);
                frm.ShowDialog();
                frm.Dispose();
                if (frm.Id > -1)
                {
                    //Validate if GC Code already exist
                    if (!CheckIfNonProductExist(frm.Code))
                    {
                        MessageBox.Show("Coupon is already included in the list");
                        return;
                    }
                    //Validate expiration date
                    if (!ValidateExpirationDate(frm.ExpirationDate))
                    {
                        DialogResult diag = MessageBox.Show("Coupon is already expired.\r\nDo you still want to accept?",
                                                        "Expired GC", MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);
                        if (diag == DialogResult.No)
                        {
                            return;
                        }
                    }
                    txtGiftChequeNumber.Text = frm.Code;
                    dtpExpirationDate.Value = frm.ExpirationDate;
                    if (txtQuantity.TextLength > 0 &&
                        cboProductDescription.Items.Count > 0)
                        lnkAddItem.Enabled = true;
                }
                else
                {
                    lnkAddItem.Enabled = false;
                }
                frm = null;
            }

        }

        private void txtGiftChequeNumber_EnabledChanged(object sender, EventArgs e)
        {
            dtpExpirationDate.Enabled = txtGiftChequeNumber.Enabled;
        }
        private ProductList GetProductList()
        {
            return blProductList.retreiveById(Convert.ToInt64(
                cboProductDescription.SelectedValue));
        }
        private string ConcatItems(List<ProductListDetails> productlistdetails)
        {
            StringBuilder sb = new StringBuilder();
            string retValue = "";
            foreach (ProductListDetails productListDetail in productlistdetails)
            {
                sb.Append(string.Concat(productListDetail.Particulars, ","));
            }
            if (sb.ToString().EndsWith(","))
            {
                retValue = sb.ToString().Remove(sb.ToString().LastIndexOf(','), 1);
            }
            return retValue;
        }

        private string GetParticulars(List<ProductListDetails> productlistDetails)
        {
            string particulars = "";
            
            switch (Convert.ToInt64(cboProductType.SelectedValue))
            {
                case 3://Product Gift Certificate
                case 4://Denomination Gift Certificate
                case 5:
                case 11://Upgrade redemption Gift Cheque
                case 21://Package Redemption Gift Cheque
                case 22://Upgrade Redemption Gift Cheque
                case 23://Package Gift Cheque
                case 10://Redemption Gift Cheque   
                case 13://Upgrade Coupon
                case 14:
                    particulars = txtGiftChequeNumber.Text.Trim();
                    break;                                                  
                default:
                    particulars = ConcatItems(productlistDetails);                   
                    break;
            }
            
            return particulars;
        }
        private double GetAmount(double unitprice)
        {
            double amount = 0;
            amount = Convert.ToInt32(txtQuantity.Text.Trim()) * unitprice * (1 - (Convert.ToDouble(txtDiscount.Text.Trim()) / 100));
            return amount;
        }
        private void ComputeTotalAmout()
        {
            double totalAmount = 0;
            foreach (OrderTransactionDetail otd in _OrderTransactionEntity.OrderTransactionDetailList)
            {
                totalAmount = totalAmount + otd.Amount;
            }
            txtTotalAmountDue.Text = totalAmount.ToString();
        }
        public bool CheckQuantityIfGiftCheque()
        {
            bool isAllow=true;
            int quantity = Convert.ToInt32(txtQuantity.Text.Trim());
            switch (Convert.ToInt64(cboProductType.SelectedValue))
            {
                case 3://Package Gift Certificate
                case 4://Denomination Gift certificate
                case 5://Coupon
                case 21://Package Redemption Gift Cheque
                case 11://Update redemption gift cheque
                case 10://Redemption Gift Cheque  
                case 23://Package Gift Certificate
                case 13://Redemption Coupon
                case 14://Upgrade Redemption Coupon
                    isAllow = (quantity == 1);
                    break;
                default:
                    
                    break;
            }
            return isAllow;
        }
        int? _rowIndex = null;
        private void lnkAddItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            double adjustment = 0;
            if (double.TryParse(txtDiscount.Text.Trim(), out adjustment))
            {
                
                if (!CheckQuantityIfGiftCheque())
                {
                    MessageBox.Show("Quantity which are greater than one is not allowed in gift cheque or coupon");
                    return;
                }
                if (!_rowIndex.HasValue)
                {
                    OrderTransactionDetail orderTransactionDetail = new OrderTransactionDetail();
                    orderTransactionDetail.Adjustment = adjustment;//Convert.ToDouble(txtDiscount.Text.Trim());
                    //orderTransactionDetail.DateLastModified = DateTime.Now;
                    orderTransactionDetail.ParticularTypeCode = cboProductType.Text;
                    orderTransactionDetail.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                    ProductList productList = GetProductList();
                    orderTransactionDetail.UnitPrice = productList.UnitPrice;
                    orderTransactionDetail.ParticularCode = productList.Description;
                    orderTransactionDetail.Particulars = GetParticulars(productList.ProductListDetails);
                    if (string.IsNullOrEmpty(orderTransactionDetail.Particulars))
                    {
                        MessageBox.Show(string.Format("{0} has invalid item,Please proceed to Admin module \r\nand adjust this particular item",
                            orderTransactionDetail.ParticularTypeCode));
                        return;
                    }
                    //orderTransactionDetail.ProductListEntity = productList;
                    orderTransactionDetail.ParticularTypeId = Convert.ToInt64(cboProductType.SelectedValue);
                    orderTransactionDetail.ProductListId = Convert.ToInt64(cboProductDescription.SelectedValue);
                    orderTransactionDetail.ParticularTypeCode = cboProductType.Text;
                    orderTransactionDetail.RecordId = gvOrderTransactionDetail.RowCount + 1;
                    orderTransactionDetail.Amount = GetAmount(productList.UnitPrice);
                    _OrderTransactionEntity.OrderTransactionDetailList.Add(orderTransactionDetail);
                    BindToGridView(gvOrderTransactionDetail, _OrderTransactionEntity.OrderTransactionDetailList);
                    orderTransactionDetail = null;
                }
                else
                {

                }
                txtDiscount.Text = "0";
                txtGiftChequeNumber.Clear();
                txtQuantity.Clear();
                //ComputeTotalAmout();
                UpdateDataGridViewTotals();
            }
            else
            {
                MessageBox.Show("Invalid adjustment value");
            }
           
        }
         Dictionary<long, bool> _orderPackageDetailIdRejection = new Dictionary<long, bool>();//for rejecting individual item on the package
        Dictionary<long, bool> _orderDetailIdForRejection = new Dictionary<long,bool>();//for rejectring item of non package
        //Dictionary<long, bool> _orderPackageForRejection = new Dictionary<long, bool>();//for rejection individual item on the package via orderpackagedetailid
        private void gvOrderTransactionDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //Get the column Name if the cell content came from mark as deleted or mark as rejected column
                DataGridViewRow row = gvOrderTransactionDetail.Rows[e.RowIndex];
                string name = gvOrderTransactionDetail.Columns[e.ColumnIndex].Name;
                switch (name)
                {
                   
                    case "colChkDeleted":
                        if (row.Cells["colOrderDetailsId"].Value.ToString() != "-1") //check if the record is already existing on the database                       
                        {
                            //check if the item is already done on the job order if already existing it means that 
                            //the user can no longer delete the item
                           
                            //if (gvOrderTransactionDetail.Rows[e.RowIndex].Cells["colChkDeleted"].Value != null)
                            //{
                            DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)row.Cells["colChkDeleted"];
                                //if ((bool)gvOrderTransactionDetail.Rows[e.RowIndex].Cells["colChkDeleted"].Value)
                                if((bool)checkBox.EditingCellFormattedValue)
                                {
                                    if (!blJobOrderDetail.AllowRejectOrDelete((long)row.Cells["colOrderDetailsId"].Value))
                                    {
                                        MessageBox.Show("This item is already printed in job order\r\nAttempting to delete is not allowed");
                                        
                                       row.Cells["colChkDeleted"].Value = false;
                                        //row.Selected = false;
                                        //checkBox.Value = false;
                                    }
                                }
                                checkBox = null;
                            //}                                                                                                              
                        }
                        break;
                }
               //row = null;
            }
        }
       
        private void lnkRemoveItems_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<int> recordIds = new List<int>();//collection that hold the rows mark as deleted
            //get the indexes of the item(s) to be deleted 
            //since that the Grid setup is not sortable,getting the 
            //indexes would not cause any problem
            for(int i=0;i<gvOrderTransactionDetail.Rows.Count;i++)
            {
                if((bool)gvOrderTransactionDetail.Rows[i].Cells["colChkDeleted"].EditedFormattedValue)
                {                   
                        recordIds.Add((int)gvOrderTransactionDetail.Rows[i].Cells["colRecordId"].Value);                                                          
                }
            }

            if (recordIds.Count == 0)
            {
                MessageBox.Show("No Item(s) is/are selected");
                return;
            }

            List<int> recordIdsForDeletion = new List<int>();
            List<long> orderDetailsForDeletion = new List<long>();
            //iterate now after collecting the indexes
            foreach (int recordId in recordIds)
            {
                foreach (DataGridViewRow row in gvOrderTransactionDetail.Rows)
                {
                    int rowRecordId = (int)row.Cells["colRecordId"].Value;
                    if (row.Cells["colOrderDetailsId"].Value.ToString() != "-1")
                    {
                        if (recordId == rowRecordId)
                        {
                            orderDetailsForDeletion.Add((long)row.Cells["colOrderDetailsId"].Value);
                            break;
                        }
                    }
                    else
                    {
                        if (recordId == rowRecordId)
                        {
                            recordIdsForDeletion.Add((int)row.Cells["colRecordId"].Value);
                            break;
                        }
                    }
                }
            }
            //delete existing item
            foreach (long orderDetail in orderDetailsForDeletion)
            {
                //blOrderTransactionDetail.delete(orderDetail);
                int index=0;
                for (int i = 0; i < _OrderTransactionEntity.OrderTransactionDetailList.Count; i++)
                {
                    if (_OrderTransactionEntity.OrderTransactionDetailList[i].Id == orderDetail)
                    {
                        index = i;
                        break;
                    }
                }
                _OrderTransactionEntity.OrderTransactionDetailList.RemoveAt(index);
            }
            //delete the unsave item
            foreach (int recordId in recordIdsForDeletion)
            {
                int index = 0;
                for (int i = 0; i < _OrderTransactionEntity.OrderTransactionDetailList.Count; i++)
                {
                    if (_OrderTransactionEntity.OrderTransactionDetailList[i].RecordId == recordId)
                    {
                        index = i;
                        break;
                    }
                }
                _OrderTransactionEntity.OrderTransactionDetailList.RemoveAt(index);

            }
            
            //Bind
            BindToGridView(gvOrderTransactionDetail, _OrderTransactionEntity.OrderTransactionDetailList);
            UpdateDataGridViewTotals();

        }

        private void lnkAddGCCoupon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            long typeId = 0;
            long statusId=0;
            foreach (long gcId in _gcIds)
            {
                if (Convert.ToInt64(cboProductType.SelectedValue) == gcId)
                {
                    GetTypeAndStatus(out statusId, out typeId);
                    GCCouponEntry frm = new GCCouponEntry(true,
                        typeId,Convert.ToInt64(cboProductDescription.SelectedValue),cboProductDescription.Text);
                    frm.ShowDialog();
                    frm.Dispose();
                    frm = null;
                    return;
                }
            }
            foreach (long productCouponId in _productCouponIds)
            {
                if (Convert.ToInt64(cboProductType.SelectedValue) == productCouponId)
                {
                    GCCouponEntry frm = new GCCouponEntry(false,
                        0, Convert.ToInt64(cboProductDescription.SelectedValue), cboProductDescription.Text);
                    frm.ShowDialog();
                    frm.Dispose();
                    frm = null;
                    return;
                }
            }
        }
        private void gvOrderTransactionPayment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (gvOrderTransactionPayment.ReadOnly) return;
            string ModifiedColumnName = gvOrderTransactionPayment.CurrentCell.OwningColumn.Name;

            //if (ModifiedColumnName != "colAmountPaid" & ModifiedColumnName != "colBankFee" & ModifiedColumnName != "colAmountReceived") return;
            if (ModifiedColumnName != "colAmountReceived") return;


            //UpdateDataGridViewTotals();
            //UpdateDataGridViewTotals(gvOrderTransactionPayment.CurrentRow);
            //if (Convert.ToDouble(txtBalance.Text) >= 0)
                gvOrderTransactionPayment.EndEdit();
          

          
        }
        private string PaymentValidations(DataGridViewRow row)
        {
            string  errorMessage = "";
            if (row.Cells["colPaymentTypeId"].Value == null)
            {
                errorMessage="Please Select a Payment Type";             
                return errorMessage;
            }
            if (row.Cells["colDocumentNumber"].Value == null)
            {
                errorMessage="Please Input a Document Number";
                return errorMessage;
            }

            if (row.Cells["colPaymentTypeId"].Value.ToString() == "-1")
            {
                errorMessage = "Please Select a Payment Type";
                return errorMessage;
            }

            if (string.IsNullOrEmpty(row.Cells["colDocumentNumber"].Value.ToString()))
            {
                errorMessage = "Please Input a Document Number";
                return errorMessage;
            }

            if (row.Cells["colPaymentTypeId"].Value.ToString() == "5")
            {
                errorMessage = "Modifying the amount under Denomination Gift Check is not allowed";
                return errorMessage;
            }
           

            return errorMessage;

        }
       
        Dictionary<Guid, string> _guidGC = new Dictionary<Guid, string>();
        private void gvOrderTransactionPayment_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row=gvOrderTransactionPayment.Rows[e.RowIndex];
            if (row.Cells["colOrderPaymentId"].Value != null)//it means some data is already existing
            {               
                switch (gvOrderTransactionPayment.Columns[e.ColumnIndex].Name)
                {
                    case "colPaymentTypeCode":
                        if (row.Cells["colOrderPaymentId"].Value.ToString() == "-1")
                        {
                            row.Cells["colPaymentTypeCode"].Value = "-Set Payment Type-";
                        }
                        break;
                    case "colAmountReceived":
                        //Check if all needed information is already supplied before going to this column
                        string validationMsg = PaymentValidations(row);
                        if (!string.IsNullOrEmpty(validationMsg))
                            MessageBox.Show(validationMsg);
                        e.Cancel = (!string.IsNullOrEmpty(validationMsg)) ? true : false;
                      
                        break;
                   
                 
                }
            }
            else//it means new data has been inputting
            {
                switch (gvOrderTransactionPayment.Columns[e.ColumnIndex].Name)
                {
                    case "colPaymentTypeCode":
                        row.Cells["colPaymentTypeCode"].Value = "-Set Payment Type-";
                        break;
                    case "colAmountReceived":
                        //Check if all needed information is already supplied before going to this column
                        string validationMsg = PaymentValidations(row);
                        if(!string.IsNullOrEmpty(validationMsg))
                            MessageBox.Show(validationMsg);
                        e.Cancel = (!string.IsNullOrEmpty(validationMsg) ) ? true : false;
                        

                        break;
                   
                  
                }
            }
        }
        private void RemovePayment(int index)
        {
            DialogResult diagResult = MessageBox.Show("Are you sure you want to remove the selected item?", "Confirm Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diagResult == DialogResult.Yes)
            {
                if (_guidGC.ContainsKey(_OrderTransactionEntity.OrderTransactionPaymentList[index].RecordGuidId))
                    _guidGC.Remove(_OrderTransactionEntity.OrderTransactionPaymentList[index].RecordGuidId);
                _OrderTransactionEntity.OrderTransactionPaymentList.RemoveAt(index);
                BindGVPayments();
            }

        }
        private void gvOrderTransactionPayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex != -1)
            {
                if (_OrderTransactionEntity.OrderStatusId == 3)
                {
                    setButtonState("10001101");
                }
                switch (gvOrderTransactionPayment.Columns[e.ColumnIndex].Name)
                {                                     
                    case "colDocumentNumber":
                        int employeeGroupId;
                        if (_ModifiedByEmployeeEntity == null)
                            employeeGroupId = _PreparedByEmployeeEntity.EmployeeGroupId;
                        else
                            employeeGroupId = _ModifiedByEmployeeEntity.EmployeeGroupId;
                        if (_OrderTransactionEntity.OrderTransactionPaymentList[e.RowIndex].CancelledId > -1)
                            return;

                        Payment payment = new Payment(
                            
                            (Guid)gvOrderTransactionPayment.Rows[e.RowIndex].Cells["colPaymentRecordId"].Value
                            , _OrderTransactionEntity.OrderTransactionPaymentList[e.RowIndex]
                            , _hasDiscount
                            , employeeGroupId
                            , _OrderTransactionEntity.OrderTransactionPaymentList
                            ,e.RowIndex,
                             _OrderTransactionEntity.OrderTransactionDetailList);
                        payment.ShowDialog();
                        BindGVPayments();
                        UpdateDataGridViewTotals();                       
                        payment.Dispose();
                        payment = null;
                        
                        break;
                    case "colCancelled":
                        long paymentId = Convert.ToInt64(gvOrderTransactionPayment.Rows[e.RowIndex].Cells["colOrderPaymentId"].Value);
                        if (_OrderTransactionEntity.OrderTransactionPaymentList[e.RowIndex].CancelledId > -1)
                        {
                            _OrderTransactionEntity.OrderTransactionPaymentList.RemoveAt(e.RowIndex);
                            BindGVPayments();
                            UpdateDataGridViewTotals();
                            return;
                        }
                        if (paymentId == -1)
                        {
                            MessageBox.Show("Unable to Cancel the unsave payment");
                            return;
                        }
                        string processMsg = blOrderTransactionPayment.EnableCancel(paymentId,
                            _OrderTransactionEntity.OrderTransactionPaymentList
                            ,Convert.ToDouble(gvOrderTransactionPayment.Rows[e.RowIndex].Cells["colAmountReceived"].Value)
                            ,Convert.ToInt64(gvOrderTransactionPayment.Rows[e.RowIndex].Cells["colPaymentTypeId"].Value));
                        if (!string.IsNullOrEmpty(processMsg))
                        {
                            MessageBox.Show(processMsg);
                            return;
                        }



                            CancelPayment frm = new CancelPayment(
                                Convert.ToInt64(gvOrderTransactionPayment.Rows[e.RowIndex].Cells["colOrderPaymentId"].Value), _OrderTransactionId,
                                _OrderTransactionEntity.OrderTransactionPaymentList,
                                e.RowIndex);
                            frm.ShowDialog();
                            BindGVPayments();
                            UpdateDataGridViewTotals();
                            frm.Dispose();
                            frm = null;
                            //_OrderTransactionEntity.OrderTransactionPaymentList = blOrderTransactionPayment.retrieveByOrderTransactionId(
                            //    _OrderTransactionId);
                            
                     
                     
                        break;
                    default:
                        break;
                }
            }
        }

        private void gvOrderTransactionDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            gvOrderTransactionPayment.Enabled = true;
            //gvOrderTransactionPayment.AllowUserToAddRows = true;
            //lnkAddPayment.Enabled = true;
        }

        private void gvOrderTransactionDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (gvOrderTransactionDetail.RowCount == 0)
            {
                gvOrderTransactionPayment.Enabled = false;
                //lnkAddPayment.Enabled = false;
                
            }
        }

        //private void gvOrderTransactionPayment_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        //{
          

        //        DataGridViewRow lastRow = gvOrderTransactionPayment.Rows[gvOrderTransactionPayment.RowCount - 1];

        //        if (lastRow.Cells["colOrderPaymentId"].Value != null)
        //        {
        //            if (lastRow.Cells["colOrderPaymentId"].Value.ToString() == "-1")
        //            {
        //                lastRow.Cells["colDatePaid"].Value = DateTime.Now.ToString("MM/dd/yyyy");
        //                lastRow.Cells["colPaymentTypeCode"].Value = "-Set Payment Type-";
        //            }
        //        }
        //        else
        //        {
        //            lastRow.Cells["colDatePaid"].Value = DateTime.Now.ToString("MM/dd/yyyy");
        //            lastRow.Cells["colPaymentTypeCode"].Value = "-Set Payment Type-";
        //        }
          
        //        if (gvOrderTransactionPayment.CurrentRow == null)
        //        {
        //            gvOrderTransactionPayment.AllowUserToAddRows = false;
        //        }
        //}
        private bool ValidateAllPaymentValue()
        {
            bool allowAdd = false;
            DataGridViewRow lastRow = gvOrderTransactionPayment.Rows[gvOrderTransactionPayment.RowCount - 1];
            if (lastRow.Cells["colPaymentTypeId"].Value.ToString() == "-1")
            {
                
                return allowAdd;
            }

            if (lastRow.Cells["colDocumentNumber"].Value == null)
                return allowAdd;

            if (lastRow.Cells["colAmountReceived"].Value == null)
                return allowAdd;

            if (string.IsNullOrEmpty(lastRow.Cells["colDocumentNumber"].Value.ToString()))
                return allowAdd;

            if (string.IsNullOrEmpty(lastRow.Cells["colAmountReceived"].Value.ToString()))
            {
                return allowAdd;
            }
            allowAdd = true;
            return allowAdd;
        }
        private void AddNewModeOfPayment()
        {
            OrderTransactionPayment orderPayment = new OrderTransactionPayment();
            orderPayment.PaymentTypeCode = "-Set Payment Type-";
            _OrderTransactionEntity.OrderTransactionPaymentList.Add(orderPayment);
            BindGVPayments();
        }
    
        private void lnkAddPayment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_OrderTransactionEntity.OrderStatusId == 3)
            {
                setButtonState("10001101");
            }

            int emplogroupId;
            if (_ModifiedByEmployeeEntity == null)
                emplogroupId = _PreparedByEmployeeEntity.EmployeeGroupId;
            else
                emplogroupId = _ModifiedByEmployeeEntity.EmployeeGroupId;

            _hasDiscount = BLService.HasDiscount(gvOrderTransactionDetail);

            Payment frm = new Payment(
                null
                , new OrderTransactionPayment()
                , _hasDiscount
                , emplogroupId
                , _OrderTransactionEntity.OrderTransactionPaymentList
                ,_OrderTransactionEntity.OrderTransactionPaymentList.Count,
                 _OrderTransactionEntity.OrderTransactionDetailList);
            frm.ShowDialog();
            BindGVPayments();
            UpdateDataGridViewTotals();
         
            frm.Dispose();
            frm = null;
            
               
        }

        private void gvOrderTransactionPayment_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            string colName = gvOrderTransactionPayment.Columns[e.ColumnIndex].Name;
            if (colName.Equals("colAmountReceived"))
            {
                if (gvOrderTransactionPayment.Rows[e.RowIndex].Cells[colName].Value != null)
                {
                    decimal amountReceived = 0;
                    if (!decimal.TryParse(
                        gvOrderTransactionPayment.Rows[e.RowIndex].Cells[colName].EditedFormattedValue.ToString(),
                        out amountReceived))
                    {
                        MessageBox.Show("Amount Received should be in numeric format",
                                   "Invalid Format"
                                   , MessageBoxButtons.OK
                                   , MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Amount Received should be in numeric format",
                                    "Invalid Format"
                                    , MessageBoxButtons.OK
                                    , MessageBoxIcon.Warning);
                }
            }

        }
     

        

      




    }
}