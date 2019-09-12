using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class JobOrderByType:BaseEntity,IEntity
    {
        private long _jobOrderId;
        private string _code, _supplierCode,_orderNumber;
        private int _quantity;
        private DataRow _entityDataRow;
        public JobOrderByType(DataRow dr)
        {
            EntityDataRow = dr;
        }

        public long JobOrderId
        {
            get { return _jobOrderId; }
        }
        public string Code
        {
            get { return _code; }
        }
        public string SupplierCode
        {
            get { return _supplierCode; }
            
        }
        public int Quantity
        {
            get { return _quantity; }
        }
        public string OrderNumber
        {
            get { return _orderNumber; }
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
                _entityDataRow = value;
                _jobOrderId = Convert.ToInt64(_entityDataRow["JOBORDERID"]);
                //_Id = _jobOrderId;
                _code = _entityDataRow["CODE"].ToString();
                _quantity = Convert.ToInt32(_entityDataRow["QUANTITY"]);
                _supplierCode = _entityDataRow["SUPPLIERCODE"].ToString();
                _orderNumber = _entityDataRow["ORDERTRANSACTIONCODE"].ToString();
            }
        }

        #endregion

        public override string Lookup
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
    }
}
