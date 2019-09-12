using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class OrderTransactionView:OrderTransaction
    {
        double _totalBalance;
        decimal _totalAmount;
        string _fullName;
      
        public OrderTransactionView(DataRow dr) : base(dr) 
        {
            _totalBalance = Convert.ToDouble(dr["TotalBalance"]);
            _totalAmount = Convert.ToDecimal(dr["TransactionAmount"]);
            _fullName = dr["FullName"].ToString();
        }
        public string TransactionDate
        {
            get { return base.DateCreated.ToShortDateString(); }
        }
        public string MothersName
        {
            get { return CustomerEntity.MothersName; }
            set { CustomerEntity.MothersName = value; }
        }

        public double TotalBalance
        {
            get { return _totalBalance; }
        }
        public decimal TotalAmount
        {
            get { return _totalAmount; }
        }
        public string FullName
        {
            get { return _fullName; }
        }
      
    }
}
