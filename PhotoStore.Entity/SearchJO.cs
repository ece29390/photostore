using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace PhotoStore.Entity
{
    public class SearchJO:BaseEntity, IEntity
    {
        public SearchJO(DataRow dr)
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
                _DateCreated = Convert.ToDateTime(_EntityRow["OT_DateCreated"]);
                this._OrderNumber = _EntityRow["OT_Code"].ToString();
                this._MothersName = _EntityRow["C_MothersName"].ToString();
                _Quantity = Convert.ToInt32(_EntityRow["OTD_Quantity"]);
                _Particulars = _EntityRow["OTD_Particulars"].ToString();
                this._JobOrderNumber = _EntityRow["JO_Code"].ToString();
                if(_EntityRow["JobOrderId"]!=DBNull.Value)
                 _jobOrderId = Convert.ToInt64(_EntityRow["JobOrderId"]);

            }
        }

        #endregion

        #region Properties
        private DateTime _DateCreated;
        public DateTime DateCreated
        {
            get { return _DateCreated; }
        }
        private string _OrderNumber;
        public string OrderNumber
        {
            get { return _OrderNumber; }
        }
        private string _MothersName = "";
        public string MothersName
        {
            get { return _MothersName; }
        }
        private int _Quantity;
        public int Quantity
        {
            get { return _Quantity; }
        }
      
        private string _Particulars;
        public string Particulars
        {
            get { return _Particulars; }
            //set { _orderDetailsId = value; }
        }
     
        private string _JobOrderNumber = null;
        public string JobOrderNumber
        {
            get { return _JobOrderNumber; }

        }
        private long _jobOrderId;
        public long JobOrderId
        {
            get { return _jobOrderId; }
        }
        #endregion
        public override string Lookup
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
    }
}
