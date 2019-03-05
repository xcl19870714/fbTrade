using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_TRADE
{
    public class ItemObject
    {
        public string Text;
        public string Value;
        public ItemObject(string _text, string _value)
        {
            Text = _text;
            Value = _value;
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
