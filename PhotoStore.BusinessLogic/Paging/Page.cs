using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoStore.BusinessLogic.Paging
{
    public class Page
    {
        PagingState _pagingState;
        public PagingState State
        {
            get { return _pagingState; }
            set { _pagingState = value; }
        }
        PageArgs _pageArgs=new PageArgs();
        public PageArgs PagingArgument
        {
            get { return _pageArgs; }
            set
            {
               
                _pageArgs = value;
            }
        }
        public Page(RetrieveData retrieveData,TotalCount totalCount)
        {
            _pagingState = new InitialState(retrieveData,totalCount,1,0, this);
        }

        public void Move(int newIndex, Direction direction, string columnToBeSorted,
                string columnToBeSelected
            , Dictionary<string, object> parameterDic)
        {
            _pagingState.Move(newIndex, direction,columnToBeSorted,columnToBeSelected,parameterDic);
        }
        public void GetSource(Direction direction, string columnToBeSorted,
                string columnToBeSelected,Dictionary<string,object> paramDic)
        {
            _pagingState.GetSource(direction,
                columnToBeSorted, columnToBeSelected,paramDic);
        }
    }
}
