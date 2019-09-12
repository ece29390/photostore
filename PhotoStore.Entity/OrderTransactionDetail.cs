using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace PhotoStore.Entity
{
    public class OrderTransactionDetail : BaseEntity, IEntity
    {
        public OrderTransactionDetail()
        {

        }

        public OrderTransactionDetail(DataRow dr)
        {
            EntityDataRow = dr;
        }

        #region BaseEntity Overrides
        public override string Lookup
        {
            get { return _Id + "-" + _Quantity; }
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

                _Id = Convert.ToInt32(_EntityDataRow["Id"]);
                _OrderTransactionId = Convert.ToInt32(_EntityDataRow["OrderTransactionId"]);
                _Quantity = Convert.ToInt32(_EntityDataRow["Quantity"]);
                _ParticularTypeCode = Convert.ToString(_EntityDataRow["ParticularTypeCode"]);
                _particularTypeId = Convert.ToInt32(_EntityDataRow["ParticularTypeId"]);
                _ParticularCode = Convert.ToString(_EntityDataRow["ParticularCode"]);
                _Particulars = Convert.ToString(_EntityDataRow["Particulars"]);
                _UnitPrice = Convert.ToDouble(_EntityDataRow["UnitPrice"]);
                _Adjustment = Convert.ToDouble(_EntityDataRow["Adjustment"]);
                _Amount = Convert.ToDouble(_EntityDataRow["Amount"]);
                _productListId = Convert.ToInt64(_EntityDataRow["ProductListId"]);
                _IsRejectedOrder = Convert.ToBoolean(_EntityDataRow["IsRejectedOrder"]);
                _DateLastModified = (DateTime)_EntityDataRow["DateLastModified"];


            }
        }
        #endregion

        #region Entity Properties
        int _recordId;
        public int RecordId
        {
            get { return _recordId; }
            set { _recordId = value; }
        }
        private long _OrderTransactionId = -1;
        public long OrderTransactionId
        {
            get { return _OrderTransactionId; }
            set { _OrderTransactionId = value; }
        }
        long _particularTypeId = -1;
        public long ParticularTypeId
        {
            get { return _particularTypeId; }
            set { _particularTypeId = value; }
        }
        long _productListId = -1;
        public long ProductListId
        {
            get { return _productListId; }
            set { _productListId = value; }
        }
        long _particularCodeId = -1;
        public long ParticularCodeId
        {
            get { return _particularCodeId; }
            set { _particularCodeId = value; }
        }
        private int _Quantity = 1;
        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        private string _ParticularTypeCode = "";
        public string ParticularTypeCode
        {
            get { return _ParticularTypeCode; }
            set { _ParticularTypeCode = value; }
        }
        private string _ParticularCode = "";
        public string ParticularCode
        {
            get { return _ParticularCode; }
            set { _ParticularCode = value; }
        }

        private string _Particulars = "";
        public string Particulars
        {
            get { return _Particulars; }
            set { _Particulars = value; }
        }
        
        private double _UnitPrice = 0;
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        private double _Adjustment = 0;
        public double Adjustment
        {
            get { return _Adjustment; }
            set { _Adjustment = value; }
        }
        private double _Amount = 0;
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        private Boolean _IsRejectedOrder = false;
        public Boolean IsRejectedOrder
        {
            get { return _IsRejectedOrder; }
            set { _IsRejectedOrder = value; }
        }

        private DateTime _DateLastModified;
        public DateTime DateLastModified
        {
            get { return _DateLastModified; }
            //set { _DateLastModified = value; }
        }
        bool _markAsDeleted = false;
        public bool MarkAsDeleted
        {
            get { return _markAsDeleted; }
            set { _markAsDeleted = value; }
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
        //ProductList _productList = new ProductList();
        //public ProductList ProductListEntity
        //{
        //    get { return _productList; }
        //    set { _productList = value; }
        //}
        #endregion

    }
}
