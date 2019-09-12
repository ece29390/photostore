using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class JobOrders:BaseEntity,IEntity
    {
        string _particulars, _supplierCode, _customerCode;
        long _orderDetailsId, _jobOrderId;
        int _consumedQuantity, _quantity, _rejectedQuantity;
        OrderTransactionDetail _orderTransactionDetails = new OrderTransactionDetail();
        JobOrder _jobOrders = new JobOrder();
        bool  _isDone;
        public override string Lookup
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #region IEntity Members

        DataRow _EntityDataRow;
        public DataRow EntityDataRow
        {
            get
            {
                return _EntityDataRow;
            }
            set
            {
                _EntityDataRow = value;
                _Id = Convert.ToInt64(_EntityDataRow["Id"]);
                _orderDetailsId = Convert.ToInt64(_EntityDataRow["OrderDetailsId"]);
                if (_EntityDataRow["JobOrderId"] != DBNull.Value)
                    _jobOrderId = Convert.ToInt64(_EntityDataRow["JobOrderId"]);

                _customerCode = _EntityDataRow["CustomerName"].ToString();
                _particulars = _EntityDataRow["Particulars"].ToString();
                _consumedQuantity = Convert.ToInt32(_EntityDataRow["ConsumedQuantity"]);
                _quantity = Convert.ToInt32(_EntityDataRow["Quantity"]);
                _rejectedQuantity = Convert.ToInt32(_EntityDataRow["RejectedQuantity"]);
               // _isSave = Convert.ToBoolean(_EntityDataRow["IsSave"]);
                _isDone = Convert.ToBoolean(_EntityDataRow["IsDone"]);
                if (_EntityDataRow["SupplierCode"] != DBNull.Value)
                {
                    _supplierCode = _EntityDataRow["SupplierCode"].ToString();
                }
                else
                {
                    _supplierCode = "Please Select a Supplier";
                }
                
            }
        }

        #endregion
        public JobOrders(DataRow dr)
        {
            EntityDataRow = dr;
        }

        public long OrderDetailsId
        {
            get { return _orderDetailsId; }
            set { _orderDetailsId = value; }
        }
        public long JobOrderId
        {
            get { return _jobOrderId; }
            set { _jobOrderId = value; }
        }
        public string Particulars
        {
            get { return _particulars; }
            set { _particulars = value; }
        }
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }
        public string CustomerName
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public int ConsumedQuantity
        {
            get { return _consumedQuantity; }
            set { _consumedQuantity = value; }
        }
        public int RejectedQuantity
        {
            get { return _rejectedQuantity; }
            set { _rejectedQuantity = value; }
        }
        public OrderTransactionDetail OrderTransactionDetailEntity
        {
            get { return _orderTransactionDetails; }
            set { _orderTransactionDetails = value; }
        }

        public JobOrder JobOrderEntity
        {
            get { return _jobOrders; }
            set { _jobOrders = value; }
        }
       
        public bool IsDone
        {
            get { return _isDone; }
            set { _isDone = value; }
        }
    }
}
