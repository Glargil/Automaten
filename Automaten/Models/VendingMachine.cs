using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten.Models
{
    public class VendingMachine
    {
        private static int _id = 0;

        public int Id { get; set; }
        public Row[] Rows { get; set; }
        public Panel Panel { get; set; }
        public CoinBank CoinBank { get; set; }

        public VendingMachine(Panel panel, CoinBank coinBank, Row[] rows)
        {
            _id = _id++;
            Rows = rows;
            for (int i = 0; i < Rows.Length; i++)
            {
                Rows[i] = new Row();
            }
            Panel = panel;
            CoinBank = coinBank;
        }

    }
}
