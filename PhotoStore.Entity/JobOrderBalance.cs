using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace PhotoStore.Entity
{
    public class JobOrderBalance : BaseEntity, IEntity
    {
        public JobOrderBalance()
        {
           
        }

        public JobOrderBalance(DataRow dr)
        {
         
            EntityDataRow = dr;
           
        }

        #region BaseEntity Overrides
        public override string Lookup
        {
            get { return ""; }
        }
        #endregion

        #region IEntity Implementations
        private DataRow _EntityDataRow;
        public DataRow EntityDataRow
        {
            get { return _EntityDataRow; }
            set
            {
                _EntityDataRow = value;

                _Id = Convert.ToInt32(_EntityDataRow["Id"]);
                _balanceQuantity = Convert.ToInt32(_EntityDataRow["BalanceQuantity"]);
                _orderTransactionId = Convert.ToInt32(_EntityDataRow["OrderId_FK"]);
                _DateLastModified = (DateTime)_EntityDataRow["DateLastModified"];
               

            }
        }
        #endregion

        #region Entity Properties



        private int _balanceQuantity = 0;
        public int BalanceQuantity
        {
            get { return _balanceQuantity; }
            set { _balanceQuantity = value; }
        }

        private int _orderTransactionId = -1;
        public int OrderTransactionId
        {
            get { return _orderTransactionId; }
            set { _orderTransactionId = value; }
        }
        private OrderTransaction _orderTransaction = null;
        public OrderTransaction OrderTransaction
        {
            get { return _orderTransaction; }
            set { _orderTransaction = value; }
        }

      
        private DateTime _DateLastModified;
        public DateTime DateLastModified
        {
            get { return _DateLastModified; }
            //set { _DateLastModified = value; }
        }

    }
}
        #endregion