using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace PhotoStore.Entity
{

    public class SearchCategory :BaseEntity, IEntity
    {
        public SearchCategory()
        {
        }

        public SearchCategory(DataRow dr)
        {

            EntityDataRow = dr;
        }

        #region BaseEntity Overrides
        public override string Lookup
        {
            get { return _value + "-" + _Description; }
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

                _value = Convert.ToInt32(_EntityDataRow["Code"]);
                _Description = (string)_EntityDataRow["Description"];

            }
        }
        #endregion

        public SearchCategory(int value,string description)
        {
            _value = value;
            _Description = description;
        }

        int _value;
        public int Value
        {
            get { return _value; }
            //set { _value = value; }
        }
        string _Description;
        public string Description
        {
            get { return _Description; }
            //set { _Description = value; }
        }
        
    }
}
