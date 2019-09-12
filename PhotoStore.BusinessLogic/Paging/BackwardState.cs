using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoStore.BusinessLogic.Paging
{
    public class BackwardState:PagingState
    {
        public BackwardState(PagingState state)
            :this(state.DelegatedRetrieveData,
            state.DelegatedTotalCount,
            state.CurrentIndex,
            state.TotalRecords,
            state.PageContext)
        {
        }
        public BackwardState(RetrieveData retrieveData
            ,TotalCount totalCount
            ,int currentIndex
            ,int totalRecords
            , Page page)
        {
            base._retrieveData = retrieveData;
            base._totalCount = totalCount;
            base._totalNumberOfRecord = totalRecords;
            base._index = currentIndex;
            base.PageContext = page;
        }

        public override void Move(int newIndex, Direction direction, string columnToBeSorted,
                string columnToBeSelected
            , Dictionary<string, object> parameterDic)
        {

            int oldIndex = base._index;
            base._index = newIndex;
            GetSource(direction,columnToBeSorted,columnToBeSelected,parameterDic);
            if (oldIndex == 1)
                base.PageContext.State = new InitialState(this);
            else if (oldIndex > newIndex)
                base.PageContext.State = this;
            else
                base.PageContext.State = new ForwardState(this);

            base.PageContext.PagingArgument.EnableBackward = newIndex > 1;

            base.PageContext.PagingArgument.EnableForward =
            base._index <= base.MaximumPage; 
       
           
        }
    }
}
