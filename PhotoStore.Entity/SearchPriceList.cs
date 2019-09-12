using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class SearchPriceList:BaseEntity,IEntity
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
               _ProductListId = (long)_EntityDataRow["ProductListId"];
               _ProductName = _EntityDataRow["ProductName"].ToString();
               _ProductType = _EntityDataRow["ProductType"].ToString();
               _ParticularType_Id = (long)_EntityDataRow["ParticularType_Id"];
               _IsPackage = (bool)_EntityDataRow["IsPackage"];
                if(_EntityDataRow["Quantity"]!=DBNull.Value)
                    _Quantity = (int)_EntityDataRow["Quantity"];
                if(_EntityDataRow["Particulars"]!=DBNull.Value)
                    _Particulars = _EntityDataRow["Particulars"].ToString();

                if(_EntityDataRow["UnitPrice"]!=DBNull.Value)
                     _UnitPrice = (decimal)_EntityDataRow["UnitPrice"];
            }
        }

        #endregion
        public SearchPriceList(DataRow dr)
        {
            EntityDataRow = dr;
         
        }
        public SearchPriceList()
        {

        }
        long _ProductListId;
        public long ProductListId
        {
            get { return _ProductListId; }
            set { _ProductListId = value; }
        }
        string _ProductName;
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        string _ProductType;
        public string ProductType
        {
            get { return _ProductType; }
            set { _ProductType = value; }
        }
        long _ParticularType_Id;
        public long ParticularType_Id
        {
            get { return _ParticularType_Id; }
            set { _ParticularType_Id = value; }
        }
        bool? _IsPackage;
        public bool? IsPackage
        {
            get { return _IsPackage; }
            set { _IsPackage = value; }
        }
        int _Quantity;
        public int Quantity
        {
            get { return _Quantity; }
            set{_Quantity=  value; }
        }
        string _Particulars;
        public string Particulars
        {
            get { return _Particulars; }
            set { _Particulars = value; }
        }
        decimal _UnitPrice;
        public decimal UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
    }
}
