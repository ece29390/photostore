using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class DetailedSalesReport:SalesReport
    {
        string _orderNumber, _customerName;
        public DetailedSalesReport(DataRow dr)
            : base(dr)
        {
            _orderNumber = dr["CODE"].ToString();
            _customerName = dr["CUSTOMERNAME"].ToString();
        }
        public string OrderNumber
        {
            get { return _orderNumber; }
        }
        public string CustomerName
        {
            get { return _customerName; }
        }
    }
}
