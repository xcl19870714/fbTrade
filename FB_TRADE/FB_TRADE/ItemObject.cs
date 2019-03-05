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
        public int Value;
        public ItemObject(string _text, int _value)
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
