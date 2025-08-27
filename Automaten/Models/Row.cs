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
        private static int _tempId = 0;

        public int Slot { get; set; }
        public Queue<Item> ItemQueue { get; set; }

        public Row()
        {
            Slot = _tempId++;
            ItemQueue = new Queue<Item>();
        }

        public void AddItem(Item itemToAdd)
        { 
        ItemQueue.Enqueue(itemToAdd);
            Console.WriteLine(itemToAdd.Name + " added to row " + Slot);
        }
        public int GetItemPrice()
        {
            return ItemQueue.Peek().Price;
        }
        public Item EjectItem()
        {
            Item ejectedItem = ItemQueue.Dequeue();
            return ejectedItem;
        }
        public override string ToString()
        {
            return "Row: " + Slot + " contains " + ItemQueue.Count + " items.";
        }
    }
}
