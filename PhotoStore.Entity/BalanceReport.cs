using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class BalanceReport:BaseEntity,IEntity
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
                _code = _entityDataRow["OrderNumber"].ToString();
                _mothersName = _entityDataRow["MommysName"].ToString();
                _balanceDue = Convert.ToDecimal(_entityDataRow["Balance"]);
            }
        }

        #endregion
        public BalanceReport(DataRow dr)
        {
            EntityDataRow = dr;
        }
        string _dateCreated, _code, _mothersName;
        decimal _balanceDue;
        public string DateCreated
        {
            get { return _dateCreated; }
        }
        public string Code
        {
            get { return _code; }
        }
        public string MothersName
        {
            get { return _mothersName; }
        }
        public decimal BalanceDue
        {
            get { return _balanceDue; }
        }
    }
}
