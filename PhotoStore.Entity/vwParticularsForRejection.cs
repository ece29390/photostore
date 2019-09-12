using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class vwParticularsForRejection:vwJobOrderItems
    {
        string _particularTypeCode, _particularCode;
        decimal _amount;
        bool _isRejected;
        public override string Lookup
        {
            get
            {
                return base.Lookup;
            }
        }

        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public string ParticularTypeCode
        {
            get { return _particularTypeCode; }
            set { _particularTypeCode = value; }
        }
        public string ParticularCode
        {
            get { return _particularCode; }
            set { _particularCode = value; }
        }
        public bool IsRejected
        {
            get { return _isRejected; }
            set { _isRejected = value; }
        }
        public vwParticularsForRejection(DataRow dr)
            : base(dr)
        {
            _particularTypeCode = dr["ParticularTypeCode"].ToString();
            _particularCode = dr["ParticularCode"].ToString();
            _amount = Convert.ToDecimal(dr["Amount"]);
            _isRejected = Convert.ToBoolean(dr["IsRejected"]);

        }
    }
}
