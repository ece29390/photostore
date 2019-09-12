using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class CouponReport:BaseEntity,IEntity
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
               // _code = _entityDataRow["Coupon #"].ToString();
                _couponType = _entityDataRow["Coupon Type"].ToString();
                _dateCreated = Convert.ToDateTime(_entityDataRow["DateCreated"]).ToString("MM/dd/yyyy");
               // _status = _entityDataRow["Status"].ToString();
                _quantity = Convert.ToInt32(_entityDataRow["QUANTITY"]);
            }
        }

        #endregion

        string _code, _couponType, _dateCreated, _status;
        int _quantity;
        public int Quantity
        {
            get { return _quantity; }
        }
        public string Code
        {
            get { return _code; }
        }
        public string CouponType
        {
            get { return _couponType; }
        }
        public string DateCreated
        {
            get { return _dateCreated; }
        }
        public string Status
        {
            get { return _status; }
        }
        public CouponReport(DataRow dr)
        {
            EntityDataRow = dr;
        }

    }
}
