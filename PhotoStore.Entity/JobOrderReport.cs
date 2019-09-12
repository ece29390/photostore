using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoStore.Entity
{
    public class JobOrderReport
    {
        string _date, _orderNumber;
        List<Particulars> _particulars = new List<Particulars>();
        public JobOrderReport(
            DateTime date
            , string ordernumber
           )
        {
            _date = date.ToString("MM/dd/yyyy");
            _orderNumber = ordernumber;
           
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
        }
        public List<Particulars> Particulars
        {
            get { return _particulars; }
            set { _particulars = value; }
        }
        string _motherName;
        public string MothersName
        {
            get { return _motherName; }
            set { _motherName = value; }
        }
    }
}
