using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten.Models
{
    class Row
    {
        private string _slot;
        private int _price;
        private Queue<Item> _currentItem;

        public Row() 
        
        { }

        public Item EjectItem()
        {
            Item ejectedItem = _currentItem.Dequeue();
            return ejectedItem;
        }
    }
}
