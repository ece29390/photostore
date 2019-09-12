using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace PhotoStore.Entity
{
    public class ParticularTypeView:ParticularType
    {
        public ParticularTypeView(DataRow dr) : base(dr) { }
        public string MultipleItemDescription
        {
            get
            {
                if (MultipleItems)
                {
                    return "True";
                }
                else
                {
                    return "False";
                }
            }
            set
            {
                if (value.ToUpper() == "TRUE")
                    MultipleItems = true;
                else
                    MultipleItems = false;
            }
        }
    }
}
