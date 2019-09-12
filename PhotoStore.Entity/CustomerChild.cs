using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace PhotoStore.Entity
{
    public class CustomerChild : BaseEntity,IEntity
    {
        public CustomerChild()
        {
            
        }

        public CustomerChild(DataRow dr)
        {
            EntityDataRow = dr;
        }

        #region BaseEntity Overrides
        public override string Lookup
        {
            get { return _Name + "-" + _BirthDate ; }
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
                _Name = (string)_EntityDataRow["Name"];
                _BirthDate = (DateTime)_EntityDataRow["BirthDate"];
                _DateLastModified = (DateTime)_EntityDataRow["DateLastModified"];

            }
        }
        #endregion

        #region Entity Properties
        private long _CustomerId=-1;
        public long CustomerId
        {
            get { return _CustomerId; }
            set { _CustomerId = value; }
        }
        private string _Name="";
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private DateTime _BirthDate=Convert.ToDateTime("01/01/1900");
        public DateTime BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; }
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
            set
            {
                _CustomerEntity = value;
                _CustomerId = _CustomerEntity.Id;
            }
        }
        #endregion






       
    }
}
