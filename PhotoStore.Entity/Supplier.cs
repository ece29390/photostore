using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace PhotoStore.Entity
{
    public class Supplier : BaseEntity, IEntity
    {
        public Supplier()
        {

        }

        public Supplier(DataRow dr)
        {
            EntityDataRow = dr;
        }

        #region BaseEntity Overrides
        public override string Lookup
        {
            get { return _Code + "-" + _Description; }
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
                _Description = (string)_EntityDataRow["Description"];
                _address =_EntityDataRow["Address"].ToString();
                _dateLastModified = (DateTime)_EntityDataRow["DateLastModified"];
                _contactNumber = _EntityDataRow["ContactNumber"].ToString();

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

        private string _Description = "";
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _contactNumber;
        public string ContactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; }
        }
        private DateTime _dateLastModified;
        public DateTime DateLastModified
        {
            get { return _dateLastModified; }
        }

        #endregion

        
    }
}
