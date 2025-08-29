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

            // step 2: Add items to the vending machine
            #region Add items to the Vending Machine
            vendingMachineService.AddItem(0, new Item("Soda", 15, 20));
            vendingMachineService.AddItem(0, new Item("Soda", 15, 20));
            vendingMachineService.AddItem(0, new Item("Soda", 15, 20));
            vendingMachineService.AddItem(0, new Item("Soda", 15, 20));
            vendingMachineService.AddItem(0, new Item("Soda", 15, 20));
            vendingMachineService.AddItem(1, new Item("Chips", 10, 15));
            vendingMachineService.AddItem(1, new Item("Chips", 10, 15));
            vendingMachineService.AddItem(1, new Item("Chips", 10, 15));
            vendingMachineService.AddItem(1, new Item("Chips", 10, 15));
            vendingMachineService.AddItem(1, new Item("Chips", 10, 15));
            vendingMachineService.AddItem(2, new Item("Candy", 7, 25));
            vendingMachineService.AddItem(2, new Item("Candy", 7, 25));
            vendingMachineService.AddItem(2, new Item("Candy", 7, 25));
            vendingMachineService.AddItem(2, new Item("Candy", 7, 25));
            vendingMachineService.AddItem(2, new Item("Candy", 7, 25));
            vendingMachineService.AddItem(3, new Item("Water", 5, 30));
            vendingMachineService.AddItem(3, new Item("Water", 5, 30));
            vendingMachineService.AddItem(3, new Item("Water", 5, 30));
            vendingMachineService.AddItem(3, new Item("Water", 5, 30));
            vendingMachineService.AddItem(3, new Item("Water", 5, 30));
            vendingMachineService.AddItem(4, new Item("Juice", 12, 20));
            vendingMachineService.AddItem(4, new Item("Juice", 12, 20));
            vendingMachineService.AddItem(4, new Item("Juice", 12, 20));
            vendingMachineService.AddItem(4, new Item("Juice", 12, 20));
            vendingMachineService.AddItem(4, new Item("Juice", 12, 20));
            vendingMachineService.AddItem(5, new Item("Gum", 3, 50));
            #endregion


            // step 3: Add coins to the coin bank
            #region Add coins to the coin bank
            vendingMachineService.AddCoin(1);
            vendingMachineService.AddCoin(2);
            vendingMachineService.AddCoin(5);
            vendingMachineService.AddCoin(10);
            vendingMachineService.AddCoin(20);
            vendingMachineService.AddCoin(1);
            vendingMachineService.AddCoin(2);
            vendingMachineService.AddCoin(5);
            vendingMachineService.AddCoin(10);
            vendingMachineService.AddCoin(20);
            vendingMachineService.AddCoin(1);
            vendingMachineService.AddCoin(2);
            vendingMachineService.AddCoin(5);
            vendingMachineService.AddCoin(10);
            vendingMachineService.AddCoin(20);
            vendingMachineService.AddCoin(1);
            vendingMachineService.AddCoin(2);
            vendingMachineService.AddCoin(5);
            vendingMachineService.AddCoin(10);
            vendingMachineService.AddCoin(20);
            #endregion

            // Step 4: Start user interaction loop
            bool continueUsing = true;
            Console.WriteLine("Welcome to the Vending Machine!");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("/nMenu:");
            Console.WriteLine("1. Purchase Item");
            Console.WriteLine("2. Exit");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Please select an option (1-2):");

            int appRunning = 1;
            while (appRunning == 1)
            {
                // Get user input for slot selection
                int userSelectedSlot = int.Parse(Console.ReadLine());
                if (userSelectedSlot < 0  userSelectedSlot > 4)
                {
                    Console.WriteLine("Invalid slot number. Please try again.");
                }
                else
                {
                    // Calculate total price of selected item ask to insert coins
                    Console.WriteLine("you have selected slot " + userSelectedSlot);
                    Console.WriteLine("The price of your selected item is " + vendingMachineService.Rows[userSelectedSlot].GetItemPrice() + "kr");
                    Console.WriteLine("Please insert coins (accepted coins: 1kr, 2kr, 5kr, 10kr, 20kr). Type 'done' when finished.");

                    // Loop to accept coins until the total inserted amount meets or exceeds the item price
                    int totalInsertedAmount = 0;
                    while (true)
                    {
                        string userInput = Console.ReadLine();
                        if (userInput.ToLower() == "done")
                        {
                            break;
                        }

                        // Validate and process inserted coin
                        int insertedCoin;
                        if (int.TryParse(userInput, out insertedCoin) && (insertedCoin == 1  insertedCoin == 2  insertedCoin == 5  insertedCoin == 10 || insertedCoin == 20))
                        {
                            // Calculates the total inserted amount and updates the panel and coin bank
                            totalInsertedAmount += insertedCoin;
                            vendingMachine1.Panel.InsertCoin(insertedCoin);
                            vendingMachine1.CoinBank.AddCoin(insertedCoin);
                            Console.WriteLine("Total inserted amount: " + totalInsertedAmount + "kr");
                            if (totalInsertedAmount >= vendingMachine1.Rows[userSelectedSlot].GetItemPrice())
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid coin. Please insert a valid coin or type 'done' to finish.");
                        }
                    }


                    appRunning = 0;
                }

            }
        }
    }
}

