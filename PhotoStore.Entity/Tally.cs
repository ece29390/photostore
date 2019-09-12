using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class Tally:BaseEntity
    {
        DataRow _entityDataRow;
        public override string Lookup
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
        public DataRow EntityDataRow
        {
            get { return _entityDataRow; }
            set { _entityDataRow = value;
            _code = _entityDataRow["Code"].ToString();
            _particulars = _entityDataRow["Particulars"].ToString();
            _qty = Convert.ToInt32(_entityDataRow["Qty"]);
            _supplierCode = _entityDataRow["SupplierCode"].ToString();
            }
        }
        public Tally(DataRow dr)
        {
            EntityDataRow = dr;
        }
        string _code, _supplierCode, _particulars;
        int _qty;
        public string Code
        {
            get { return _code; }
        }
        public string SupplierCode
        {
            get { return _supplierCode; }
        }
        public string Particulars
        {
            get { return _particulars; }
        }
        public int Qty
        {
            get { return _qty; }
        }

    }
}
