using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using PhotoStore.Entity;
using PhotoStore.DataAccess;
using System.Data;
using System.Windows.Forms;
using System.IO;
namespace PhotoStore.BusinessLogic
{
    public delegate BindingSource RetrieveData(
                string columnToBeSorted,
                string columnToBeSelected,
                int currentIndex,
                string direction,
                int upperLimit,
                int lowerLimit,
                Dictionary<string,object> parameterDic);

    public delegate int TotalCount(Dictionary<string, object> parameterDic); 

    
}

