using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoStore.Entity
{
    public abstract class BaseEntity
    {
        protected long _Id=-1;
        Guid _recordId = Guid.NewGuid();
        public long Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public Guid RecordId
        {
            get {return _recordId; }
        }

        public abstract string Lookup { get;}

        //protected EntityState _CurrentEntityState = EntityState.New;
        //public EntityState CurrentEntityState
        //{
        //    get { return _CurrentEntityState; }
        //    set { _CurrentEntityState = value; }
        //}
    }
}
