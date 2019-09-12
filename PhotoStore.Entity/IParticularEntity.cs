using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoStore.Entity
{
    public interface IParticularEntity
    {
        long Id { get;set;}
        string Code { get;set;}
        string Description { get;set;}
        double UnitPrice { get;set;}
    }
}
