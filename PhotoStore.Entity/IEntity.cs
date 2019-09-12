using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace PhotoStore.Entity
{
    public interface IEntity
    {
        long Id { get;set;}
        string Lookup { get;}
        DataRow EntityDataRow { get;set;}
    }

}
