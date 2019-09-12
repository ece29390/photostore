using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoStore.BusinessLogic
{
    public enum Direction
    {
        [BlEnumAttributes("ASC")]
        ASC,
        [BlEnumAttributes("DESC")]
        DESC
    }

    public class BlEnumAttributes : System.Attribute
    {
        string _description;
        public BlEnumAttributes(string description)
        {
            _description = description;
        }
        public string Description
        {
            get { return _description; }
        }
    }

    public static class EnumReader
    {
        public static string GetDescription(Enum enumeration)
        {
            Type type = enumeration.GetType();
            BlEnumAttributes enumAttrib = (BlEnumAttributes)type.GetField(enumeration.ToString()).GetCustomAttributes(false)[0];
            return  enumAttrib.Description;
        }
    }
}
