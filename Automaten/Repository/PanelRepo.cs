using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten.Models;
using Automaten.Models.Coins;

namespace Automaten.Repository
{
    public class PanelRepo : IPanelRepo
    {
        public List<Coin> InsertedCoins { get; set; } = new List<Coin>();


        public void InsertCoin(int coin)
        {

            if (coin == 1)
            {
                Coin_One oneKr = new Coin_One();
                InsertedCoins.Add(oneKr);
            }
            else if (coin == 2)
            {
                Coin_Two twoKr = new Coin_Two();
                InsertedCoins.Add(twoKr);
            }
            else if (coin == 5)
            {
                Coin_Five fiveKr = new Coin_Five();
                InsertedCoins.Add(fiveKr);
            }
            else if (coin == 10)
            {
                Coin_Ten tenKr = new Coin_Ten();
                InsertedCoins.Add(tenKr);
            }
            else if (coin == 20)
            {
                Coin_Twenty twentyKr = new Coin_Twenty();
                InsertedCoins.Add(twentyKr);
            }

        }
        public int CalcTotal()
        {
            int total = 0;
            foreach (var coin in InsertedCoins)
            {
                total += coin.Value;
            }
            return total;
        }
    }
}
