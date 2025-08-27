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
        private int _price;

        public string Name { get; set; }
        public int MarketPrice { get; set; }
        public int Price { get; set; }

        public Item(string name, int marketPrice, int price)
        {
            _name = name;
            _marketPrice = marketPrice;
            _price = price;
        }
    }
}
