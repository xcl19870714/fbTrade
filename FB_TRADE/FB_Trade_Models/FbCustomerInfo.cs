﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Trade_Models
{
    [Serializable]
    public class FbCustomerInfo
    {
        public string fbId;
        public string name;
        public string fbUrl;
        public int friendsNum;
        public string country;
        public string state;
        public string city;
        public string email;
        public string introduction;
    }
}