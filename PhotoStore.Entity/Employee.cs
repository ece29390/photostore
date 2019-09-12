using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace PhotoStore.Entity
{
    public class Employee : BaseEntity, IEntity
    {
        public Employee()
        {

        }

        public Employee(DataRow dr)
        {
            EntityDataRow = dr;
        }

        #region BaseEntity Overrides
        public override string Lookup
        {
            get { return _UserName + "-" + _FullName; }
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
                _UserName = (string)_EntityDataRow["UserName"];
                _Password = (string)_EntityDataRow["Password"];
                _FullName = (string)_EntityDataRow["FullName"];
                _EmployeeGroupId = Convert.ToInt32(_EntityDataRow["EmployeeGroupId"]);
                _DateLastModified = (DateTime)_EntityDataRow["DateLastModified"];

            }
        }
        #endregion

        #region Entity Properties

        private string _UserName = "";
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _Password = "";
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        
        private string _FullName = "";
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        private int _EmployeeGroupId = -1;
        public int EmployeeGroupId
        {
            get { return _EmployeeGroupId; }
            set { _EmployeeGroupId = value; }
        }
        private EmployeeGroup _EmployeeGroup = null;
        public EmployeeGroup EmployeeGroup
        {
            get { return _EmployeeGroup; }
            set { _EmployeeGroup = value; }
        }
        private string _groupDescription = "-Please Select a group-";
        public string GroupDescription
        {
            get
            {
                if (_EmployeeGroup != null)
                {
                    _groupDescription = _EmployeeGroup.Description;
                    return _groupDescription;
                }
                else
                {
                    return _groupDescription;
                }
            }
            set { _groupDescription = value; }
        }

        private DateTime _DateLastModified;
        public DateTime DateLastModified
        {
            get { return _DateLastModified; }
            //set { _DateLastModified = value; }
        }

        #endregion
    }
}
