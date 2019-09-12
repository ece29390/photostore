using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace PhotoStore.Entity
{
    public class ActualJO:BaseEntity
    {
        public ActualJO(DataRow dr)
        {
            EntityDataRow = dr;
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
                this._JobOrderNumber = _EntityRow["Code"].ToString();
                this._OrderNumber = _EntityRow["OrderNumber"].ToString();
                _Quantity = Convert.ToInt32(_EntityRow["Quantity"]);
                _Particulars = _EntityRow["Particulars"].ToString();
                this._OrderDetailsId = Convert.ToInt32(_EntityRow["OrderDetailsId"]);
                if (_EntityRow["JobOrderId"] != DBNull.Value)
                {
                    this._JobOrderId = Convert.ToInt32(_EntityRow["JobOrderId"]);
                }

                if (_EntityRow["SupplierId_FK"] != DBNull.Value)
                    _SupplierId_FK = Convert.ToInt32(_EntityRow["SupplierId_FK"]);

                _SupplierDescription = _EntityRow["SupplierDescription"].ToString();

                if (_EntityRow["JODate"] != DBNull.Value)
                    _JODate = Convert.ToDateTime(_EntityRow["JODate"]);

            }
        }

        #endregion

        #region Properties
        private DateTime _DateCreated;
        public DateTime DateCreated
        {
            get { return _DateCreated; }
        }
        private DateTime _JODate;
        public DateTime JODate
        {
            get { return _JODate; }
        }
        private string _JobOrderNumber = "";
        public string JobOrderNumber
        {
            get { return _JobOrderNumber; }
        }
        private int _Quantity;
        public int Quantity
        {
            get { return _Quantity; }           
        }
        private string _OrderNumber = "";
        public string OrderNumber
        {
            get { return _OrderNumber; }
        }
        private string  _Particulars;
        public string Particulars
        {
            get { return _Particulars; }
            //set { _orderDetailsId = value; }
        }
        private int _OrderDetailsId = -1;
        public int OrderDetailsId
        {
            get { return _OrderDetailsId; }
            //set { _jobOrderId = value; }
        }
        private int _JobOrderId = -1;
        public int JobOrderId
        {
            get { return _JobOrderId; }
         
        }
        private int _SupplierId_FK = -1;
        public int SupplierId_FK
        {
            get { return _SupplierId_FK; }
        }

        private string _SupplierDescription = null;
        public string SupplierDescription
        {
            get { return _SupplierDescription; }
         
        }

        #endregion

        public override string Lookup
        {
            get { return ""; }
        }
    }
}
