using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten.Models;

namespace Automaten.Repository
{
    public class RowRepo : IRowRepo
    {
        public RowRepo()
        {
        }
        public void AddItem(Row row, Item itemToAdd)
        {
            row.ItemQueue.Enqueue(itemToAdd);
            Console.WriteLine(itemToAdd.Name + " added to row " + row.Slot);
        }

        public int GetItemPrice(Row row)
        {
            return row.ItemQueue.Peek().Price;
        }

        public Item EjectItem(Row row)
        {
            return row.ItemQueue.Dequeue();
        }

        public string RowToString(Row row)
        {
            return "Row: " + row.Slot + " contains " + row.ItemQueue.Count + " items.";
        }
    }
}

