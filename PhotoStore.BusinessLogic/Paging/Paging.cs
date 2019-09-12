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
    public abstract class Paging
    {
        DataSet dsReturn;
        protected  string _withStatement;
        protected readonly int _pageSize;
        protected bool _isEnable;
        protected int _currentIndex;
        int _lowerLimit,_upperLimit;
        public Paging()
        {
//            WITH tempTable AS (
            //SELECT ROW_NUMBER() OVER (ORDER BY Code DESC)
            //AS Row,* FROM GiftCertificate
            //)
            _withStatement = "WITH tempTable AS (SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) AS Row,{2} FROM {3}) SELECT * FROM tempTable WHERE Row BETWEEN {4} AND {5}";
            _pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["RecordPageSize"]);
        }
         public abstract void Move(int currentIndex,
             string tableName,
             string columnsSepartedbyComma,
             string columnToBeSorted,
             Direction direction);

        protected string ConstructSQL(int currentIndex,
             string tableName,
             string columnsSepartedbyComma,
             string columnToBeSorted,
             Direction direction)
        {
            return _withStatement = string.Format(
                _withStatement, columnToBeSorted,EnumReader.GetDescription(direction),
                string.IsNullOrEmpty(columnsSepartedbyComma) ? "*" : columnsSepartedbyComma,
                tableName,
                _lowerLimit,
                _upperLimit);
        }
        protected void GetDs(string sqlStatement)
        {

            dsReturn = DataAccess.daHelper.executeSelect(sqlStatement);
        }
        protected void CalculateIndex()
        {
            if (dsReturn != null)
            {
                if (_pageSize > dsReturn.Tables[0].Rows.Count)
                {
                    _isEnable = false;

                }
                else
                {
                    _currentIndex += 1;
                }
            }
            
        }
        protected void CalculateLimits()
        {
            _lowerLimit = (_pageSize * _currentIndex - _pageSize) + 1;
            _upperLimit = _pageSize * _currentIndex;

        }
        public DataSet DsReturn
        {
            get { return dsReturn; }
        }
        public bool IsEnable
        {
            get { return _isEnable; }
        }
        public int NewIndex
        {
            get { return _currentIndex; }
        }
        
        

    }
}
