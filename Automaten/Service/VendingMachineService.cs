using Automaten.Models;
using Automaten.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Automaten.Services
{
    public class VendingMachineService : IVendingMachineService
    {
        private readonly IVendingMachineRepository _repository;

        // Define the available coin denominations (descending order for optimal change)
        private static readonly int[] CoinDenominations = { 20, 10, 5, 2, 1 };

        // Define the items for refill (slot index to item)
        private readonly Dictionary<int, Item> _refillItems = new()
        {
            { 0, new Item("Cola", 20, 25) },
            { 1, new Item("Fanta", 30, 35) },
            { 2, new Item("Snickers", 15, 20) },
            { 3, new Item("Apple", 10, 15) },
            { 4, new Item("Water", 5, 10) }
        };

        public VendingMachineService(IVendingMachineRepository repository)
        {
            _repository = repository;
        }

        public bool TryPurchaseItem(int slot, List<int> insertedCoins, out string message, out Dictionary<int, int> change)
        {
            change = new Dictionary<int, int>();
            var vendingMachine = _repository.GetVendingMachine();

            // Validate slot
            if (slot < 0 || slot >= vendingMachine.Rows.Length)
            {
                message = "Invalid slot number.";
                return false;
            }

            var row = vendingMachine.Rows[slot];
            if (row.ItemQueue == null || row.ItemQueue.Count == 0)
            {
                message = "Selected item is out of stock.";
                return false;
            }

            int price = row.GetItemPrice();
            int totalInserted = insertedCoins.Sum();

            if (totalInserted < price)
            {
                message = $"Insufficient funds. Inserted: {totalInserted}kr, Price: {price}kr.";
                return false;
            }

            // Add coins to CoinBank and Panel
            foreach (var coin in insertedCoins)
            {
                vendingMachine.Panel.InsertCoin(coin);
                vendingMachine.CoinBank.AddCoin(coin);
            }

            // Dispense item
            var item = row.EjectItem();

            // Calculate change
            int changeAmount = totalInserted - price;
            if (changeAmount > 0)
            {
                change = CalculateOptimalChange(changeAmount);
                message = $"You bought {item.Name} for {price}kr. Change returned: {changeAmount}kr.";
            }
            else
            {
                message = $"You bought {item.Name} for {price}kr. No change needed.";
            }

            return true;
        }

        public void RefillAllRows()
        {
            var vendingMachine = _repository.GetVendingMachine();
            for (int i = 0; i < vendingMachine.Rows.Length; i++)
            {
                if (_refillItems.TryGetValue(i, out var item))
                {
                    // For simulation, refill each row with 5 items
                    for (int j = 0; j < 5; j++)
                    {
                        vendingMachine.Rows[i].AddItem(new Item(item.Name, item.Price, item.MarketPrice));
                    }
                }
            }
        }

        // Returns a dictionary of coin value to count (optimal change)
        private Dictionary<int, int> CalculateOptimalChange(int changeAmount)
        {
            var result = new Dictionary<int, int>();
            int remaining = changeAmount;
            foreach (var coin in CoinDenominations)
            {
                int count = remaining / coin;
                if (count > 0)
                {
                    result[coin] = count;
                    remaining -= coin * count;
                }
            }
            return result;
        }
    }
}
