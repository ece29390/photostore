using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class RejectedPackage:BaseEntity,IEntity
    {
        public override string Lookup
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #region IEntity Members

        DataRow _entityDataRow;
        public DataRow EntityDataRow
        {
            get
            {
                return _entityDataRow;
            }
            set
            {
                _entityDataRow = value;
                _jobId = (long)_entityDataRow["Id"];
                _consumedQuantity = (int)_entityDataRow["ConsumedQuantity"];
                _customerName = _entityDataRow["CustomerName"].ToString();
                _dateCreated = (DateTime)_entityDataRow["DateCreated"];
                _jobDetailId = (long)_entityDataRow["JOBORDERDETAILSID"];
                _jobOrderNumber = _entityDataRow["JobOrderNumber"].ToString();
                _orderDetailsId = (long)_entityDataRow["OrderDetailsId"];
                if(_entityDataRow["OrderPackageDetailsId"] !=DBNull.Value)
                    _orderPackageDetailsId = (long)_entityDataRow["OrderPackageDetailsId"];
                _customerName = _entityDataRow["CustomerName"].ToString();
                _particulars = _entityDataRow["Particulars"].ToString();

            }
        }

        #endregion

        #region Properties

        #endregion
        int _rejectedQuantity;
        public int RejectedQuantity
        {
            get { return _rejectedQuantity; }
        }
        bool _isRejectedOrder;
        public bool IsRejectedOrder
        {
            get { return _isRejectedOrder; }
            set { _isRejectedOrder = value; }
        }
        long _jobId;
        public long JobId
        {
            get { return _jobId; }
            set { _jobId = value; }
        }
        long _jobDetailId;
        public long JobDetailId
        {
            get { return _jobDetailId; }
            set { _jobDetailId = value; }
        }
        DateTime _dateCreated;
        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set { _dateCreated = value; }
        }
        int _consumedQuantity;
        public int ConsumedQuantity
        {
            get { return _consumedQuantity; }
            set { _consumedQuantity = value; }
        }
        string _particulars="";
        public string Particulars
        {
            get { return _particulars; }
            set { _particulars = value; }
        }
        string _jobOrderNumber;
        public string JobOrderNumber
        {
            get { return _jobOrderNumber; }
            set { _jobOrderNumber = value; }
        }
        long _orderDetailsId;
        public long OrderDetailsId
        {
            get { return _orderDetailsId; }
            set { _orderDetailsId = value; }
        }
        long _orderPackageDetailsId;
        public long OrderPackageDetailsId
        {
            get { return _orderPackageDetailsId; }
            set { _orderPackageDetailsId = value; }
        }
        string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }


            
        #region 
        public RejectedPackage(DataRow dr)
        {
            EntityDataRow = dr;
        }
        #endregion
    }
}
