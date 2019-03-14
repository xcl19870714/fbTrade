using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Trade_Models
{
    [Serializable]
    public class FbCustomerContactInfo
    {
        public int id;
		public string marketFbId;
        public string marketFbAccount;
        public string customerFbId;
        public string time;
        public string content;
    }
}
