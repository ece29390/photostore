using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class OrderPackageDetails:BaseEntity,IEntity
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
                _EntityDataRow = value ;
                _Id = (long)_EntityDataRow["Id"];
                _particulars = _EntityDataRow["Particulars"].ToString();
                _quantity = (int)_EntityDataRow["Quantity"];
                _orderDetailsId = (long)_EntityDataRow["OrderDetails_Id"];
                _isRejected = (bool)_EntityDataRow["IsRejectedOrder"];
                _dateLastModified =Convert.ToDateTime(_EntityDataRow["DateLastModified"]);
            }
        }

        #endregion
        public OrderPackageDetails()
        {
        }
        public OrderPackageDetails(DataRow dr)
        {
            EntityDataRow = dr;
            
        }
        string _particulars;
        int _quantity;
        long _orderDetailsId = -1;
        bool _isRejected = false;
        DateTime _dateLastModified;
        public DateTime DateLastModified
        {
            get { return _dateLastModified; }
            set { _dateLastModified = value; }
        }
        public string Particulars
        {
            get { return _particulars; }
            set { _particulars = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        OrderTransactionDetail _orderTransactionDetail;
        public OrderTransactionDetail OrderTransactionDetail
        {
            get { return _orderTransactionDetail; }
            set { _orderTransactionDetail = value; }
        }
        public long OrderTransactionDetailId
        {
            get { return _orderDetailsId; }
            set { _orderDetailsId = value; }
        }
        public bool IsRejected
        {
            get { return _isRejected; }
            set { _isRejected = value; }
        }
        
    }
}
