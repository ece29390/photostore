using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace PhotoStore.Entity
{
    public class Customer : BaseEntity,IEntity
    {
        public Customer()
        {
        }

        public Customer(DataRow dr)
        {
            EntityDataRow = dr;
        }

        #region BaseEntity Overrides
        public override string Lookup
        {
            get { return _Code + "-" + _MothersName ; }
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

                _Id = Convert.ToInt64( _EntityDataRow["Id"]);
                _Code = (string)_EntityDataRow["Code"];
                _PrivilegeCardCode = (string)_EntityDataRow["PrivilegeCardCode"];
                _CDNumbers = (string)_EntityDataRow["CDNumbers"];
                _FathersName = (string)_EntityDataRow["FathersName"];
                _FathersBirthDate = (DateTime)_EntityDataRow["FathersBirthDate"];
                _FathersLandLine = (string)_EntityDataRow["FathersLandLine"];
                _FathersCellNumber = (string)_EntityDataRow["FathersCellNumber"];
                _MothersName = (string)_EntityDataRow["MothersName"];
                _MothersBirthDate = (DateTime)_EntityDataRow["MothersBirthDate"];
                _MothersLandLine = (string)_EntityDataRow["MothersLandLine"];
                _MothersCellNumber = (string)_EntityDataRow["MothersCellNumber"];
                _Address = (string)_EntityDataRow["Address"];
                _Area = (string)_EntityDataRow["Area"];
                _Email = (string)_EntityDataRow["Email"];
                _DateLastModified = (DateTime)_EntityDataRow["DateLastModified"];

            }
        }
        #endregion

        #region Entity Properties
        private string _Code;
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        private string _PrivilegeCardCode;
        public string PrivilegeCardCode
        {
            get { return _PrivilegeCardCode; }
            set { _PrivilegeCardCode = value; }
        }

        private string _CDNumbers;
        public string CDNumbers
        {
            get { return _CDNumbers; }
            set { _CDNumbers = value; }
        }

        private string _FathersName;
        public string FathersName
        {
            get { return _FathersName; }
            set { _FathersName = value; }
        }

        private DateTime _FathersBirthDate;
        public DateTime FathersBirthDate
        {
            get { return _FathersBirthDate; }
            set { _FathersBirthDate = value; }
        }

        private string _FathersLandLine;
        public string FathersLandLine
        {
            get { return _FathersLandLine; }
            set { _FathersLandLine = value; }
        }

        private string _FathersCellNumber;
        public string FathersCellNumber
        {
            get { return _FathersCellNumber; }
            set { _FathersCellNumber = value; }
        }

        private string _MothersName;
        public string MothersName
        {
            get { return _MothersName; }
            set { _MothersName = value; }
        }

        private DateTime _MothersBirthDate;
        public DateTime MothersBirthDate
        {
            get { return _MothersBirthDate; }
            set { _MothersBirthDate = value; }
        }

        private string _MothersLandLine;
        public string MothersLandLine
        {
            get { return _MothersLandLine; }
            set { _MothersLandLine = value; }
        }

        private string _MothersCellNumber;
        public string MothersCellNumber
        {
            get { return _MothersCellNumber; }
            set { _MothersCellNumber = value; }
        }

        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private string _Area;
        public string Area
        {
            get { return _Area; }
            set { _Area = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private DateTime _DateLastModified;
        public DateTime DateLastModified
        {
            get { return _DateLastModified; }
            //set { _DateLastModified = value; }
        }
        
        #endregion

        #region Child Properties
        private List<Entity.CustomerChild> _CustomerChildList;
        public List<Entity.CustomerChild> CustomerChildList
        {
            get { return _CustomerChildList; }
            set
            {
                _CustomerChildList = value;
                foreach (Entity.CustomerChild entityObject in _CustomerChildList)
                {
                    entityObject.CustomerEntity = this;
                }
            }
        }

        #endregion
    }
}
