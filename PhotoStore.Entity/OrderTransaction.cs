using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace PhotoStore.Entity
{
    public class OrderTransaction : BaseEntity, IEntity
    {
        public OrderTransaction()
        {

        }

        public OrderTransaction(DataRow dr)
        {
            EntityDataRow = dr;
        }

        #region BaseEntity Overrides
        public override string Lookup
        {
            get { return _Code + "-" + _DateCreated; }
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
                _Code = (string)_EntityDataRow["Code"];
                _DateCreated = (DateTime)_EntityDataRow["DateCreated"];
                _CustomerId = Convert.ToInt32(_EntityDataRow["CustomerId"]);
                _OrderStatusId = Convert.ToInt32(_EntityDataRow["OrderStatusId"]);
               // _Freebies = (string)_EntityDataRow["Freebies"];
                PreparedByEmployeeId = Convert.ToInt32(_EntityDataRow["PreparedByEmployeeId"]);
                
                if (_EntityDataRow["CancelledCode"] is DBNull)
                    _CancelledCode = ""; 
                else
                    _CancelledCode = (string)_EntityDataRow["CancelledCode"];

                if (_EntityDataRow["RejectedCode"] is DBNull)
                    _RejectedCode = "";
                else
                    _RejectedCode = (string)_EntityDataRow["RejectedCode"];

                _DateLastModified = (DateTime)_EntityDataRow["DateLastModified"];
                if (_EntityDataRow["PrivilegeCardCode"] is DBNull)
                    _priviledgeCard = "";
                else
                    _priviledgeCard = (string)_EntityDataRow["PrivilegeCardCode"];
            }
        }
        #endregion

        #region Entity Properties
        private string _Code = "";
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        string _priviledgeCard;
        public string PriviledgeCard
        {
            get { return _priviledgeCard; }
            set { _priviledgeCard = value; }
        }
        private DateTime _DateCreated = Convert.ToDateTime("01/01/1900");
        public DateTime DateCreated
        {
            get { return _DateCreated; }
            set { _DateCreated = value; }
        }

        private long _CustomerId = -1;
        public long CustomerId
        {
            get { return _CustomerId; }
            set { _CustomerId = value; }
        }

        private long _OrderStatusId = -1;
        public long OrderStatusId
        {
            get { return _OrderStatusId; }
            set { _OrderStatusId = value; }
        }

        private string _Freebies = "";
        public string Freebies
        {
            get { return _Freebies; }
            set { _Freebies = value; }
        }

        private long _PreparedByEmployeeId = -1;
        public long PreparedByEmployeeId
        {
            get { return _PreparedByEmployeeId; }
            set { _PreparedByEmployeeId = value; }
        }

        private string _CancelledCode = "";
        public string CancelledCode 
        {
            get { return _CancelledCode; }
            set { _CancelledCode = value; }
        }

        private string _RejectedCode = "";
        public string RejectedCode
        {
            get { return _RejectedCode; }
            set { _RejectedCode = value; }
        }

        private DateTime _DateLastModified;
        public DateTime DateLastModified
        {
            get { return _DateLastModified; }
            //set { _DateLastModified = value; }
        }

        #endregion

        #region Related Entities
        private Customer _CustomerEntity = null;
        public Customer CustomerEntity
        {
            get { return _CustomerEntity; }
            set { _CustomerEntity = value; }
        }

        private Employee _PreparedByEmployeeEntity = null;
        public Employee PreparedByEmployeeEntity
        {
            get { return _PreparedByEmployeeEntity; }
            set { _PreparedByEmployeeEntity = value; }
        }

        private OrderStatus _OrderStatusEntity = null;
        public OrderStatus OrderStatusEntity 
        {
            get { return _OrderStatusEntity; }
            set { _OrderStatusEntity = value; }
        }

        private List<Entity.OrderTransactionDetail> _OrderTransactionDetailList=new List<OrderTransactionDetail>();
        public List<Entity.OrderTransactionDetail> OrderTransactionDetailList
        {
            get { return _OrderTransactionDetailList; }
            set
            {
                _OrderTransactionDetailList = value;
                foreach (Entity.OrderTransactionDetail entityObject in _OrderTransactionDetailList)
                {
                    entityObject.OrderTransactionEntity = this;
                }
            }
        }
        private List<Entity.OrderTransactionPayment> _OrderTransactionPaymentList=new List<OrderTransactionPayment>();
        public List<Entity.OrderTransactionPayment> OrderTransactionPaymentList
        {
            get { return _OrderTransactionPaymentList; }
            set
            {
                _OrderTransactionPaymentList = value;
                foreach (Entity.OrderTransactionPayment entityObject in _OrderTransactionPaymentList)
                {
                    entityObject.OrderTransactionEntity = this;
                }
            }
        }
        
        private List<Entity.OrderTransactionModifiedBy> _OrderTransactionModifiedByList=new List<OrderTransactionModifiedBy>();
        public List<Entity.OrderTransactionModifiedBy> OrderTransactionModifiedByList
        {
            get { return _OrderTransactionModifiedByList; }
            set
            {
                _OrderTransactionModifiedByList = value;
                foreach (Entity.OrderTransactionModifiedBy entityObject in _OrderTransactionModifiedByList)
                {
                    entityObject.OrderTransactionEntity = this;
                }
            }
        }
        #endregion

     
    }
}
