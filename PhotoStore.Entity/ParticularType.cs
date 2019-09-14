using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class ParticularType : BaseEntity, IEntity
    {
        public ParticularType()
        {

        }

        public ParticularType(DataRow dr)
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
                _DateLastModified = (DateTime)_EntityDataRow["DateLastModified"];
                _multipleItems = (bool)_EntityDataRow["MultipleItems"];
                _isParent = (bool)_EntityDataRow["IsParent"];
                _isPrintable = (bool)_EntityDataRow["IsPrintable"];

            }
        }
        #endregion

        #region Entity Properties
        private bool _multipleItems,_isPrintable;
        public bool MultipleItems
        {
            get { return _multipleItems; }
            set { _multipleItems = value; }
        }
        public bool IsPrintable
        {
            get { return _isPrintable; }
            set { _isPrintable = value; }
        }
        bool _isParent;
        public bool IsParent
        {
            get { return _isParent; }
            set { _isParent = value; }
        }

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

        private DateTime _DateLastModified;
        public DateTime DateLastModified
        {
            get { return _DateLastModified; }
            //set { _DateLastModified = value; }
        }

        #endregion
    }
}
