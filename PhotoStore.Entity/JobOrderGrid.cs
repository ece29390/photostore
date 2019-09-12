using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class JobOrderGrid:BaseEntity,IEntity
    {
        public JobOrderGrid(DataRow dr)
        {
            EntityDataRow = dr;
        }
        public override string Lookup
        {
            get { return _orderNumber; }
        }

        #region IEntity Members

        private DataRow _entityDataRow;
        public DataRow EntityDataRow
        {
            get
            {
                return _entityDataRow;//throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                _entityDataRow = value;
                _dateCreated = Convert.ToDateTime(_entityDataRow["DATECREATED"]);
                //_code = _entityDataRow["CODE"].ToString();
                _orderQuantity = Convert.ToInt32(_entityDataRow["ORDERQUANTITY"]);
                _particulars = _entityDataRow["PARTICULARS"].ToString();
                _supplierId = Convert.ToInt64(_entityDataRow["SUPPLIERID"]);
                _orderNumber = _entityDataRow["ORDERNUMBER"].ToString();
                _jobDetailsId = Convert.ToInt64(_entityDataRow["JOBORDERDETAILSID"]);
                _jobOrderId = Convert.ToInt64(_entityDataRow["ID"]);
                _orderDetailsId = Convert.ToInt64(_entityDataRow["ORDERDETAILSID"]);
                _supplierCode = _entityDataRow["SUPPLIERCODE"].ToString();
                if(_entityDataRow["OrderPackageDetailsId"]!=DBNull.Value)
                _OrderPackageDetailsId = Convert.ToInt64(_entityDataRow["OrderPackageDetailsId"]);

            _customerName = _entityDataRow["CUSTOMERNAME"].ToString();
            }
        }
        string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        private DateTime _dateCreated;
        public DateTime DateCreated
        {
            get { return _dateCreated; }
        }
        long _orderDetailsId;
        public long OrderDetailsId
        {
            get { return _orderDetailsId; }
        }
        long _OrderPackageDetailsId;
        public long OrderPackageDetailsId
        {
            get { return _OrderPackageDetailsId; }
            set { _OrderPackageDetailsId = value; }
        }
        private int _orderQuantity;
        public int OrderQuantity
        {
            get { return _orderQuantity; }
            set { _orderQuantity = value; }
        }
        string _supplierCode;
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }
        string _particulars;
        public string Particulars
        {
            get { return _particulars; }
        }
        private long _supplierId=-1;
        public long SupplierId_FK
        {
            get { return _supplierId; }
            set { _supplierId = value; }
        }
        Supplier _supplier;
        public Supplier Supplier
        {
            get { return _supplier; }
            set { _supplier = value; }
        }
        string _orderNumber;
        public string OrderNumber
        {
            get { return _orderNumber; }
        }
        long _jobDetailsId;
        public long JobDetailsId
        {
            get { return _jobDetailsId; }
        }
        long _jobOrderId;
        public long JobOrderId
        {
            get { return _jobOrderId; }
        }
        #endregion
    }
}
