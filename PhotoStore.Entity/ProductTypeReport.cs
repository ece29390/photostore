using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class ProductTypeReport:BaseEntity,IEntity
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
                _dateCreated = Convert.ToDateTime(_entityDataRow["DateCreated"]).ToString("MM/dd/yyyy");
               // _code = _entityDataRow["Code"].ToString();
                _productName = _entityDataRow["ProductName"].ToString();
                _quantity = Convert.ToInt32(_entityDataRow["PurchaseQuantity"]);
            }
        }

        #endregion

        public ProductTypeReport(DataRow dr)
        {
            EntityDataRow = dr;
        }
        string _dateCreated, _code, _productName;
        int _quantity;
        public string DateCreated
        {
            get { return _dateCreated; }
        }
        public string Code
        {
            get { return _code; }
        }
        public string ProductName
        {
            get { return _productName; }
        }
        public int Quantity
        {
            get { return _quantity; }
        }
    }
}
