using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten.Models.Coins
{
    public class Coin_Two:Coins
    {
        public Coin_Two()
        {
            this.Value = 2;
            this.Name = "2 KR";
        }
        public Coin_Two(int value, string name)
        {
            this.Value = value;
            this.Name = name;
        }
    }
}
