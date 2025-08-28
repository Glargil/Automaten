using System;
using System.Collections.Generic;
using Automaten.Models.Coins;
using Automaten.Models;

namespace Automaten.Repository
{
    public class VendingMachineRepo : IVendingMachineRepo
    {
        // Reference to the coin bank for this vending machine
        private CoinBank _coinBank;

        // Coin denominations in descending order
        private static readonly int[] CoinDenominations = { 20, 10, 5, 2, 1 };

        // Constructor: requires a CoinBank so we can update it
        public VendingMachineRepo(CoinBank coinBank)
        {
            _coinBank = coinBank;
        }

        public void Refill()
        {
            // Your refill logic here (not changed)
        }

        // Calculates the coins to return as change for a given amount
        public List<Coin> CalculateChange(int changeAmount)
        {
            List<Coin> result = new List<Coin>();
            int remaining = changeAmount;

            for (int d = 0; d < CoinDenominations.Length; d++)
            {
                int coinValue = CoinDenominations[d];
                int count = remaining / coinValue;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        Coin coin = CreateCoinByValue(coinValue);
                        if (coin != null)
                        {
                            result.Add(coin);
                        }
                    }
                    remaining -= coinValue * count;
                }
            }
            return result;
        }

        // Removes the coins in coinsToRemove from the coin bank
        public void RemoveCoinsFromBank(List<Coin> coinsToRemove)
        {
            for (int i = 0; i < coinsToRemove.Count; i++)
            {
                Coin coinToRemove = coinsToRemove[i];
                // Find the first coin in the bank with the same value
                for (int j = 0; j < _coinBank.BankedCoins.Count; j++)
                {
                    Coin bankCoin = _coinBank.BankedCoins[j];
                    if (bankCoin.Value == coinToRemove.Value)
                    {
                        _coinBank.BankedCoins.RemoveAt(j);
                        break; // Remove only one matching coin per coinToRemove
                    }
                }
            }
        }

        // Helper method to create Coin objects based on value
        private Coin CreateCoinByValue(int value)
        {
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
    }
}
