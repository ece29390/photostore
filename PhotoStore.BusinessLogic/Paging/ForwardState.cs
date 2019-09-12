using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
namespace PhotoStore.BusinessLogic.Paging
{
    public class ForwardState:PagingState
    {
        public ForwardState(PagingState state):
            this(        
            state.DelegatedRetrieveData,
            state.DelegatedTotalCount,
            state.CurrentIndex,
            state.TotalRecords,
            state.PageContext)
        {

        }
        public ForwardState(
           RetrieveData retrieveData,
            TotalCount totalCount,
            int currentIndex
            ,int totalRecords
            , Page page
            )
        {
            base._retrieveData = retrieveData;   
            base._totalCount=totalCount;
            this.PageContext = page;
            this._index = currentIndex;
            base._totalNumberOfRecord = totalRecords;

         

        }
        public override void Move(int newIndex,Direction direction,string columnToBeSorted,
                string columnToBeSelected, Dictionary<string, object> paramDic)
        {
            int oldIndex = base._index;
            base._index = newIndex;
            GetSource(direction,columnToBeSorted,columnToBeSelected,paramDic);
                        
            //base.PageContext.PagingArgument.EnableBackward = true;
            if (oldIndex > newIndex)
            {
                if (newIndex == 1)
                    base.PageContext.State = new InitialState(this);
                else
                    base.PageContext.State = new BackwardState(this);
            }
            else
                base.PageContext.State = this;

            base.PageContext.PagingArgument.EnableForward =
             base._index < base.MaximumPage;
            base.PageContext.PagingArgument.EnableBackward = base._index == 1 ? false : true;

        }

       
    }
}
