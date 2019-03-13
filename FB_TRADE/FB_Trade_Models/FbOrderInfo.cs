using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Trade_Models
{
    [Serializable]
    public class FbOrderInfo
    {
        public string orderId;
        public string customerFbId;
        public string marketFbId;
        public string orderType;
        public string oriOrderId;
        public string createTime;
        public string lastEditTime;
        public string status;
        public string shippingAddress;
        public string shippingName;
        public string shippingPhone;
        public string shippingType;
        public string shippingFee;
        public string shippingNo;
        public string currency;
        public string totalPrice;
        public string paymentType;
        public string paymentNo;
        public string note;
    }
}
