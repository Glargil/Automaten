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
    }

}
