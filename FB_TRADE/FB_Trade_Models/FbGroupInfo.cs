using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Trade_Models
{
    [Serializable]
    public class FbGroupInfo
    {
        public string fbId;
        public string name;
        public string fbUrl;
        public string membersNum;
        public string introduction;
        public string gpSource;
        public string gpType;
        public string needVerify;
    }
}
