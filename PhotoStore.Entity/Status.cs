using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoStore.Entity
{
    public enum StatusType { Unknown = 0, Issued, Redeemed }
    public class Status
    {
        public Status(int value,string description)
        {
            _value = value;
            _description = description;
        }

        string _description;
        public string Description
        {
            get { return _description; }
        }
        int _value;
        public int Value
        {
            get { return _value; }
        }

        public static List<Status> GetStatus
        {
            get
            {
                List<Status> status = new List<Status>();
                status.Add(new Status((int)StatusType.Unknown, ""));
                status.Add(new Status((int)StatusType.Issued, "Issued"));
                status.Add(new Status((int)StatusType.Redeemed, "Redeemed"));
                return status;
            }
        }

    }
}
