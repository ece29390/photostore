using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace PhotoStore.Entity
{
    public class JobOrder:BaseEntity,IEntity
    {
        public JobOrder()
        {
            //if (_JobOrderTypeId == -1)
            //{
            //    if (_initialJobOrderTypeId.HasValue)
            //        _JobOrderTypeId = _initialJobOrderTypeId.Value;
            //}
        }

        public JobOrder(DataRow dr)
        {
            EntityDataRow = dr;
            //if (_JobOrderTypeId == -1)
            //{
            //    if (_initialJobOrderTypeId.HasValue)
            //        _JobOrderTypeId = _initialJobOrderTypeId.Value;
            //}
        }

        #region BaseEntity Overrides
        public override string Lookup
        {
            get { return _Code; }
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
                _DateLastModified = (DateTime)_EntityDataRow["DateLastModified"];
                _transactionDate = Convert.ToDateTime(_EntityDataRow["TransactionDate"]);
                //if (_EntityDataRow["IsDone"] != DBNull.Value)
                   // _isDone = Convert.ToBoolean(_EntityDataRow["IsDone"]);

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

        DateTime _transactionDate;
        public DateTime TransactionDate
        {
            get{return _transactionDate;}
            set{_transactionDate=value;}
        }

      
        //private bool _isDone ;
        //public bool IsDone
        //{
        //    get { return _isDone; }
        //    set { _isDone = value; }
        //}
      
        private DateTime _DateLastModified;
        public DateTime DateLastModified
        {
            get { return _DateLastModified; }
            //set { _DateLastModified = value; }
        }
       
        #endregion

        
    }
}
