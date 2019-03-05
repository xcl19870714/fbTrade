using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbTrade.Models
{
    [Serializable]
    public class AdminInfo
    {
        private int _id;
        private string _name = string.Empty;
        private string _pwd = string.Empty;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Pwd { get => _pwd; set => _pwd = value; }
        
    }
}
