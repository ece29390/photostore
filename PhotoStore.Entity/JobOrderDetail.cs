using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class JobOrderDetail:BaseEntity,IEntity
    {
        public override string Lookup
        {
            get { return ""; }
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
                _Id = (long)_EntityDataRow["Id"];
                _orderDetailsId = (long)_EntityDataRow["OrderDetails_Id"];
                _supplierId = (long)_EntityDataRow["Supplier_Id"];
                _jobOrderId = (long)_EntityDataRow["JobOrder_Id"];
                _consumedQuantity = (int)_EntityDataRow["ConsumedQuantity"];
                _isDone = (bool)_EntityDataRow["IsDone"];
            }
        }

        #endregion
        long _orderDetailsId, _supplierId, _jobOrderId;
        int _consumedQuantity;
        public long OrderDetailsId
        {
            get { return _orderDetailsId; }
            set { _orderDetailsId = value; }
        }
        bool _isDone;
        public bool IsDone
        {
            get { return _isDone; }
            set { _isDone = value; }
        }
        public long SupplierId
        {
            get { return _supplierId; }
            set { _supplierId = value; }
        }
        public long JobOrderId
        {
            get { return _jobOrderId; }
            set { _jobOrderId = value; }
        }
        public int ConsumedQuantity
        {
            get { return _consumedQuantity; }
            set { _consumedQuantity = value; }
        }
        OrderTransactionDetail _orderTransactionDetail;
        public OrderTransactionDetail OrderDetail
        {
            get { return _orderTransactionDetail; }
            set { _orderTransactionDetail = value; }
        }



        Supplier _supplier;
        public Supplier Supplier
        {
            get { return _supplier; }
            set { _supplier = value; }
        }
        JobOrder _jobOrder;
        public JobOrder JobOrder
        {
            get { return _jobOrder; }
            set { _jobOrder = value; }
        }
        public JobOrderDetail(DataRow dr)
        {
            EntityDataRow = dr;
        }
    }
}
