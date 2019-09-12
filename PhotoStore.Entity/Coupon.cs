using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Data;
namespace PhotoStore.Entity
{
    [Serializable]
    public class Coupon : BaseEntity, IEntity, IParticularEntity
    {
        public Coupon()
        {
        }

        public Coupon(DataRow dr)
        {

            EntityDataRow = dr;
        }

        #region BaseEntity Overrides
        [XmlIgnore()]
        public override string Lookup
        {
            get { return _Code + "-" + _Description; }
        }
        #endregion

        #region IEntity Implementations
        private DataRow _EntityDataRow;
        [XmlIgnore()]
        public DataRow EntityDataRow
        {
            get { return _EntityDataRow; }
            set
            {
                _EntityDataRow = value;

                _Id = Convert.ToInt64(_EntityDataRow["Id"]);
                _Code = (string)_EntityDataRow["Code"];
                _Description = (string)_EntityDataRow["Description"];
                _UnitPrice = Convert.ToDouble(_EntityDataRow["UnitPrice"]);
                //_CouponTypeId = Convert.ToInt32(_EntityDataRow["CouponTypeId"]);
                _CouponStatusId = Convert.ToInt64(_EntityDataRow["CouponStatusId"]);

                _ExpirationDate = null;
                if (_EntityDataRow["ExpirationDate"].GetType() != typeof(DBNull))
                    _ExpirationDate = Convert.ToDateTime(_EntityDataRow["ExpirationDate"]);
                else
                {
                    if (_Id == -1)
                    {
                        _ExpirationDate = DateTime.Now.AddMonths(
                            Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["autocouponadd"]));
                    }
                }
                _DateLastModified = (DateTime)_EntityDataRow["DateLastModified"];
                _productListId = Convert.ToInt64(_EntityDataRow["ProductListId"]);

                if (_EntityDataRow["IssuedDate"] != DBNull.Value)
                    _issuedDate = Convert.ToDateTime(_EntityDataRow["IssuedDate"]);

                if (_EntityDataRow["IssuedTo"] != DBNull.Value)
                    _issuedTo = _EntityDataRow["IssuedTo"].ToString();

                if (_EntityDataRow["RedeemedDate"] != DBNull.Value)
                    _redeemedDate = Convert.ToDateTime(_EntityDataRow["RedeemedDate"]);

                if (_EntityDataRow["RedeemedBy"] != DBNull.Value)
                    _redeemedBy = _EntityDataRow["RedeemedBy"].ToString();

                _isConsumed = Convert.ToBoolean(_EntityDataRow["IsConsumed"]);
            
            }
        }
        #endregion

        #region Entity Properties
        bool _isConsumed;
        [XmlElement("IsConsumed")]
        public bool IsConsumed
        {
            get { return _isConsumed; }
            set { _isConsumed = value; }
        }
        DateTime? _issuedDate;
        [XmlElement("IssueDate")]
        public DateTime? IssuedDate
        {
            get { return _issuedDate; }
            set { _issuedDate = value; }
        }
        string _issuedTo;
        [XmlElement("IssuedTo")]
        public string IssuedTo
        {
            get { return _issuedTo; }
            set { _issuedTo = value; }
        }
        DateTime? _redeemedDate;
        [XmlElement("RedeemedDate")]
        public DateTime? RedeemedDate
        {
            get { return _redeemedDate; }
            set { _redeemedDate = value; }
        }
        string _redeemedBy;
        [XmlElement("RedeemedBy")]
        public string RedeemedBy
        {
            get { return _redeemedBy; }
            set { _redeemedBy = value; }
        }
        private string _Code = "";
        [XmlElement("Code")]
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        private string _Description = "";
        [XmlElement("Description")]
        public string Description
        {
            get 
            {
                if (!string.IsNullOrEmpty(_Description))
                    return _Description;
                else
                    return System.Configuration.ConfigurationManager.AppSettings["defaultdescription"].ToString();
            }
            set { _Description = value; }
        }

        private double _UnitPrice = 0;
        [XmlElement("UnitPrice")]
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        private long _CouponTypeId = -1;
        [XmlElement("CouponTypeId")]
        public long CouponTypeId
        {
            get { return _CouponTypeId; }
            set { _CouponTypeId = value; }
        }
        //private CouponType _CouponType = null;
        //public CouponType CouponType
        //{
        //    get { return _CouponType; }
        //    set { _CouponType = value; }
        //}

        private long _CouponStatusId = -1;
        [XmlElement("CouponStatusId")]
        public long CouponStatusId
        {
            get { return _CouponStatusId; }
            set { _CouponStatusId = value; }
        }
        long _productListId = -1;
        [XmlElement("ProductListId")]
        public long ProductListId
        {
            get { return _productListId; }
            set { _productListId = value; }

        }
        private CouponStatus _CouponStatus = null;
        [XmlIgnore()]
        public CouponStatus CouponStatus
        {
            get { return _CouponStatus; }
            set { _CouponStatus = value; }
        }
        string _couponStatusCode;
        [XmlIgnore()]
        public string CouponStatusCode
        {
            get { return _couponStatusCode; }
            set { _couponStatusCode = value; }
        }

        private Nullable<DateTime> _ExpirationDate = null;
        [XmlElement("ExpirationDate")]
        public Nullable<DateTime> ExpirationDate
        {
            get { return _ExpirationDate; }
            set { _ExpirationDate = value; }
        }

        private DateTime _DateLastModified;
        [XmlElement("DateLastModified")]
        public DateTime DateLastModified
        {
            get { return _DateLastModified; }
            set { _DateLastModified = value; }
        }


        #endregion
    }
}
