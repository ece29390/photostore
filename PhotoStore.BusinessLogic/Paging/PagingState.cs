using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
namespace PhotoStore.BusinessLogic.Paging
{
    public abstract class PagingState
    {
         Page _paging;
        protected int _index = 1;
        int _lowerLimit,_upperLimit;
       
        protected RetrieveData _retrieveData;
        protected TotalCount _totalCount;
        protected int _pagingSize=Convert.ToInt32(ConfigurationManager.AppSettings["RecordPageSize"]);
        protected int _totalNumberOfRecord = 0;                
        public int CurrentIndex
        {
            get { return _index; }
            set { _index = value; }
        }
            
        public RetrieveData DelegatedRetrieveData
        {
            get { return _retrieveData; }
            //set { _retrieveData = value; }
        }
        public TotalCount DelegatedTotalCount
        {
            get { return _totalCount; }
        }
        public int LowerLimit
        {
            get { return _lowerLimit; }

        }
        public int UpperLimit
        {
            get { return _upperLimit; }
        }

        public Page PageContext
        {
            get { return _paging; }
            set { _paging = value; }
        }
        public int TotalRecords
        {
            get { return _totalNumberOfRecord; }
        }
        public int MaximumPage
        {
            get 
            {
                int modulus = _totalNumberOfRecord % _pagingSize;
                if (modulus > 0)
                    return (_totalNumberOfRecord / _pagingSize) + 1;
                else
                    return _totalNumberOfRecord / _pagingSize; 

               
            }
        }
        public abstract void Move(int newIndex, Direction direction, string columnToBeSorted,
                string columnToBeSelected, Dictionary<string, object> paramDic);
     
        public  void GetSource(Direction direction,string columnToBeSorted,
                string columnToBeSelected,Dictionary<string,object> paramDic)
        {

            int _lowerLimit = (_pagingSize * _index - _pagingSize)+1;
            int _upperLimit = _pagingSize * _index;

           _paging.PagingArgument.BindingSourceObject=_retrieveData(columnToBeSorted,
               columnToBeSelected,
               _index,
                EnumReader.GetDescription(direction),
                _upperLimit,
                _lowerLimit,
                paramDic
                );
           if (_totalNumberOfRecord == 0)
           {
               _totalNumberOfRecord = _totalCount(paramDic);
           }
           if (_paging.PagingArgument.BindingSourceObject.Count == 0)
           {
               _paging.PagingArgument.EnableBackward = false;
               _paging.PagingArgument.EnableForward = false;
               this._index = 0;
           }
           else
           {
               if (_totalNumberOfRecord > _paging.PagingArgument.BindingSourceObject.Count)
                   _paging.PagingArgument.EnableForward = true;

           }
         


         
        }


    }
}
