using Automaten.Models;
using Automaten.Repository;
using Automaten.Service;
using Automaten.Models.Coins;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace Automaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Initialize repositories and services
            IVendingMachineRepo vendingMachineRepo = new VendingMachineRepo();
            VendingMachineService vendingMachineService = new VendingMachineService(vendingMachineRepo);

            vendingMachineService.AddItem(0, new Item("Soda", 15, 20));
            vendingMachineService.AddItem(1, new Item("Chips", 10, 15));
          


            //// Step 3: Add coins to the coin bank
            //vendingMachineService.AddCoin(20);
            //vendingMachineService.AddCoin(10);
            //vendingMachineService.AddCoin(5);
            //vendingMachineService.AddCoin(2);
            //vendingMachineService.AddCoin(1);

            //// Step 4: Show initial coin bank report
            //Console.WriteLine("Initial Coin Bank Report:");
            //vendingMachineService.CoinBankReport();

            //// Step 5: Simulate removing some coins
            //List<Coin> CoinsToRemove = new List<Coin>
            //    {
            //        new Coin_Twenty(),
            //        new Coin_Ten(),
            //        new Coin_Five()
            //    };

            //Console.WriteLine("Removing coins:");
            //foreach (var coin in CoinsToRemove)
            //{
            //    Console.WriteLine(coin.Name);
            //}
            //vendingMachineService.RemoveCoinsFromBank(CoinsToRemove);

            //// Step 6: Simulate a purchase and change calculation
            //Console.WriteLine("Simulating purchase and change calculation:");
            //vendingMachineService.CalculateChange(12);

            //// Step 7: Show final coin bank report
            //Console.WriteLine("Final Coin Bank Report:");
            //vendingMachineService.CoinBankReport();
        }
    }
}

