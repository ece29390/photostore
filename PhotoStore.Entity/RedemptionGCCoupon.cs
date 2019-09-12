using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class RedemptionGCCoupon:IEntity
    {
        #region IEntity Members
        long _id;
        public long Id
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string Lookup
        {
            get { return ""; }
        }
        DataRow _entityDataRow;
        public DataRow EntityDataRow
        {
            get
            {
               return _entityDataRow;
            }
            set
            {
                _entityDataRow=value;
                _id = Convert.ToInt64(_entityDataRow["Id"]);
                _childProductListId = Convert.ToInt64(_entityDataRow["ProductListId"]);
                _parentProductListId = Convert.ToInt64(_entityDataRow["Parent_ProductListId"]);

            }
        }
        long _childProductListId=-1,_parentProductListId=-1;
        public long ChildProductListId
        {
            get { return _childProductListId; }
        }
        public long ParentProductListId
        {
            get { return _parentProductListId; }
        }

        #endregion
        public RedemptionGCCoupon(DataRow dr)
        {
            EntityDataRow = dr;
        }
       
    }
}
