using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class ReleaseReport:BaseEntity
    {
        public override string Lookup
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public ReleaseReport(DataRow dr)
        {
            EntityDataRow = dr;
        }
        DataRow _entityDataRow;
        public DataRow EntityDataRow
        {
            get { return _entityDataRow; }
            set { _entityDataRow = value;
            _jobOrderNumber = _entityDataRow["JobOrderNumber"].ToString();
            _orderNumber = _entityDataRow["OrderNumber"].ToString();
            _particulars = _entityDataRow["Particulars"].ToString();
            _joDate = Convert.ToDateTime(_entityDataRow["JODate"]);
            _dateCreated = Convert.ToDateTime(_entityDataRow["DateCreated"]);
            _quantity = Convert.ToInt32(_entityDataRow["Quantity"]);
            _Id = Convert.ToInt32(_entityDataRow["Id"]);
            _rejectedQuantity = Convert.ToInt32(_entityDataRow["RejectedQuantity"]);
            }
        }
        string _jobOrderNumber, _orderNumber, _particulars;
        DateTime _joDate, _dateCreated;
        int _quantity,_rejectedQuantity;
        public int RejectedQuantity
        {
            get { return _rejectedQuantity; }
        }
        public string JobOrderNumber
        {
            get { return _jobOrderNumber; }
        }
        public string JODate
        {
            get { return _joDate.ToString("MM/dd/yyyy"); }
        }
        public string DateCreated
        {
            get { return _dateCreated.ToString("MM/dd/yyyy"); }
        }
        public string OrderNumber
        {
            get { return _orderNumber; }
        }
        public string Particulars
        {
            get { return _particulars; }
        }
        public int Quantity
        {
            get { return _quantity; }
        }

    }
}
