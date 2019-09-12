using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class MissingJobOrder : BaseEntity, IEntity
    {
        public override string Lookup
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #region IEntity Members

        DataRow _entityDataRow;
        public DataRow EntityDataRow
        {
            get
            {
                return _entityDataRow;
            }
            set
            {
                _entityDataRow = value;
                Code = _entityDataRow["Code"].ToString();
                OrderedQuantity = Convert.ToInt32(_entityDataRow["OrderedQuantity"]);
                Particulars = _entityDataRow["Particulars"].ToString();
                ParticularTypeId = Convert.ToInt64(_entityDataRow["ParticularTypeId"]);
                Description = _entityDataRow["Description"].ToString();
                MultipleItems = Convert.ToBoolean(_entityDataRow["MultipleItems"]);
                ProductListId = Convert.ToInt64(_entityDataRow["ProductListId"]);
                Id = Convert.ToInt64(_entityDataRow["Id"]);
            }
        }
        #endregion

        public MissingJobOrder(DataRow dr)
        {
            EntityDataRow = dr;
        }

        string _code;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        int _orderedQuantity;
        public int OrderedQuantity
        {
            get { return _orderedQuantity; }
            set { _orderedQuantity = value; }
        }
        string _particulars;
        public string Particulars
        {
            get { return _particulars; }
            set { _particulars = value; }
        }
        long _particularTypeId;
        public long ParticularTypeId
        {
            get { return _particularTypeId; }
            set { _particularTypeId = value; }
        }
        string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        bool _multipleItems;
        public bool MultipleItems
        {
            get { return _multipleItems; }
            set { _multipleItems = value; }

        }
        long _productListId;
        public long ProductListId
        {
            get { return _productListId; }
            set { _productListId = value; }
        }
        long _id;
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }



    }
}
