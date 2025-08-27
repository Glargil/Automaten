using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten.Models.Coins
{
    public class Coin_One:Coin
    {
        public Coin_One()
        {
            this.Value = 1;
            this.Name = "1 KR";
        }
        public Coin_One(int value, string name)
        {
            this.Value = value;
            this.Name = name;
        }
    }
}
