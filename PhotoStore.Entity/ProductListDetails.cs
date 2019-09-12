using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class ProductListDetails:BaseEntity,IEntity
    {
        public override string Lookup
        {
            get { return ""; }
        }

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
                _EntityDataRow=value;
                _Id = (long)_EntityDataRow["Id"];
                _productListDetails_Id = (long)_EntityDataRow["ProductList_Id"];
                _quantity = (int)_EntityDataRow["Quantity"];
                _particulars = _EntityDataRow["Particulars"].ToString();
                //_unitPrice = (decimal)_EntityDataRow["UnitPrice"];
            }
        }

        #endregion

        public ProductListDetails(DataRow dr)
        {
            EntityDataRow = dr;
        }
        public ProductListDetails()
        {
        }

        long _productListDetails_Id;
        public long ProductList_Id
        {
            get{return _productListDetails_Id;}
            set { _productListDetails_Id = value; }
        }

        ProductList _productList;
        public ProductList ProductListEntity
        {
            get { return _productList; }
            set { _productList = value; }
        }

        int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        string _particulars;
        public string Particulars
        {
            get { return _particulars; }
            set { _particulars = value; }
        }
        //decimal _unitPrice;
        //public decimal UnitPrice
        //{
        //    get { return _unitPrice; }
        //    set { _unitPrice = value; }
        //}


        

    }
}
