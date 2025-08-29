using Automaten.Models;
using Automaten.Repository;
using Automaten.Service;
using Automaten.Models.Coins;

namespace Automaten
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Coin> CoinsToRemove = new List<Coin>();
            CoinsToRemove.Add(new Coin_Twenty());
            CoinsToRemove.Add(new Coin_Ten());
            CoinsToRemove.Add(new Coin_Five());

            foreach(var coin in CoinsToRemove)
            {
                Console.WriteLine(coin.Name);
            }


            // Initialize repositories
            IVendingMachineRepo vendingMachineRepo = new VendingMachineRepo();

            // Initialize vendingmachine service
            VendingMachineService vendingMachineService = new VendingMachineService(vendingMachineRepo);

            // Add coins to the coin bank
            vendingMachineService.AddCoin(20);
            vendingMachineService.AddCoin(10);
            vendingMachineService.AddCoin(5);
            vendingMachineService.AddCoin(2);
            vendingMachineService.AddCoin(1);


            // Stocks the vending machine with items
            Item cola = new Item("Cola", 20, 25);
            Item fanta = new Item("Fanta", 30, 35);
            Item snickers = new Item("Snickers", 15, 20);
            Item apple = new Item("Apple", 10, 15);
            Item water = new Item("Water", 5, 10);


            vendingMachineService.Refill();

            vendingMachineService.CoinBankReport();

            Console.WriteLine("DEBUG");
            vendingMachineService.CalculateChange(12);
            vendingMachineService.RemoveCoinsFromBank(CoinsToRemove);

            vendingMachineService.CoinBankReport();
        }

    }
}

