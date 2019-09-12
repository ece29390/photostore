using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class SalesReport:BaseEntity,IEntity
    {
        DataRow _entityDataRow;
        double _dailySales;
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
                _dateCreated = _entityDataRow["DateCreated"].ToString();
                _cash = Convert.ToDouble(_entityDataRow["Cash"]);
                _atmAmntPaid =Convert.ToDouble(_entityDataRow["ATMAmountPaid"]);
                _atmBankFee = Convert.ToDouble(_entityDataRow["ATMBankFee"]);
                _atmRcvd = Convert.ToDouble(_entityDataRow["ATMReceived"]);
                _due =Convert.ToDouble( _entityDataRow["Due"]);
                _ccBankFee =Convert.ToDouble(_entityDataRow["CCBankFee"]);
                _ccRcvd = Convert.ToDouble(_entityDataRow["CCReceived"]);
                _check = Convert.ToDouble(_entityDataRow["Check"]);
                _dailySales = Convert.ToDouble(_entityDataRow["DailySales"]);
            }
        }

        #endregion
        public SalesReport(DataRow dr)
        {
            EntityDataRow = dr;
        }

        string _dateCreated;
        public string DateCreated
        {
            get { return _dateCreated; }
        }
        double _cash, _atmAmntPaid, _atmBankFee, _atmRcvd, _due, _ccBankFee, _ccRcvd,_check;
        public double Cash
        {
            get { return _cash; }
        }
        public double ATMAmountPaid
        {
            get { return _atmAmntPaid; }
        }
        public double ATMBankFee
        {
            get { return _atmBankFee; }
        }
        public double ATMReceived
        {
            get { return _atmRcvd; }
        }
        public double Due
        {
            get { return _due; }
        }
        public double CCBankFee
        {
            get { return _ccBankFee; }
        }
        public double CCReceived
        {
            get { return _ccRcvd; }
        }
        public double Check
        {
            get { return _check; }
        }
        public double DailySales
        {
            get { return _dailySales; }
        }

    }
}
