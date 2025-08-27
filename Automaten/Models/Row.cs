using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten.Models;

namespace Automaten.Models
{
    public class Row
    {
        private int _tempId = 0;
        private int _slot;
        private Queue<Item> _itemQueue;

        public int Slot { get; set; }
        public Queue<Item> ItemQueue { get; set; }

        public Row()
        {
            _slot = _tempId++;
            _itemQueue = new Queue<Item>();
        }

        public void AddItem(Item itemToAdd)
        { 
        _itemQueue.Enqueue(itemToAdd);
            Console.WriteLine(itemToAdd.Name + " added to row " + _slot);
        }

        public Item EjectItem()
        {
            Item ejectedItem = _itemQueue.Dequeue();
            return ejectedItem;
        }


        public string ToString()
        {
            return "Row: " + _slot + " contains " + _itemQueue.Count + " items.";
        }
    }
}
