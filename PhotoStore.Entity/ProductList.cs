using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
namespace PhotoStore.Entity
{
    public class ProductList : BaseEntity, IEntity
    {
        public ProductList()
        {

        }

        public ProductList(DataRow dr)
        {
            EntityDataRow = dr;
        }

        #region BaseEntity Overrides
        public override string Lookup
        {
            get { return ""; }
        }
        #endregion

        #region IEntity Implementations
        private DataRow _EntityDataRow;
        public DataRow EntityDataRow
        {
            get { return _EntityDataRow; }
            set
            {
                _EntityDataRow = value;

                _Id = Convert.ToInt64(_EntityDataRow["Id"]);
                _description = (string)_EntityDataRow["Description"];
                _particularTypeId = Convert.ToInt32(_EntityDataRow["ParticularType_Id"]);
                _dateCreated = (DateTime)_EntityDataRow["DateCreated"];

                if (_EntityDataRow["Created_Employee_Id"] is DBNull)
                    _createdEmployeeId = 0;
                else
                    _createdEmployeeId = Convert.ToInt64(_EntityDataRow["Created_Employee_Id"]);

                if (_EntityDataRow["DateModified"] is DBNull)
                {
                }
                else
                {
                    _dateModified = (DateTime)_EntityDataRow["DateModified"];
                }

                if (_EntityDataRow["Modified_Employee_Id"] is DBNull)
                    _modifiedEmployeeId = 0;
                else
                    _modifiedEmployeeId = (long)_EntityDataRow["Modified_Employee_Id"];

                _isPackage = (bool)_EntityDataRow["IsPackage"];
                if(_EntityDataRow["UnitPrice"]!=DBNull.Value)
                    _unitPrice = Convert.ToDouble(_EntityDataRow["UnitPrice"]);
                

            }
        }
        #endregion

        #region Entity Properties
        double _unitPrice;
        public double UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

         string  _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        long _particularTypeId;
        public long ParticularTypeId
        {
            get { return _particularTypeId; }
            set { _particularTypeId = value; }
        }
        ParticularType _particularType;
        public ParticularType ProductType
        {
            get { return _particularType; }
            set { _particularType = value; }
        }

        DateTime _dateCreated;
        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set { _dateCreated = value; }
        }

        long _createdEmployeeId ;
        public long  CreatedEmployeeId
        {
            get { return _createdEmployeeId; }
            set { _createdEmployeeId = value; }
        }

        DateTime _dateModified ;
        public DateTime DateModified
        {
            get { return _dateModified; }
            set { _dateModified = value; }
        }

        long _modifiedEmployeeId;
        public long ModifiedEmployeeId 
        {
            get { return _modifiedEmployeeId; }
            set { _modifiedEmployeeId = value; }
        }

        bool _isPackage ;
        public bool IsPackage
        {
            get { return _isPackage; }
            set { _isPackage = value; }
        }

        Employee _employeeCreated;
        public Employee CreatedEmployee
        {
            get { return _employeeCreated; }
            set { _employeeCreated = value; }
        }
        Employee _employeeModified;
        public Employee ModifiedEmployee
        {
            get { return _employeeModified; }
            set { _employeeModified = value; }
        }

        List<ProductListDetails> _productListDetails=new List<ProductListDetails>();
        public List<ProductListDetails> ProductListDetails
        {
            get { return _productListDetails; }
            set { _productListDetails = value; }
        }

       
        #endregion



        #region IEntity Members

        

        #endregion

        #region IEntity Members

        public long Id
        {
            get
            {
               return _Id;
            }
            set
            {
                _Id = value;
            }
        }

       
        #endregion
    }
}
