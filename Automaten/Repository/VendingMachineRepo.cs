using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten.Models.Coins;

namespace Automaten.Repository
{
    public class VendingMachineRepo : IVendingMachineRepo
    {
        // Define the available coin denominations (descending order for optimal change)
        private static readonly int[] CoinDenominations = { 20, 10, 5, 2, 1 };
        public void Refill()
        {

        }
        
public List<Coin> CalculateChange(int changeAmount)
        {
            var result = new List<Coin>();
            int remaining = changeAmount;

            foreach (var coinValue in CoinDenominations)
            {
                int count = remaining / coinValue;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        // Create a Coin object for each coin to be returned
                        Coin coin = CreateCoinByValue(coinValue);
                        if (coin != null)
                        {
                            result.Add(coin);
                        }
                    }
                    remaining -= coinValue * count;
                }
            }
            // TESTING
            foreach (var coin in result)
            {
                Console.WriteLine($"Denomination: {coin.Value}, Name: {coin.Name}");
            }

            return result;
        }

        // Helper method to create Coin objects based on value
        private Coin CreateCoinByValue(int value)
        {
            // Replace with your actual Coin subclasses if available
            switch (value)
            {
                case 20: return new Coin_Twenty();
                case 10: return new Coin_Ten();
                case 5: return new Coin_Five();
                case 2: return new Coin_Two();
                case 1: return new Coin_One();
                default: return null;
            }
        }
        public void RemoveCoinsFromBank(List<Coin> coinsToRemove)
        {

        }
    }
}
