using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace PhotoStore.Entity
{
    public class PrivilegeCard : BaseEntity, IEntity
    {
        public PrivilegeCard()
        {

        }

        public PrivilegeCard(DataRow dr)
        {
            EntityDataRow = dr;
        }

        #region BaseEntity Overrides
        public override string Lookup
        {
            get { return _Id + "-" + _Code; }
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
                _CustomerId = Convert.ToInt32(_EntityDataRow["CustomerId"]);
                _Code = Convert.ToString(_EntityDataRow["Code"]);
                //_Code = _Code.Replace(
                //    System.Configuration.ConfigurationManager.AppSettings["BranchCode"].ToString(),
                //    "").Trim();
                _IssueDate = Convert.ToDateTime(_EntityDataRow["IssueDate"]);
                _ExpirationDate = Convert.ToDateTime(_EntityDataRow["ExpirationDate"]);
                _Remarks = Convert.ToString(_EntityDataRow["Remarks"]);
                _DateLastModified = (DateTime)_EntityDataRow["DateLastModified"];

            }
        }
        #endregion

        #region Entity Properties
        private long _CustomerId = -1;
        public long CustomerId
        {
            get { return _CustomerId; }
            set { _CustomerId = value; }
        }
        private string _Code = "";
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        private DateTime _IssueDate=DateTime.Now;
        public DateTime IssueDate
        {
            get { return _IssueDate; }
            set { _IssueDate = value; }
        }

        private DateTime _ExpirationDate=DateTime.Now.AddYears(1);
        public DateTime ExpirationDate
        {
            get { return _ExpirationDate; }
            set { _ExpirationDate = value; }
        }
        
        private string _Remarks="";
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        private DateTime _DateLastModified;
        public DateTime DateLastModified
        {
            get { return _DateLastModified; }
            //set { _DateLastModified = value; }
        }

        #endregion

        #region Extended Entities
        private Customer _CustomerEntity = null;
        public Customer CustomerEntity
        {
            get { return _CustomerEntity; }
            set
            {
                _CustomerEntity = value;
                _CustomerId = _CustomerEntity.Id;
            }
        }

        #endregion

        #region other properties
        public bool isExpired
        {
            get { return (DateTime.Now > Convert.ToDateTime(_ExpirationDate)); }
        }
        #endregion

    }
}
