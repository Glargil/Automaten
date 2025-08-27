using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten.Models
{
    public class VendingMachine
    {
        private int _id;
        private Row[] _rows;
        private Panel _panel;
        private CoinBank _coinBank;
        private Drawer _drawer;

        public int Id { get; set; }
        public Row[] Rows { get; set; }
        public Panel Panel { get; set; }
        public CoinBank CoinBank { get; set; }
        public Drawer Drawer { get; set; }

        public VendingMachine(int id, Panel panel, CoinBank coinBank, Drawer drawer, Row[] rows)
        {
            _id = id;
            _rows = rows;
            Rows = rows;
            for (int i = 0; i < Rows.Length; i++)
            {
                Rows[i] = new Row();
            }
            _panel = panel;
            _coinBank = coinBank;
            _drawer = drawer;
        }

    }
}
