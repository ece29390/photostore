using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.BusinessLogic;
using PhotoStore.Entity;
using System.Configuration;
namespace PhotoStore
{
    public partial class RejectOrderTransaction : Form
    {
        Dictionary<long, bool> _packageDetailId, _orderDetailIdRejected;
        OrderTransaction _orderTransaction;
        bool _isSave = false;
        bool _isViewing = false;
        Employee _preparedEmployee = null;
        List<vwParticularsForRejection> _particularForRejection;
        Dictionary<int, bool> _selectedIndexes = new Dictionary<int, bool>();
        public bool IsSave
        {
            get { return _isSave; }
        }
        public RejectOrderTransaction(
            Dictionary<long,bool> packageDetailId 
            ,Dictionary<long,bool> orderDetailIdRejected
            ,OrderTransaction ordertransaction
            ,Employee preparedemployee,bool isviewing)
        {
            InitializeComponent();
            //txtCode.Text = ordercode;
            //txtOrderStatus.Text = orderstatus;
            //InitializeComponent();
            _packageDetailId = packageDetailId;
            _orderDetailIdRejected = orderDetailIdRejected;
            _orderTransaction = ordertransaction;
            _preparedEmployee = preparedemployee;
            _isViewing = isviewing;
        }

        public RejectOrderTransaction(
           OrderTransaction ordertransaction)
        {
            _orderTransaction = ordertransaction;
            _isViewing = true;
            InitializeComponent();
        }
        public RejectOrderTransaction(OrderTransaction ordertransaction,
            Employee employee,List<vwParticularsForRejection> particularsforrejection)
        {
            InitializeComponent();
            _preparedEmployee = employee;
            _particularForRejection = particularsforrejection;
            _orderTransaction = ordertransaction;
        }

        private void BindRejectItems()
        {
            //gvRejectItems.AutoGenerateColumns = false;
            //BindingSource bs = UI.BindSource(_rejectedOrders, false);
            //gvRejectItems.DataSource = bs;

            //if (_isViewing)
            //{
            //    foreach (DataGridViewRow row in gvRejectItems.Rows)
            //    {
            //        row.Cells["colQuantity"].ReadOnly = true;
            //    }
            //}
            gvRejectItems.AutoGenerateColumns = false;
            BindingSource bs = UI.BindSource(_particularForRejection, false);
            gvRejectItems.DataSource = bs;
            _selectedIndexes = blUtility.SelectedItems(
                gvRejectItems, "colChk");
            BLService.ApplyColor(Color.LightGray,
                gvRejectItems, _selectedIndexes);
            
        }



