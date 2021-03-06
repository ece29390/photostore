using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;
namespace PhotoStore.Entity
{
    [Serializable]
    public class GiftCertificate : BaseEntity, IEntity, IParticularEntity
    {
       
        public GiftCertificate()
        {
        }

        public GiftCertificate(DataRow dr)
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
                if (_EntityDataRow["UnitPrice"] != DBNull.Value)
                {
                    double.TryParse(_EntityDataRow["UnitPrice"].ToString(), out _UnitPrice);
                    
                }
                _GiftCertificateTypeId = Convert.ToInt64(_EntityDataRow["GiftCertificateTypeId"]);
                _GiftCertificateStatusId = Convert.ToInt64(_EntityDataRow["GiftCertificateStatusId"]);

                _ExpirationDate = null;
                if (_EntityDataRow["ExpirationDate"].GetType() != typeof(DBNull))
                    _ExpirationDate = Convert.ToDateTime(_EntityDataRow["ExpirationDate"]);
                else
                {
                    if (_Id == -1)
                    {
                        _ExpirationDate = DateTime.Now.AddMonths(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["autogcadd"]));
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
                _isComplementary = Convert.ToBoolean(_EntityDataRow["IsComplementary"]);
            }
        }
        #endregion

        #region Entity Properties
        
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

        private long _GiftCertificateTypeId = -1;
        [XmlElement("GiftCertificateTypeId")]
        public long GiftCertificateTypeId
        {
            get { return _GiftCertificateTypeId; }
            set { _GiftCertificateTypeId = value; }
        }
        private GiftCertificateType _GiftCertificateType = null;
        [XmlIgnore()]
        public GiftCertificateType GiftCertificateType
        {
            get { return _GiftCertificateType; }
            set { _GiftCertificateType = value; }
        }

        private long _GiftCertificateStatusId = -1;
        [XmlElement("GiftCertificateStatusId")]
        public long GiftCertificateStatusId
        {
            get { return _GiftCertificateStatusId; }
            set { _GiftCertificateStatusId = value; }
        }
        string _issuedTo;
        [XmlElement("IssuedTo")]
        public string IssuedTo
        {
            get { return _issuedTo; }
            set { _issuedTo = value; }
        }
        DateTime? _issuedDate;
        [XmlElement("IssuedDate")]
        public DateTime? IssuedDate
        {
            get { return _issuedDate; }
            set { _issuedDate = value; }
        }
        string _redeemedBy;
        [XmlElement("RedeemedBy")]
        public string RedeemedBy
        {
            get { return _redeemedBy; }
            set { _redeemedBy = value; }
        }
        DateTime? _redeemedDate;
        [XmlElement("RedeemedDate")]
        public DateTime? RedeemedDate
        {
            get { return _redeemedDate; }
            set { _redeemedDate = value; }
        }


        private GiftCertificateStatus _GiftCertificateStatus = null;
        [XmlIgnore()]
        public GiftCertificateStatus GiftCertificateStatus
        {
            get { return _GiftCertificateStatus; }
            set { _GiftCertificateStatus = value; }
        }

        private Nullable<DateTime> _ExpirationDate=null;
        [XmlElement("ExpirationDate")]
        public Nullable<DateTime> ExpirationDate
        {
            get { return _ExpirationDate; }
            set { _ExpirationDate = value; }
        }
        string _giftCertificateStatusCode;
        [XmlIgnore()]
        public string GiftCertificateStatusCode
        {
            get { return _giftCertificateStatusCode; }
            set { _giftCertificateStatusCode = value; }
        }
        string _giftCertificateTypeCode;
        [XmlIgnore()]
        public string GiftCertificateTypeCode
        {
            get { return _giftCertificateTypeCode; }
            set { _giftCertificateTypeCode = value; }
        }
        private DateTime _DateLastModified;
        [XmlElement("DateLastModified")]
        public DateTime DateLastModified
        {
            get { return _DateLastModified; }
            set { _DateLastModified = value; }
        }

        long _productListId=-1;
        [XmlElement("ProductListId")]
        public long ProductListId
        {
            get { return _productListId; }
            set { _productListId = value; }
            
        }

        bool _isConsumed;
        [XmlElement("IsConsumed")]
        public bool IsConsumed
        {
            get { return _isConsumed; }
            set { _isConsumed = value; }
        }

        bool _isComplementary;
        [XmlElement("IsComplementary")]
        public bool IsComplementary
        {
            get { return _isComplementary; }
            set { _isComplementary = value; }
        }


        #endregion

        
    }
}
