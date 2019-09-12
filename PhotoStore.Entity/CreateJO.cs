using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class CreateJO:BaseEntity,IEntity
    {
        public CreateJO()
        {
        }
        public CreateJO(DataRow dr)
        {
            EntityDataRow = dr;
        }
        public override string Lookup
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #region IEntity Members

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
                _Code = _EntityRow["Code"].ToString();
                _Quantity =Convert.ToInt32(_EntityRow["Quantity"]);
                _Particulars = _EntityRow["Particulars"].ToString();
                _orderDetailsId = Convert.ToInt32(_EntityRow["OrderDetailsId"]);
                _Id = Convert.ToInt32(_EntityRow["Id"]);//TransactionId
                if (_EntityRow["JobOrderId"] != DBNull.Value)
                {
                    _jobOrderId = Convert.ToInt32(_EntityRow["JobOrderId"]);
                }

                if (_EntityRow["SupplierId_FK"] != DBNull.Value)
                    _SupplierId_FK = Convert.ToInt32(_EntityRow["SupplierId_FK"]);

                if (_EntityRow["IsDone"] != DBNull.Value)
                    _isDone = Convert.ToBoolean(_EntityRow["IsDone"]);

                _QuantityHidden = Convert.ToInt32(_EntityRow["RemainingQuantity"]);
                _OrderQuantity = Convert.ToInt32(_EntityRow["OrderQuantity"]);
                _ConsumedQuantity = Convert.ToInt32(_EntityRow["ConsumedQuantity"]);
                _JONumber = _EntityRow["JONumber"].ToString();
            }
        }

        #endregion

        #region Properties
        private DateTime _DateCreated;
        public DateTime DateCreated
        {
            get { return _DateCreated; }
        }
        private string _Code = "";
        public string Code
        {
            get { return _Code; }
        }
        private int _Quantity;
        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        private string _Particulars = "";
        public string Particulars
        {
            get { return _Particulars; }
        }
        private int _orderDetailsId;
        public int OrderDetailsId
        {
            get { return _orderDetailsId; }
            //set { _orderDetailsId = value; }
        }
        private int _jobOrderId = -1;
        public int JobOrderId
        {
            get { return _jobOrderId; }
            //set { _jobOrderId = value; }
        }
        private int _SupplierId_FK = -1;
        public int SupplierId_FK
        {
            get { return _SupplierId_FK; }
            set { _SupplierId_FK = value; }
        }
        private bool? _isDone=null;
        public bool? IsDone
        {
            get { return _isDone; }
            set { _isDone = value; }
        }
        private int _QuantityHidden;
        public int QuantityHidden
        {
            get { return _QuantityHidden; }
        }
        private int _OrderQuantity;
        public int OrderQuantity
        {
            get { return _OrderQuantity; }
        }
        private int _ConsumedQuantity;
        public int ConsumedQuantity
        {
            get { return _ConsumedQuantity; }
        }
        private string _JONumber;
        public string JONumber
        {
            get { return _JONumber; }
        }
        #endregion
    }
}
