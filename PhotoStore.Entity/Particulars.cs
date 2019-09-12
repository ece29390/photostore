using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoStore.Entity
{
    public class Particulars
    {
        string _item;//,_signatureDate="",_signature="";
        int _quantity, _rejectedQuantity;
        public Particulars(string item
            ,int quantity,int rejectedquantity)
        {
            _item = item;
            _quantity = quantity;
            _rejectedQuantity = rejectedquantity;
        }
        public string Item
        {
            get { return _item; }
            set { _item = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public int RejectedQuantity
        {
            get { return _rejectedQuantity; }
            set { _rejectedQuantity = value; }
        }
        //public string SignatureDate
        //{
        //    get { return _signatureDate; }
        //    set { _signatureDate = value; }
        //}
        //public string Signature
        //{
        //    get { return _signature; }
        //    set { _signature = value; }
        //}
    }
}
