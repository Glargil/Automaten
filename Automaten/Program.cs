using Automaten.Models;
using Automaten.Repositories;
using Automaten.Services;
using System;
using System.Collections.Generic;

namespace Automaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a vending machine with 5 rows (to match the 5 slots)
            var vendingMachine = new VendingMachine(new Panel("", 0, 0), new CoinBank(), new Row[5]);
            for (int i = 0; i < vendingMachine.Rows.Length; i++)
            {
                vendingMachine.Rows[i] = new Row();
            }

            // Set up repository and service
            var repository = new VendingMachineRepository(vendingMachine);
            var service = new VendingMachineService(repository);

            // Initial refill
            service.RefillAllRows();
            Console.Clear();
            Console.WriteLine("Vending Machine Simulation");
            Console.WriteLine("--------------------------");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Buy an item");
                Console.WriteLine("2. Refill all rows");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
                var menuInput = Console.ReadLine();

                switch (menuInput)
                {
                    case "1":
                        Console.WriteLine("Available slots:");
                        Console.WriteLine("0: Cola (25kr)");
                        Console.WriteLine("1: Fanta (35kr)");
                        Console.WriteLine("2: Snickers (20kr)");
                        Console.WriteLine("3: Apple (15kr)");
                        Console.WriteLine("4: Water (10kr)");
                        Console.Write("Please enter the slot number of the item you wish to purchase: ");
                        if (!int.TryParse(Console.ReadLine(), out int userSelectedSlot))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            break;
                        }

                        // Get item price for the selected slot
                        var vm = repository.GetVendingMachine();
                        if (userSelectedSlot < 0 || userSelectedSlot >= vm.Rows.Length)
                        {
                            Console.WriteLine("Invalid slot number. Please try again.");
                            break;
                        }

                        int itemPrice = vm.Rows[userSelectedSlot].GetItemPrice();
                        Console.WriteLine($"You have selected slot {userSelectedSlot}.");
                        Console.WriteLine($"The price of your selected item is {itemPrice}kr.");
                        Console.WriteLine("Please insert coins (accepted coins: 1kr, 2kr, 5kr, 10kr, 20kr). Type 'done' when finished.");

                        var insertedCoins = new List<int>();
                        while (true)
                        {
                            string userInput = Console.ReadLine();
                            if (userInput.ToLower() == "done")
                                break;

                            if (int.TryParse(userInput, out int insertedCoin) &&
                                (insertedCoin == 1 || insertedCoin == 2 || insertedCoin == 5 || insertedCoin == 10 || insertedCoin == 20))
                            {
                                insertedCoins.Add(insertedCoin);
                                int total = 0;
                                foreach (var c in insertedCoins) total += c;
                                Console.WriteLine($"Total inserted amount: {total}kr");
                                if (total >= itemPrice)
                                    break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid coin. Please insert a valid coin or type 'done' to finish.");
                            }
                        }

                        // Try to purchase item via service
                        if (service.TryPurchaseItem(userSelectedSlot, insertedCoins, out string message, out Dictionary<int, int> change))
                        {
                            Console.WriteLine(message);
                            if (change.Count > 0)
                            {
                                Console.WriteLine("Change given:");
                                foreach (var kvp in change)
                                {
                                    Console.WriteLine($"{kvp.Value} x {kvp.Key}kr");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(message);
                        }
                        break;

                    case "2":
                        service.RefillAllRows();
                        Console.WriteLine("All rows refilled.");
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

            Console.WriteLine("Thank you for using the vending machine simulation!");
        }
    }
}
