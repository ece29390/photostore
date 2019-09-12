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
    public partial class CancelPayment : CancelBaseForm//Form
    {
        //private long _employeeGroupId;
     
        OrderTransactionPayment _orderTransactionPayment;
        List<OrderTransactionPayment> _paymentList;
        double _amountBalance;
        long _orderTransactionId;
        int _index;
        public CancelPayment(long orderPaymentId,long orderTransactionId,List<OrderTransactionPayment> paymentList,
            int index)
        {
            InitializeComponent();
            
            _orderTransactionId = orderTransactionId;
            _orderTransactionPayment = blOrderTransactionPayment.retrieve<long>(orderPaymentId);
            _paymentList = paymentList;
            _index = index;
        }
        
        

        private void CancelPayment_Load(object sender, EventArgs e)
        {
            PopulateValues();
            blOrderTransactionPayment.GetProperMode(rdo,this.rdoCash,_orderTransactionPayment);
            blOrderTransactionPayment.GetCorrectModeOfPaymentAndRemarks(
                txtModeOfPayment, lblRemarks, _orderTransactionPayment,rdo);
            
            if (_orderTransactionPayment.CancelledId != -1)
            {
                btnRemoved.Enabled = true;
            }
            if (_orderTransactionPayment.PaymentTypeId == 3 ||
                _orderTransactionPayment.PaymentTypeId == 4)
            {
                txtAmountCancel.ReadOnly = true;
            }
        }
        private void PopulateValues()
        {
            double amount = _orderTransactionPayment.AmountReceived < 0 ?
                _orderTransactionPayment.AmountReceived * -1 :
                _orderTransactionPayment.AmountReceived;
            txtAmount.Text = amount.ToString();
                txtDatePaid.Text = _orderTransactionPayment.DatePaid.ToString();//Convert.ToDateTime(_row.Cells["colDatePaid"].Value).ToString();
                txtDocumentNumber.Text = _orderTransactionPayment.DocumentNumber; //_row.Cells["colDocumentNumber"].Value.ToString();
                double amountPaid = _orderTransactionPayment.AmountPaid < 0 ?
                    _orderTransactionPayment.AmountPaid * -1 :
                    _orderTransactionPayment.AmountPaid;
                txtAmountPaid.Text = amountPaid.ToString();
                txtBankFee.Text = _orderTransactionPayment.BankFee.ToString();//Convert.ToDouble(_row.Cells["colBankFee"].Value).ToString();
                double amountReceived = _orderTransactionPayment.AmountReceived < 0 ?
                    _orderTransactionPayment.AmountReceived * -1 :
                    _orderTransactionPayment.AmountReceived;
                if (_orderTransactionPayment.CancelledId == -1)
                    this._amountBalance = amountReceived - blOrderTransactionPayment.GetTotalCancelledAmount(
                        _orderTransactionPayment.Id
                        ,_paymentList);
                else
                {
                    this._amountBalance =blOrderTransactionPayment.GetAmountReceived(
                        _orderTransactionPayment.CancelledId,_paymentList)-
                        blOrderTransactionPayment.GetTotalCancelledAmount(
                        _orderTransactionPayment.Id
                        ,_paymentList);
                }
                if (this._amountBalance < 0)
                    this._amountBalance = this._amountBalance * -1;
                txtAmountCancel.Text = this._amountBalance.ToString();
                if (_orderTransactionPayment.PaymentTypeId == 2||
                    _orderTransactionPayment.PaymentTypeId==3||
                    _orderTransactionPayment.PaymentTypeId==4)
                {
                    rdoCash.Visible = true;
                    rdo.Visible = true;
                    rdo.Checked = true;
                }
            
        }
      
        private void btnOk_Click(object sender, EventArgs e)
        {

            blOrderTransactionPayment.SaveCancelledPayment(
                _orderTransactionPayment, txtModeOfPayment.Text, txtAmountCancel.Text.Trim(),_orderTransactionId,
                _amountBalance,_paymentList,_index);
            this.Close();
        }

        private void txtAmountCancel_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = (txtAmountCancel.TextLength > 0) ? true : false;
        }

        private void txtAmountCancel_KeyPress(object sender, KeyPressEventArgs e)
        {
            BLService.KeyPressNumeric(txtAmountCancel,e);
        }

        private void btnRemoved_Click(object sender, EventArgs e)
        {
           
            if (_orderTransactionPayment.PaymentTypeId == 5)
            {
                blGiftCertificate.UpdateGCAfterCancelledOrRemoved(txtDocumentNumber.Text, 1);
            }
            blOrderTransactionPayment.delete(_orderTransactionPayment);
            this.Close();
        }

        private void rdoCheck_CheckedChanged(object sender, EventArgs e)
        {
            blOrderTransactionPayment.RadioButton_CheckedChanged(rdo, e, txtModeOfPayment);
        }

        private void rdoCash_CheckedChanged(object sender, EventArgs e)
        {
            blOrderTransactionPayment.RadioButton_CheckedChanged(rdoCash, e, txtModeOfPayment);
        }

     
    }
}