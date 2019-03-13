﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Trade_Models
{
    [Serializable]
    public class FbGroupShipInfo
    {
        public int id;
        public string groupFbId;
        public string marketFbId;
        public string status;
        public int customers;
        public int contactCustomers;
        public int tradeCustomers;
        public int orders;
        public int tweets;
        public int tweetFeedback;
        public string mark;
        public string note;
    }
}