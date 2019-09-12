using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.BusinessLogic;
using PhotoStore.Entity;
namespace PhotoStore
{
    public partial class Payment : Form
    {

        OrderTransactionPayment _orderTransactionPayment;    
        bool _hasDiscount = false;
        int _employeeGroupId;
        Guid? _recordId ;
        int _selectedIndex;
        List<OrderTransactionPayment> _orderTransactionPayments;
        List<OrderTransactionDetail> _orderTransactionDetails;
        long _orderTransactionId;
        //public object DataSource
        //{
        //    get { return UI.BindSource(_orderTransactionPayments, false); }
        //}

        public Payment(Guid? recordId,
            OrderTransactionPayment payment
            ,bool hasdiscount
            ,int employeeGroupId
            ,List<OrderTransactionPayment> paymentList,
            int selectedIndex,
             List<OrderTransactionDetail> orderTransactionDetails)
        {
            InitializeComponent();
            //if (ordertransactionpaymentid > -1)
            //{
            //    _orderTransactionPayment = blOrderTransactionPayment.retrieve<long>(ordertransactionpaymentid);
            //    btnRemove.Enabled = true;
            //}
            _recordId = recordId;
            _orderTransactionPayment = payment;
            _hasDiscount = hasdiscount;
            _employeeGroupId = employeeGroupId;
            _selectedIndex=selectedIndex;

            _orderTransactionPayments = paymentList;
           // _orderTransactionId = orderTransactionId;
            _orderTransactionDetails = orderTransactionDetails;
        }

       


        private void Payment_Load(object sender, EventArgs e)
        {
            cboPaymentType.DataSource = UI.BindSource(BusinessLogic.blPaymentType.retrieveForComboBox(), false);
            cboPaymentType.DisplayMember = "Description";
            cboPaymentType.ValueMember = "Id";
            txtDatePaid.Text = DateTime.Now.ToString("MM/dd/yyyy");
            if (_orderTransactionPayment!=null)
            {                             
                cboPaymentType.SelectedValue = _orderTransactionPayment.PaymentTypeId;
                txtDatePaid.Text = _orderTransactionPayment.DatePaid.ToString("MM/dd/yyyy");
                txtBankFee.Text = _orderTransactionPayment.BankFee.ToString("#,###.00");
                txtAmountPaid.Text = _orderTransactionPayment.AmountPaid.ToString("#,###.00");
                txtAmountReceived.Text = _orderTransactionPayment.AmountReceived.ToString();
                txtDocumentNumber.Text = _orderTransactionPayment.DocumentNumber;
                if (_orderTransactionPayment.PaymentTypeId == 5)
                {
                    lnkShowGC.Enabled = true;
                    txtDocumentNumber.Enabled = false;
                }
                btnSave.Enabled = true;

                if (_orderTransactionPayment.DatePaid.Date != DateTime.Now.Date)
                {
                    btnSave.Enabled = false;
                    if (_orderTransactionPayment.PaymentTypeId != 5)
                        btnRemove.Enabled = false;
                    else
                        lnkShowGC.Enabled = false;
                }
                if (_orderTransactionPayment.Id > -1)
                {
                    switch (_orderTransactionPayment.PaymentTypeId)
                    {
                        case 3:
                        case 4:
                            cboPaymentType.Enabled = false;
                            txtAmountReceived.Enabled = false;
                            break;
                        case 5:
                            txtAmountReceived.Enabled = false;
                            btnRemove.Enabled = true;
                            break;
                    }

                    
                }
                else
                {
                    btnRemove.Enabled = true;
                }
                if (_orderTransactionPayment.CancelledId > -1)
                {
                    btnSave.Enabled = false;
                    btnRemove.Enabled = false;
                }
                panel1.Enabled = (_orderTransactionPayment.DatePaid.ToShortDateString() == DateTime.Now.ToShortDateString());
            }
           
           
            cboPaymentType.SelectedIndexChanged += new EventHandler(cboPaymentType_SelectedIndexChanged);


           // _hasDiscount = BLService.HasDiscount(_gvOrderTransactionPayment);
        }

        private void SetDenominationGC()
        {
           
                AdminGiftCertificate gc = new AdminGiftCertificate(true,
                    2, 4, 0);
                gc.ShowDialog();
                if (gc.Id != -1)
                {

                    if (blOrderTransactionPayment.DenominationGCExists(gc.Code))
                    {
                        MessageBox.Show("Denomination GC is already selected in the previous item");
                        cboPaymentType.SelectedIndex = 0;
                        return;
                    }
                    txtDocumentNumber.Text = gc.Code;
                    if (gc.DenominationAmount.HasValue)
                    {
                        txtAmountReceived.Text = gc.DenominationAmount.Value.ToString("#,###.00");
                        txtAmountReceived.Enabled = false;

                    }


                }
                gc.Dispose();
                gc = null;



     
        }

