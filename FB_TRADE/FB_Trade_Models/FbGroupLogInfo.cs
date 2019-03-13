using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Trade_Models
{
    [Serializable]
    public class FbGroupLogInfo
    {
        public int id;
        public string groupFbId;
        public string marketFbId;
        public string marketFbAccount;
        public string time;
        public string logs;
    }
}
