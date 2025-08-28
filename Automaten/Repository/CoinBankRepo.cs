using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten.Models.Coins;

namespace Automaten.Repository
{
    public class CoinBankRepo: ICoinBankRepo
    {
        public List<Coin> BankedCoins { get; set; } = new List<Coin>();
        public CoinBankRepo()
        {
        }
        public void AddCoin(int coin)
        {
            if (coin == 1)
            {
                Coin_One oneKr = new Coin_One();
                BankedCoins.Add(oneKr);
            }
            else if (coin == 2)
            {
                Coin_Two twoKr = new Coin_Two();
                BankedCoins.Add(twoKr);
            }
            else if (coin == 5)
            {
                Coin_Five fiveKr = new Coin_Five();
                BankedCoins.Add(fiveKr);
            }
            else if (coin == 10)
            {
                Coin_Ten tenKr = new Coin_Ten();
                BankedCoins.Add(tenKr);
            }
            else if (coin == 20)
            {
                Coin_Twenty twentyKr = new Coin_Twenty();
                BankedCoins.Add(twentyKr);
            }
        }
    }
}
