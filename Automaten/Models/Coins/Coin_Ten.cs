using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten.Models.Coins
{
    public class Coin_Ten:Coin
    {
        public Coin_Ten()
        {
            this.Value = 10;
            this.Name = "10 KR";
        }

        public Coin_Ten(int value, string name)
        {
            this.Value = value;
            this.Name = name;
        }
    }
}
