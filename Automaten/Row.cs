using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    class Row
    {
        private string _slot;
        private int _price;
        private Queue<Item> _currentItem;

        public Row() { }

        public Item EjectItem()
        {
            // ? ? ?? 
            _currentItem.Dequeue();
        }
    }
}
