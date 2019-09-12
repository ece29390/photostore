using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace PhotoStore.Entity
{
    public class OrderTransactionPayment : BaseEntity, IEntity
    {
        long _cancelledId = -1;
        public OrderTransactionPayment()
        {

        }

        public OrderTransactionPayment(DataRow dr)
        {
            EntityDataRow = dr;
        }

        #region BaseEntity Overrides
        public override string Lookup
        {
            get { return _Id + "-" + _DatePaid; }
        }
        #endregion

        #region IEntity Implementations
        private DataRow _EntityDataRow;
        public DataRow EntityDataRow
        {
            get { return _EntityDataRow; }
            set
            {
                _EntityDataRow = value;
                if (_EntityDataRow != null)
                {
                    _Id = Convert.ToInt32(_EntityDataRow["Id"]);
                    _OrderTransactionId = Convert.ToInt32(_EntityDataRow["OrderTransactionId"]);
                    _DatePaid = Convert.ToDateTime(_EntityDataRow["DatePaid"]);
                    _PaymentTypeCode = Convert.ToString(_EntityDataRow["PaymentTypeCode"]);
                    _DocumentNumber = Convert.ToString(_EntityDataRow["DocumentNumber"]);
                    _AmountPaid = Convert.ToDouble(_EntityDataRow["AmountPaid"]);
                    _BankFee = Convert.ToDouble(_EntityDataRow["BankFee"]);
                    _AmountReceived = Convert.ToDouble(_EntityDataRow["AmountReceived"]);
                    _DateLastModified = (DateTime)_EntityDataRow["DateLastModified"];
                    _paymentTypeId = (long)_EntityDataRow["PaymentTypeId"];
                    if (_EntityDataRow["CancelledId"] != DBNull.Value)
                        _cancelledId = Convert.ToInt64(_EntityDataRow["CancelledId"]);
                }
            }
        }
        #endregion

        #region Entity Properties
        private long _OrderTransactionId = -1;
        public long OrderTransactionId
        {
            get { return _OrderTransactionId; }
            set { _OrderTransactionId = value; }
        }
        private DateTime _DatePaid = DateTime.Now;
        public DateTime DatePaid
        {
            get { return _DatePaid; }
            set { _DatePaid = value; }
        }
        private string _PaymentTypeCode = "";
        public string PaymentTypeCode
        {
            get { return _PaymentTypeCode; }
            set { _PaymentTypeCode = value; }
        }
        private string _DocumentNumber = "";
        public string DocumentNumber
        {
            get { return _DocumentNumber; }
            set { _DocumentNumber = value; }
        }
        public long CancelledId
        {
            get { return _cancelledId; }
            set { _cancelledId = value; }
        }
        public string CancelDescription
        {
            get { return "Refund"; }
        }
        private double _AmountPaid = 0;
        public double AmountPaid
        {
            get { return _AmountPaid; }
            set { _AmountPaid = value; }
        }
        private double _BankFee = 0;
        public double BankFee
        {
            get { return _BankFee; }
            set { _BankFee = value; }
        }
        private double _AmountReceived = 0;
        public double AmountReceived
        {
            get { return _AmountReceived; }
            set { _AmountReceived = value; }
        }

        private DateTime _DateLastModified;
        public DateTime DateLastModified
        {
            get { return _DateLastModified; }
            //set { _DateLastModified = value; }
        }
        long _paymentTypeId = -1;
        public long PaymentTypeId
        {
            get { return _paymentTypeId; }
            set { _paymentTypeId = value; }
        }
        #endregion


        #region Extended Entities
        private OrderTransaction _OrderTransactionEntity = null;
        public OrderTransaction OrderTransactionEntity
        {
            get { return _OrderTransactionEntity; }
            set
            {
                _OrderTransactionEntity = value;
                _OrderTransactionId = _OrderTransactionEntity.Id;
            }
        }

        #endregion
        #region Display Properties
        public string RemoveDescription
        {
            get { return "Remove Payment"; }
        }
        Guid _recordGuidId = Guid.NewGuid();
        public Guid RecordGuidId
        {
            get { return _recordGuidId; }
        }
           #endregion
    }
}
