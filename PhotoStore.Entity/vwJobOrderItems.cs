using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class vwJobOrderItems:JobOrders
    {
        DateTime _otDate;
        string _orderNumber;
        bool _isSelected;
        long _supplierId;
        int _maxQuantity;
        public DateTime DateCreated
        {
            get { return _otDate; }
            set { _otDate = value; }
        }
        public long SupplierId
        {
            get { return _supplierId; }
            set { _supplierId = value; }
        }
        public string Code
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
        }
        public int MaxQuantity
        {
            get { return _maxQuantity; }
        }
        public bool Selected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }
        public vwJobOrderItems(DataRow dr):base(dr)
        {          
            _otDate = Convert.ToDateTime(dr["DateCreated"]);
            _orderNumber = dr["Code"].ToString();
            _isSelected = Convert.ToBoolean(dr["Selected"]);
            _supplierId = Convert.ToInt64(dr["SupplierId"]);
            _maxQuantity = base.Quantity;
        }
    }
}
