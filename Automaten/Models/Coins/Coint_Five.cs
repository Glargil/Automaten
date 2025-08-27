using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten.Models.Coins
{
    public class Coint_Five: Coins
    {
        public Coint_Five()
        {
            this.Value = 5;
            this.Name = "5 KR";
        }
        public Coint_Five(int value, string name)
        {
            this.Value = value;
            this.Name = name;
        }
    }
}
