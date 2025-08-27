using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten.Models.Coins
{
    public class Coin_Twenty:Coin
    {
        public Coin_Twenty()
        {
            this.Value = 20;
            this.Name = "20 KR";
        }
        public Coin_Twenty(int value, string name)
        {
            this.Value = value;
            this.Name = name;
        }
    }
}
