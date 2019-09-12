using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace PhotoStore.BusinessLogic.Paging
{
    public abstract class blPaging
    {
        public abstract  BindingSource RetrieveByPaging(string tableName,
                string columnToBeSorted,
                string columnsToBeSelected,
                string direction,
                string upperLimit,
                string lowerLimit); 
    }
}
