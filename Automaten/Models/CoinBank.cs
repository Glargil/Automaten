using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten.Models
{
    public class CoinBank
    {

        public List<Coins.Coin> BankedCoins { get; set; } = new List<Coins.Coin>();

        public CoinBank()
        { 
        }
    }
}
