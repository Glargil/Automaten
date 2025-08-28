using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten.Models.Coins;

namespace Automaten.Models
{
    public class CoinBank
    {

        public List<Coins.Coin> BankedCoins { get; set; } = new List<Coins.Coin>();

        public CoinBank()
        { 
        }

        



        public void CoinBankReport()
        {
            //foreach (Coin coin in BankedCoins)
            //{
            //    Console.WriteLine ("CoinBank contains " + coin.Name + " coins.");
            //}
        }
    }
}
