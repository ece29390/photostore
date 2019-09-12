using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PhotoStore.Entity
{
    public class RejectedReport:BaseEntity,IEntity
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
                return _entityDataRow ;
            }
            set
            {
                _entityDataRow=value;
                _dateCreated = Convert.ToDateTime(_entityDataRow["DateCreated"]).ToString("MM/dd/yyyy");
                _code = _entityDataRow["RejectedCode"].ToString();
                _particularTypeCode = _entityDataRow["ParticularTypeCode"].ToString();
                _item = _entityDataRow["Item"].ToString();
                _quantity = Convert.ToInt32(_entityDataRow["Quantity"]);
                _derivedCode = _entityDataRow["DERIVEDCODE"].ToString();
                _mothersName = _entityDataRow["MOTHERSNAME"].ToString();
            }
        }

        #endregion
        public RejectedReport(DataRow dr)
        {
            EntityDataRow = dr;
        }
        string _dateCreated,_code,_particularTypeCode,_item,_derivedCode,_mothersName;
        public string DerivedCode
        {
            get { return _derivedCode; }
            set { _derivedCode = value; }
        }
        public string MothersName
        {
            get { return _mothersName; }
            set { _mothersName = value; }
        }
        int _quantity;
        public string DateCreated
        {
            get { return _dateCreated; }
        }
        public string RejectedCode
        {
            get { return _code; }
        }
        public string ParticularTypeCode
        {
            get { return _particularTypeCode; }
        }
        public string Item
        {
            get { return _item; }
        }
        public int Quantity
        {
            get { return _quantity; }
        }
    }
}
