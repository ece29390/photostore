using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace PhotoStore.BusinessLogic
{
    public class CancelBaseForm:Form
    {
        protected double _amountReceived;
        protected long _paymentTypeId,_orderTransactionId;
        protected bool _allowPayment;
        public double AmountReceived
        {
            get { return _amountReceived; }
        }
        public long PaymentTypeId
        {
            get { return _paymentTypeId; }
        }
        public bool AllowPayment
        {
            get { return _allowPayment; }
        }
    }
}
