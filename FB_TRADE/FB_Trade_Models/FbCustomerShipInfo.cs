﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Trade_Models
{
    [Serializable]
    public class FbCustomerShipInfo
    {
        public int id;
        public string customerFbId;
        public string marketFbId;
        public string shipType;
        public string customerType;
        public string interestedGoods;
        public string note;
        public int trace;
        public string traceDate;
        public string lastEditTime;
    }
}
