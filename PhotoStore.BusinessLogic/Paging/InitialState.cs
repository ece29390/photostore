using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PhotoStore.BusinessLogic.Paging
{
    public class InitialState:PagingState
    {
        public InitialState(PagingState state)
            :
           this(       
            state.DelegatedRetrieveData,
            state.DelegatedTotalCount,
            state.CurrentIndex,
            state.TotalRecords,
            state.PageContext)
        {
           
        }
            

        public InitialState(
           RetrieveData retrieveData
            ,TotalCount totalCount
            ,int currentIndex
            ,int totalRecords
            ,Page page
            )
        {

            base._retrieveData = retrieveData;
            base._totalCount = totalCount;
           
            PageContext = page;
            base._index = currentIndex;
        }
        public override void Move(int newIndex, Direction direction, string columnToBeSorted,
                string columnToBeSelected, Dictionary<string, object> parameterDic)
        {
            base._index = newIndex;
            PageContext.PagingArgument.EnableBackward = true;
            PageContext.PagingArgument.EnableForward = true;
            GetSource(direction,columnToBeSorted,columnToBeSelected,parameterDic);
            this.PageContext.State = new ForwardState(
               this);

            base.PageContext.PagingArgument.EnableForward =
                base._index < base.MaximumPage ;
        }
      
    }
}
