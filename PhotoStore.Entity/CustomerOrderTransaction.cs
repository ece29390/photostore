using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class CustomerOrderTransaction:BaseEntity
    {
        
        public CustomerOrderTransaction(DataRow dr)
        {
            EntityDataRow = dr;
        }

        #region IEntity Members
        long _orderTransactionId;
        private DataRow _EntityRow;
        public DataRow EntityDataRow
        {
            get
            {
                return _EntityRow;
            }
            set
            {
                _EntityRow = value;
                _DateCreated = Convert.ToDateTime(_EntityRow["DateCreated"]);
                _OrderNumber = _EntityRow["Code"].ToString();                                
                _Particulars = _EntityRow["Particulars"].ToString();
                _Amount = Convert.ToDecimal(_EntityRow["Amount"]);
                base._Id = Convert.ToInt32(_EntityRow["CustomerId"]);
                _orderTransactionId = Convert.ToInt64(_EntityRow["OrderTransactionId"]);
            }
        }

        #endregion

        #region Properties
        private DateTime _DateCreated;
        public DateTime DateCreated
        {
            get { return _DateCreated; }
        }
        
        private string _OrderNumber = "";
        public string OrderNumber
        {
            get { return _OrderNumber; }
        }
        
        private string _Particulars;
        public string Particulars
        {
            get { return _Particulars; }
            set { _Particulars = value; }
            //set { _orderDetailsId = value; }
        }
        public long OrderTransactionId
        {
            get { return _orderTransactionId; }
        }

        private decimal _Amount;
        public decimal Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        #endregion

        public override string Lookup
        {
            get { return ""; }
        }
    }
}