        void cboPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlSave(sender, e);
            long paymentTypeId=Convert.ToInt64(cboPaymentType.SelectedValue);
            if (Convert.ToInt64(cboPaymentType.SelectedValue) > -1 && txtAmountReceived.TextLength > 0)
            {
                BLService.ComputeBankFeeFromList(txtAmountPaid, txtBankFee, paymentTypeId,
                    txtAmountReceived, _hasDiscount, _selectedIndex,_orderTransactionPayments);
            }
            txtAmountReceived.Enabled = true;
            txtDocumentNumber.Enabled = true;
            lnkShowGC.Enabled = false;
            //lnkReverseGC.Enabled=false;
            if (paymentTypeId == 5)
            {
                lnkShowGC.Enabled = true;
                txtDocumentNumber.Enabled = false;
                txtAmountReceived.Clear();
                txtAmountReceived.Enabled = false;
                //if(_orderTransactionPayment==null)
                //    lnkReverseGC.Enabled = (_employeeGroupId == 1) ? true : false;
            }
            else
            {
                txtDocumentNumber.Clear();
                txtAmountPaid.Clear();
                txtAmountReceived.Clear();
                txtDocumentNumber.Focus();
            }
            
        }

        private void txtAmountReceived_TextChanged(object sender, EventArgs e)
        {
            ControlSave(sender, e);
            if (Convert.ToInt64(cboPaymentType.SelectedValue) > -1 && txtAmountReceived.TextLength > 0)
                BLService.ComputeBankFeeFromList(txtAmountPaid, txtBankFee, Convert.ToInt64(cboPaymentType.SelectedValue),
                    txtAmountReceived,_hasDiscount, _selectedIndex,_orderTransactionPayments);
            else
            {
                txtAmountPaid.Clear();
                txtBankFee.Clear();
            }
        }

        private void txtDocumentNumber_TextChanged(object sender, EventArgs e)
        {
            ControlSave(sender, e);
        }

        private void cboPaymentType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ControlSave(object sender, EventArgs e)
        {
            btnSave.Enabled = (Convert.ToInt64(cboPaymentType.SelectedValue) > -1)
            && txtDocumentNumber.TextLength > 0 && txtAmountReceived.TextLength > 0;
        }
        private bool ValidateControls()
        {
            double amountReceived;
            if (!double.TryParse(txtAmountReceived.Text.Trim(), out amountReceived))
            {
                MessageBox.Show("Amount Received should be in numeric form");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            long paymentTypeId=Convert.ToInt64(cboPaymentType.SelectedValue);
            double amountReceived=Convert.ToDouble(txtAmountReceived.Text.Trim());
           
            if (_orderTransactionPayment == null)
            {
                _orderTransactionPayment = new OrderTransactionPayment();
                _orderTransactionPayment.OrderTransactionId = _orderTransactionId;
                               
            }
            _orderTransactionPayment.PaymentTypeCode = cboPaymentType.Text;
            _orderTransactionPayment.PaymentTypeId = paymentTypeId;
            _orderTransactionPayment.DocumentNumber = txtDocumentNumber.Text.Trim();
            _orderTransactionPayment.BankFee = Convert.ToDouble(txtBankFee.Text.Trim());
            _orderTransactionPayment.AmountPaid = Convert.ToDouble(txtAmountPaid.Text.Trim());
            _orderTransactionPayment.AmountReceived =amountReceived ;

            if (_orderTransactionPayment.PaymentTypeId == 3 ||
                _orderTransactionPayment.PaymentTypeId == 4)
            {
                DialogResult diagResult = MessageBox.Show("Did you already swipe the atm/credit card of the customer?",
                    "READ THIS FIRST!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (diagResult == DialogResult.No)
                {
                    MessageBox.Show("Please swipe the ATM/Credit card of the customer\r\nbefore saving the payment transaction");
                    return;
                }
            }

            if (!blOrderTransactionPayment.CheckIfGCExistonQueuedPayment(_orderTransactionPayments,
                txtDocumentNumber.Text.Trim()))
            {
                if (!_recordId.HasValue)
                    _orderTransactionPayments.Add(_orderTransactionPayment);
            }


            this.Close();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult diagResult = MessageBox.Show("Are you sure you want to cancel or remove the selected payment",
                "Confirmation Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (diagResult == DialogResult.No)
                return;
            _orderTransactionPayments.RemoveAt(_selectedIndex);
            //blOrderTransactionPayment.delete(_orderTransactionPayment.Id);
            blOrderTransactionPayment.RecomputePayment(_orderTransactionPayments, _orderTransactionDetails);
            this.Close();
        }

        private void txtAmountReceived_KeyPress(object sender, KeyPressEventArgs e)
        {
            BLService.KeyPressNumeric(txtAmountReceived, e);
        }

        private void lnkShowGC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetDenominationGC();
        }

       

   }
}