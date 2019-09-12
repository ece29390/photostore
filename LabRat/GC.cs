using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
namespace LabRat
{
    [XmlRoot("GC")]
    public class GC
    {
        int _id;
        [XmlElement("Id")]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        string _code;
        [XmlElement("Code")]
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

    }
}
