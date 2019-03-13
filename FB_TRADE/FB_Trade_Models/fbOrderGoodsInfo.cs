using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Trade_Models
{
    [Serializable]
    public class fbOrderGoodsInfo
    {
        public int id;
        public string orderId;
        public byte[] photo;
        public string color;
        public string size;
        public string price;
        public string amount;
    }
}
