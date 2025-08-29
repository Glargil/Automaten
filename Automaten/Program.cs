using Automaten.Models;
using Automaten.Repository;
using Automaten.Service;
using Automaten.Models.Coins;
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
            Console.Clear();
            Console.WriteLine("Welcome to the Vending Machine!");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Please type the number of the Row that you would like to purchase from:");
            Console.WriteLine("Row 0: Soda 20 DKK.-");
            Console.WriteLine("Row 1: Chips 15 DKK.-");
            Console.WriteLine("Row 2: Candy 25 DKK.-");
            Console.WriteLine("Row 3: Water 30 DKK.-");
            Console.WriteLine("Row 4: Juice 20 DKK.-");
            Console.WriteLine("Row 5: Gum 50 DKK.-");
            Console.WriteLine("--------------------------------");
            int appRunning = 1;
            while (appRunning == 1)
            {
                //User selects slot
                int userSelectedSlot = int.Parse(Console.ReadLine());
                if (userSelectedSlot < 0 || userSelectedSlot > 5)
                {
                    Console.WriteLine("Invalid slot number. Please try again.");
                }
                else
                {
                    Console.WriteLine("Please insert " + vendingMachineService.GetItemPrice(userSelectedSlot) + " DKK.-");
                }
                Console.WriteLine("Please insert coins (accepted coins: 1, 2, 5, 10, 20). Type 'done' when finished.");
                //User inserts coins until done

                


                appRunning = 0;
            }
        }

            }
        }

