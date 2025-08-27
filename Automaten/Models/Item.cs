using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten.Models
{
    public class Item
    {
        private string _name;
        private int _marketPrice;

        public string Name { get; set; }
        public int MarketPrice { get; set; }

        public Item(string name, int marketPrice)
        {
            Name = name;
            MarketPrice = marketPrice;
        }
    }
}
