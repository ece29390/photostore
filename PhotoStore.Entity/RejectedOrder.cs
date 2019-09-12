using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class RejectedOrder :BaseEntity,IEntity
    {
        long _orderDetailsId, _particularTypeId, _productListId;//,_jobOrderDetailId;
        long _orderPackageDetailsId;
        int _quantity, _maxQuantity;
        decimal _amount = 0;
        bool _isPackage = false;
        string _particularTypeCode, _particular,_particularCode;
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
                _orderDetailsId = (long)_EntityDataRow["OrderDetailsId"];
                _particularTypeId = (long)_EntityDataRow["ParticularTypeId"];
                _productListId = (long)_EntityDataRow["ProductListId"];
                _quantity = (int)_EntityDataRow["RejectedQuantity"];
                _maxQuantity = (int)_EntityDataRow["Quantity"];
                _particularTypeCode = _EntityDataRow["ParticularTypeCode"].ToString();
                _particular = _EntityDataRow["Particulars"].ToString();
                _particularCode = _EntityDataRow["ParticularCode"].ToString();
                _isPackage = Convert.ToBoolean(_EntityDataRow["IsPackage"]);
                _orderPackageDetailsId = Convert.ToInt64(_EntityDataRow["OrderPackageDetailsId"]);
               // _jobOrderDetailId = Convert.ToInt64(_EntityDataRow["JobOrderDetailId"]);
            }
        }

        #endregion

        public RejectedOrder(DataRow dr)
        {
            EntityDataRow = dr;
        }
        //public long JobOrderDetailsId
        //{
        //    get { return _jobOrderDetailId; }
        //    set { _jobOrderDetailId = value; }
        //}
        public bool IsPackage
        {
            get { return _isPackage; }
            set { _isPackage = value; }
        }
        public long OrderDetailsId
        {
            get { return _orderDetailsId; }
            set { _orderDetailsId = value; }
        }
        public decimal Amount
        {
            get { return _amount; }
        }
        public long ParticularTypeId
        {
            get { return _particularTypeId; }
            set { _particularTypeId = value; }
        }
        public long ProductListId
        {
            get { return _productListId; }
            set { _productListId = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string ParticularCode
        {
            get { return _particularCode; }
            set { _particularCode = value; }
        }
        public int MaximumQuantity
        {
            get { return _maxQuantity; }
            set { _maxQuantity = value; }
        }
        public string ParticularTypeCode
        {
            get { return _particularTypeCode; }
            set { _particularTypeCode = value; }
        }
        public string Particular
        {
            get { return _particular; }
            set { _particular = value; }
        }
        public long OrderPackageDetailsId
        {
            get { return _orderPackageDetailsId; }
            set { _orderPackageDetailsId = value; }
        }
        public override string Lookup
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
    }
}
