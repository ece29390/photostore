using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class GiftCertificateReport:BaseEntity,IEntity
    {
        DataRow _entityDataRow;
        public override string Lookup
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #region IEntity Members


        public DataRow EntityDataRow
        {
            get
            {
                return _entityDataRow;
            }
            set
            {
                _entityDataRow=value;
                //_code = _entityDataRow["Code"].ToString();
                _gcType = _entityDataRow["PARTICULARTYPECODE"].ToString();
                //_status = _entityDataRow["Status"].ToString();
                _dateCreated = Convert.ToDateTime(_entityDataRow["DATECREATED"]).ToString("MM/dd/yyyy");
                _quantity = Convert.ToInt32(_entityDataRow["QUANTITY"]);

            }
        }

        #endregion
        public GiftCertificateReport(DataRow dr)
        {
            EntityDataRow = dr;
        }
        string _code, _gcType, _status,_dateCreated;
        int _quantity;
        public int Quantity
        {
            get { return _quantity; }
        }

        public string Code
        {
            get { return _code; }
        }
        public string GCType
        {
            get { return _gcType; }
        }
        public string Status
        {
            get { return _status; }
        }
        public string DateCreated
        {
            get { return _dateCreated; }
        }

    }
}