        private void BindOrderDetails(List<OrderTransactionDetail> orderdetails)
        {
            lnkRemoveItems.Enabled = (orderdetails.Count > 0) ? true : false;
            gvOrderTransactionDetail.AutoGenerateColumns = false;            
            BindingSource bs = UI.BindSource(orderdetails, false);
            gvOrderTransactionDetail.DataSource = bs;
        }
        List<RejectedOrder> _rejectedOrders = null;
        private void CheckRejectItems()
        {
            gvRejectItems.AutoGenerateColumns = false;
            //if (Convert.ToBoolean(ConfigurationManager.AppSettings["OrderTransactionDetail"]))
            //{
                StringBuilder sbOrderDetailIds = new StringBuilder(), sbOrderPackageIds = new StringBuilder();
                string inOrderDetailIds = "";
                if (_orderDetailIdRejected.Count > 0)
                {
                    if (_orderDetailIdRejected.ContainsValue(true))
                    {
                        foreach (long key in _orderDetailIdRejected.Keys)
                        {
                            if (_orderDetailIdRejected[key])
                            {
                                if (!sbOrderDetailIds.ToString().StartsWith("IN ("))
                                    sbOrderDetailIds.Append("IN (");

                                sbOrderDetailIds.Append(string.Format("{0},", key));
                            }
                        }

                        if (!string.IsNullOrEmpty(sbOrderDetailIds.ToString()))
                        {
                            inOrderDetailIds = sbOrderDetailIds.ToString();
                            if (inOrderDetailIds.EndsWith(","))
                            {
                                inOrderDetailIds = inOrderDetailIds.Remove(
                                    inOrderDetailIds.LastIndexOf(','), 1);
                                inOrderDetailIds = string.Concat(inOrderDetailIds, ')');
                            }
                        }




                    }
                }

                StringBuilder sbPackageDetails = new
                     StringBuilder();
                string inPackageDetails = "";
                foreach (long key in _packageDetailId.Keys)
                {
                    if (_packageDetailId[key])
                    {
                        if (!sbPackageDetails.ToString().StartsWith("IN ("))
                            sbPackageDetails.Append("IN (");

                        sbPackageDetails.Append(string.Format("{0},", key));
                    }
                }

                inPackageDetails = sbPackageDetails.ToString();
                if (!string.IsNullOrEmpty(inPackageDetails))
                {
                    inPackageDetails = inPackageDetails.Remove(
                        inPackageDetails.LastIndexOf(','), 1);
                    inPackageDetails = string.Concat(inPackageDetails, ')');

                   
                }
                _rejectedOrders = blOrderTransactionDetail.retrieveOrderRejectedItems(
                           inOrderDetailIds, inPackageDetails);
                //else
                //    _rejectedOrders = new List<RejectedOrder>();

                //BindingSource bs = UI.BindSource(_rejectedOrders, false);
                //gvRejectItems.DataSource = bs;
                BindRejectItems();

            //}
            //else
            //{
            //    StringBuilder sbPackageDetails = new
            //        StringBuilder();
            //    string inPackageDetails = "";
            //    foreach (long key in _packageDetailId.Keys)
            //    {
            //        if (_packageDetailId[key])
            //        {
            //            if (!sbPackageDetails.ToString().StartsWith("IN ("))
            //                sbPackageDetails.Append("IN (");

            //            sbPackageDetails.Append(string.Format("{0},", key));
            //        }
            //    }
            //    inPackageDetails = sbPackageDetails.ToString();
            //    if (!string.IsNullOrEmpty(inPackageDetails))
            //    {
                    
            //        inPackageDetails = inPackageDetails.Remove(
            //            inPackageDetails.LastIndexOf(','), 1);
            //        inPackageDetails = string.Concat(inPackageDetails, ')');
            //        _rejectedOrders = blOrderTransactionDetail.retrieveOrderRejectedItems(
            //            inPackageDetails);
            //    }
            //    else
            //    {
            //        _rejectedOrders = new List<RejectedOrder>();
            //    }
            //    //BindingSource bs = UI.BindSource(_rejectedOrders, false);
            //    //gvRejectItems.DataSource = bs;
            //    BindRejectItems();
            //}

            btnReject.Enabled = (gvRejectItems.Rows.Count == 0) ? false : true;
        }
        private void BindParticularType()
        {
            List<ParticularType> particularTypes = blParticularType.retrieveAllForReject();
            cboParticularType.ValueMember = "Id";
            cboParticularType.DisplayMember = "Description";
            cboParticularType.DataSource = UI.BindSource(particularTypes, false);
            //BindParticular(particularTypes[0].Id);

        }
        private void BindParticular()
        {
            List<ProductList> productLists = blProductList.retrieveByParticularTypeId(
                Convert.ToInt64(cboParticularType.SelectedValue));
            if (cboProductDescription.DataSource != null)
            {
                //cboProductDescription.Items.Clear();
                cboProductDescription.DataSource = null;
            }
            cboProductDescription.ValueMember = "Id";
            cboProductDescription.DisplayMember = "Description";
            cboProductDescription.DataSource = UI.BindSource(productLists, false);

        }
        private void BindItem()
        {
            List<ProductListDetails> productLists = blProductListDetails.retrieveByProductListId(
                Convert.ToInt64(cboProductDescription.SelectedValue));
            cboProductItem.DataSource = null;
            cboProductItem.ValueMember = "Id";
            cboProductItem.DisplayMember = "Particulars";
            cboProductItem.DataSource = UI.BindSource(productLists, false);
            

        }
        OrderTransaction _rejectOrderTransaction = null;
        private void RejectOrderTransaction_Load(object sender, EventArgs e)
        {
                                         
                
              
                    BindParticularType();
                    BindParticular();
                    BindItem();
                    
                    _rejectOrderTransaction = blOrderTransaction.retrieveByRejectCode(
                        _orderTransaction.Code);
                    if (_rejectOrderTransaction != null)//if null it means no records that corresponds to the reject code
                    {
                        //groupBox2.Enabled = false;
                        txtCode.Text = _rejectOrderTransaction.Code;
                        txtDateCreated.Text = _rejectOrderTransaction.DateCreated.ToString("MM/dd/yyyy");
                        txtOrderStatus.Text = string.Concat(_rejectOrderTransaction.OrderStatusEntity.Description, " from ", _rejectOrderTransaction.RejectedCode);
                        for (int i = 0; i < _rejectOrderTransaction.OrderTransactionDetailList.Count; i++)
                        {
                            if (i > 0)
                            {
                                _rejectOrderTransaction.OrderTransactionDetailList[i].RecordId =
                                    _rejectOrderTransaction.OrderTransactionDetailList[i - 1].RecordId + 1;
                            }
                            else
                            {
                                _rejectOrderTransaction.OrderTransactionDetailList[i].RecordId = 1;
                            }
                        }
                        BindOrderDetails(_rejectOrderTransaction.OrderTransactionDetailList);
                    }
                    else
                    {

                        _rejectOrderTransaction = new OrderTransaction();

                        groupBox2.Enabled = true;
                        _rejectOrderTransaction.Code = blOrderTransaction.retrieveNextCode();
                        _rejectOrderTransaction.DateCreated = DateTime.Now;
                        txtCode.Text = _rejectOrderTransaction.Code;
                        txtDateCreated.Text = DateTime.Now.ToString("MM/dd/yyyy");
                        _rejectOrderTransaction.OrderStatusEntity = blOrderStatus.retrieve("RejectedOrder");
                        _rejectOrderTransaction.OrderStatusId = _rejectOrderTransaction.OrderStatusEntity.Id;
                        _rejectOrderTransaction.CustomerId = _orderTransaction.CustomerId;
                        _rejectOrderTransaction.PriviledgeCard = _orderTransaction.PriviledgeCard;
                        _rejectOrderTransaction.PreparedByEmployeeEntity = _preparedEmployee;
                        _rejectOrderTransaction.PreparedByEmployeeId = _preparedEmployee.Id;
                        _rejectOrderTransaction.RejectedCode = _orderTransaction.Code;
                        txtOrderStatus.Text = string.Concat(_rejectOrderTransaction.OrderStatusEntity.Description, " from ", _orderTransaction.Code);
                    }

                if (_isViewing)
                {
                    groupBox2.Enabled = false;
                    btnSave.Visible = false;
                    btnReject.Visible = false;
                    _rejectedOrders = blOrderTransactionDetail.viewRejectedOrder(_orderTransaction.Id);
                }
                BindRejectItems();

        }
        private void NumericEntry(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57)) //|| e.KeyChar != 8)
            {
                if (e.KeyChar != 8)
                    e.Handled = true;
            }
        }
        public string _RejectRemarks;
        public string RejectRemarks
        {
            get { return _RejectRemarks; }
        }

        private bool IsValid()
        {
            int invalidRecord = 0;
            foreach (DataGridViewRow row in gvRejectItems.Rows)
            {
                int quantity = Convert.ToInt32(row.Cells["colQuantity"].Value);
                int maxQuantity = Convert.ToInt32(row.Cells["colMaxQuantity"].Value);
                if (quantity > maxQuantity)
                {
                    invalidRecord = invalidRecord + 1;
                    row.Cells["colQuantity"].Style.BackColor = Color.Aqua;
                }
                else
                {
                    if (quantity > 0)
                        row.Cells["colQuantity"].Style.BackColor = Color.White;
                    else
                    {
                        invalidRecord = invalidRecord + 1;
                        row.Cells["colQuantity"].Style.BackColor = Color.Aqua;
                    }
                }
            }
            return (invalidRecord == 0 ? true : false);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (!IsValid())
            //{
            //    MessageBox.Show("Quantity should not exceed the consumed quantity of the rejected item");
            //    return;
            //}
            if (gvOrderTransactionDetail.Rows.Count == 0)
            {
                MessageBox.Show("Please create atleast one item");
                return;
            }

//            DialogResult diag = MessageBox.Show(@"Removing the rejected item will change the order status of this 
//                                                transaction and make the deleted items available to the job order
//                                                but will not remove the previously created items
//                                                Are you sure you want to continue?",
//                                                                                    "Confirm Action",
//                                                                                    MessageBoxButtons.YesNo,
//                                                                                    MessageBoxIcon.Question);
//            if (diag == DialogResult.Yes)
//            {


                //verify the password of the employee that will reject the transaction
                Entity.Employee adminEmployee = null;
                //string rejectRemarks = "";
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
                    _RejectRemarks = frmVP.Remarks;
                    frmVP.Dispose();
                    frmVP = null;
                    //set the person who rejected be the last modifier
                    Entity.OrderTransactionModifiedBy modifiedBy = new PhotoStore.Entity.OrderTransactionModifiedBy();
                    modifiedBy.ModifiedByEmployee = adminEmployee;
                    modifiedBy.ModifiedByEmployeeId = adminEmployee.Id;
                    modifiedBy.OrderTransactionId = _rejectOrderTransaction.Id;//_orderTransaction.Id;
                    modifiedBy.Remarks = _RejectRemarks;
                    this._rejectOrderTransaction.OrderTransactionModifiedByList.Add(modifiedBy);

                    //blOrderTransactionDetail.RejectItems(_rejectedOrders,_deletedRejectOrder);
                    //Remove payment list
                    //_orderTransaction.OrderTransactionPaymentList.Clear();
                    if (_rejectOrderTransaction.Id == -1)
                        blOrderTransaction.create(_rejectOrderTransaction);
                    else
                        blOrderTransaction.update(_rejectOrderTransaction);

                    MessageBox.Show("Successful Process");
                    _isSave = true;

                    //foreach (RejectedOrder rejectedOrder in _deletedRejectOrder)
                    //{
                    //    if (rejectedOrder.IsPackage)
                    //    {
                    //        _packageDetailId[rejectedOrder.OrderPackageDetailsId] = false;
                    //    }
                    //    else
                    //    {
                    //        _orderDetailIdRejected[rejectedOrder.OrderDetailsId] = false;
                    //    }
                    //}

                    //if (gvRejectItems.RowCount == 0)
                    //{
                    //    for (int i = 0; i < _orderTransaction.OrderTransactionDetailList.Count; i++)
                    //    {
                    //        _orderTransaction.OrderTransactionDetailList[i].IsRejectedOrder = false;
                    //    }
                    //}
                                                                                                        
                    this.Close();

                }
            //}
            //else
            //{
            //    Close();
            //}

            
        }
      

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindParticular();
            BindItem();
            ControlAddLink();
        }

        private void cboProductDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindItem();
            ControlAddLink();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumericEntry(sender, e);
        }
        //List<long> _deleteJobOrderReject=new List<long>();
        List<RejectedOrder> _deletedRejectOrder = new List<RejectedOrder>();
        private void btnReject_Click(object sender, EventArgs e)
        {
            if (!_selectedIndexes.ContainsValue(true))
            {
                MessageBox.Show("Please Select atleast one item");
                return;
            }

            MessageBox.Show(BLService.RejectParticulars(gvRejectItems,
                "colJobOrdersId", "colMaxQuantity", "colQuantity", _selectedIndexes));

            BindRejectItems();
        }
        private void ControlAddLink()
        {
            lnkAddItem.Enabled = (cboProductDescription.Items.Count > 0) &&
                (cboProductItem.Items.Count > 0) && (cboParticularType.Items.Count > 0) && txtQuantity.TextLength > 0&&_selectedIndexes.ContainsValue(true);
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            ControlAddLink();
        }

        private void lnkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtQuantity.Clear();
            ControlAddLink();
        }
        List<OrderTransactionDetail> _orderTransactionDetails = new List<OrderTransactionDetail>();
        private void lnkAddItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkRemoveItems.Enabled = true;
            OrderTransactionDetail orderTransactionDetail = new OrderTransactionDetail();
            orderTransactionDetail.Adjustment = 0;
            orderTransactionDetail.Amount = 0;
            //orderTransactionDetail.DateLastModified = DateTime.Now.ToString("MM/dd/yyyy");
            orderTransactionDetail.IsRejectedOrder = false;
            orderTransactionDetail.UnitPrice = 0;
            orderTransactionDetail.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
            orderTransactionDetail.ParticularTypeId = Convert.ToInt32(
                cboParticularType.SelectedValue);
            orderTransactionDetail.ParticularTypeCode = cboParticularType.Text;
            orderTransactionDetail.ProductListId = Convert.ToInt32(
                cboProductDescription.SelectedValue);
            orderTransactionDetail.ParticularCode = cboProductDescription.Text;   
            orderTransactionDetail.Particulars = cboProductItem.Text;
            if (_rejectOrderTransaction.OrderTransactionDetailList.Count > 0)
                orderTransactionDetail.RecordId = _rejectOrderTransaction.OrderTransactionDetailList[_rejectOrderTransaction.OrderTransactionDetailList.Count - 1].RecordId + 1;
            else
                orderTransactionDetail.RecordId = 1;

            _rejectOrderTransaction.OrderTransactionDetailList.Add(orderTransactionDetail);
            
            orderTransactionDetail = null;

            BindOrderDetails(_rejectOrderTransaction.OrderTransactionDetailList);
            txtQuantity.Clear();
            ControlAddLink();
        }

        //private void BindOrderDetails(List<OrderTransactionDetail> ordertransactiondetails)
        //{
        //    gvOrderTransactionDetail.AutoGenerateColumns = false;
        //    BindingSource bs = UI.BindSource(
        //        ordertransactiondetails, false);
        //    gvOrderTransactionDetail.DataSource = bs;
        //}
            
        private void cboParticularType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboProductDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboProductItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void lnkRemoveItems_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<int> delRecordIds = new List<int>();
            foreach (DataGridViewRow row in gvOrderTransactionDetail.Rows)
            {
                if (row.Cells["colChkDel"].Value != null)
                {
                    if ((bool)row.Cells["colChkDel"].Value)
                    {
                        int recordId=(int)row.Cells["colRecordId"].Value  ;                                            
                            delRecordIds.Add(recordId);
                    
                    }
                    
                }
            }
            if (delRecordIds.Count==0)
            {
                MessageBox.Show("Please Select atleast one item");
                return;
            }

            foreach(long delRecordId in delRecordIds)
            {
                int index=0;
                for(int i=0;i< this._rejectOrderTransaction.OrderTransactionDetailList.Count;i++)
                {
                    if (delRecordId.Equals(this._rejectOrderTransaction.OrderTransactionDetailList[i].RecordId))
                    {
                        index=i;
                        break;
                    }
                }

                this._rejectOrderTransaction.OrderTransactionDetailList.RemoveAt(index);
            }
            BindOrderDetails(this._rejectOrderTransaction.OrderTransactionDetailList);
            

        }

        private void RejectOrderTransaction_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult diag = MessageBox.Show(
            //    "Closing this form without saving will deselect all the selected items for rejection/r/nAre you sure you want to exit",
            //    "Confirmation Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (diag == DialogResult.Yes)
            //{
            //    this.Close();
            //}
        }

        private void gvOrderTransactionDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = gvOrderTransactionDetail.Rows[e.RowIndex];
                switch (gvOrderTransactionDetail.Columns[e.ColumnIndex].Name)
                {
                    case "colChkDel":
                        if ((bool)row.Cells["colChkDel"].EditedFormattedValue)
                        {
                            if (!blJobOrderDetail.AllowRejectOrDelete((long)row.Cells["colId"].Value))
                            {
                                MessageBox.Show("This item is already printed in job order\r\nAttempting to delete is not allowed");
                                row.Cells["colChkDeleted"].Value = false;
                            }
                        }
                        break;
                }
               
                row = null;
            }
        }

        private void gvRejectItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = gvRejectItems.Rows[e.RowIndex];
                switch (gvRejectItems.Columns[e.ColumnIndex].Name)
                {
                    case "colChk":
                        blUtility.ManipulateDictionary<int, bool>(_selectedIndexes, e.RowIndex,
                            Convert.ToBoolean(row.Cells[e.ColumnIndex].EditedFormattedValue));
                      
                        break;
                }
            }
        }

        private void gvRejectItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Exception ex = e.Exception;

            if (ex.GetType() == typeof(System.ArgumentException)
                || ex.GetType() == typeof(System.FormatException))
            {
                MessageBox.Show("Input should be in numbers!", "Invalid Input", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
            }
            else
            {
                e.ThrowException = true;
            }
        }

    







    }
}