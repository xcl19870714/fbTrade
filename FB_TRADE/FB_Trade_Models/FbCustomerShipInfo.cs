using System;
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
        public int shipType;
        public int customerType;
        public string interestedGoods;
        public string note;
        public string traceDate;
        public string createTime;
    }
}
