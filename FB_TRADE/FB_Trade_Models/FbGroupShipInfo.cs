using System;
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
        public string customersNum;
        public string contactCustomersNum;
        public string tradeCustomersNum;
        public string ordersNum;
        public string tweetsNum;
        public string tweetFeedback;
        public string mark;
        public string note;
        public string lastEditTime;
    }
}
