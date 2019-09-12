using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace PhotoStore.Entity
{
    public class OrderTransactionModifiedBy : BaseEntity, IEntity
    {
        public OrderTransactionModifiedBy()
        {

        }

        public OrderTransactionModifiedBy(DataRow dr)
        {
            EntityDataRow = dr;
        }

        #region BaseEntity Overrides
        public override string Lookup
        {
            get { return _ModifiedByEmployeeId + "-" + _Remarks; }
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
                _OrderTransactionId = Convert.ToInt32(_EntityDataRow["OrderTransactionId"]);
                _ModifiedByEmployeeId = Convert.ToInt32(_EntityDataRow["ModifiedByEmployeeId"]);
                _Remarks = (string)_EntityDataRow["Remarks"];
                _DateLastModified = (DateTime)_EntityDataRow["DateLastModified"];

            }
        }
        #endregion

        #region Entity Properties

        private long _OrderTransactionId = -1;
        public long OrderTransactionId
        {
            get { return _OrderTransactionId; }
            set { _OrderTransactionId = value; }
        }

        private long _ModifiedByEmployeeId = -1;
        public long ModifiedByEmployeeId
        {
            get { return _ModifiedByEmployeeId; }
            set { _ModifiedByEmployeeId = value; }
        }

        private string _Remarks = "";
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        private DateTime _DateLastModified=DateTime.Now;
        public DateTime DateLastModified
        {
            get { return _DateLastModified; }
            //set { _DateLastModified = value; }
        }

        #endregion

        #region Related Entities
        private Entity.Employee _ModifiedByEmployee;
        public Entity.Employee ModifiedByEmployee
        {
            get { return _ModifiedByEmployee; }
            set { _ModifiedByEmployee = value; }
        }

        public string ModifiedByEmployeeFullName
        {
            get { return _ModifiedByEmployee.FullName; }
        }

        private OrderTransaction _OrderTransactionEntity = null;
        public OrderTransaction OrderTransactionEntity
        {
            get { return _OrderTransactionEntity; }
            set
            {
                _OrderTransactionEntity = value;
                _OrderTransactionId = _OrderTransactionEntity.Id;
            }
        }
        #endregion
    }
}
