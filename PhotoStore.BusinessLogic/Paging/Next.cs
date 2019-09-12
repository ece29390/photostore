using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using PhotoStore.BusinessLogic;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
namespace PhotoStore.BusinessLogic.Paging
{
    public class Next:Paging
    {
        public Next() : base() { }
        

        public override void Move(int currentIndex, string tableName, string columnsSepartedbyComma,string columnToBeSorted,
            Direction direction)
        {
            CalculateLimits();
            base.GetDs(base.ConstructSQL(currentIndex,
                tableName,
                columnsSepartedbyComma,
                columnToBeSorted,
                direction));
            if (currentIndex == 1)                        
                base._currentIndex += 1;            
            else
            {               
                if (base._pageSize > base.DsReturn.Tables[0].Rows.Count)
                {
                    base._isEnable = false;
                }
            }

        }

       
    }
}
