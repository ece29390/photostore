using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoStore.Entity
{
    public class PriviledgeCardCombo
    {
        long _id;
        string _priviledgedCard;
        public PriviledgeCardCombo(long id,
            string priviledgedcard)
        {
            _id = id;
            _priviledgedCard = priviledgedcard;
        }
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string PriviledgedCardCode
        {
            get { return _priviledgedCard; }
            set { _priviledgedCard = value; }
        }
    }
}
