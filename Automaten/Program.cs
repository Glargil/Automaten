using Automaten.Models;
using Automaten.Repository;
using Automaten.Service;
using Automaten.Models.Coins;
using Automaten.Models;
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
            vendingMachineService.AddItem(2, new Item("Candy", 7, 25));
            vendingMachineService.AddItem(2, new Item("Candy", 7, 25));
            vendingMachineService.AddItem(3, new Item("Water", 5, 30));
            vendingMachineService.AddItem(3, new Item("Water", 5, 30));
            vendingMachineService.AddItem(3, new Item("Water", 5, 30));
            vendingMachineService.AddItem(3, new Item("Water", 5, 30));
            #endregion

            // step 3: Add coins to the coin bank
            #region Add coins to the coin bank
            vendingMachineService.AddCoin(1);
            vendingMachineService.AddCoin(2);
            vendingMachineService.AddCoin(5);
            vendingMachineService.AddCoin(10);
            vendingMachineService.AddCoin(1);
            vendingMachineService.AddCoin(2);
            vendingMachineService.AddCoin(5);
            #endregion

            // Step 4: Start user interaction loop
            int appRunning = 1;
            do
            {
                Console.Clear();
                //CoinBankReport method prints every coin object currently in the coinBank
                vendingMachineService.CoinBankReport();
                Console.WriteLine();
                //RowReport method prints the current status of each row in the vending machine
                vendingMachineService.RowReport();

                Console.WriteLine();
                Console.WriteLine("Welcome to the Magnus&Egil Vending Machine! :D");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Please type the number of the Row that you would like to purchase from:");
                Console.WriteLine("Row 0: Soda 20 DKK.-");
                Console.WriteLine("Row 1: Chips 15 DKK.-");
                Console.WriteLine("Row 2: Candy 25 DKK.-");
                Console.WriteLine("Row 3: Water 30 DKK.-");
                Console.WriteLine("Row 4: Juice 20 DKK.-");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Type '9' to exit the application.");
                Console.WriteLine("--------------------------------");

                //User selects slot
                int userSelectedSlot = int.Parse(Console.ReadLine());
                if (userSelectedSlot == 9)
                {
                    appRunning = 0;
                    Console.WriteLine("Exiting application. Goodbye!");
                    break;
                }

                if (userSelectedSlot < 0 || userSelectedSlot >= 5)
                {
                    Console.WriteLine("Invalid slot number. Please try again.");
                    continue;
                }
                if (vendingMachineService.GetRow(userSelectedSlot).ItemQueue.Count < 1)
                {
                    Console.WriteLine("Selected row is empty. Please choose another row.");
                    continue;
                }
                int itemPrice = vendingMachineService.GetItemPrice(userSelectedSlot);
                Console.WriteLine("Please insert " + itemPrice + " DKK.-");

                //User inserts coins

                //array containing accepted coins
                int[] acceptedCoins = { 1, 2, 5, 10, 20 };
                //variable to keep track of the total amount of coins inserted by the user
                int insertedCoins = 0;
                //variable to store the coins inserted by the user
                List<int> userCoins = new List<int>();

                while (insertedCoins < itemPrice)
                {
                    Console.WriteLine($"Amount remaining: {itemPrice - insertedCoins} DKK. Insert coin (accepted: 1, 2, 5, 10, 20):");
                    string input = Console.ReadLine();
                    //checks if the input is a valid integer and if it is one of the accepted coins
                    if (int.TryParse(input, out int coinValue) && acceptedCoins.Contains(coinValue))
                    {
                        insertedCoins += coinValue;
                        userCoins.Add(coinValue);
                        Console.WriteLine($"Inserted {coinValue} DKK.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid coin. Accepted coins are: 1, 2, 5, 10, 20.");
                    }
                }
                //variable to store the change amount to be returned later
                int change = insertedCoins - itemPrice;

                // Step 3: Add coins to CoinBank
                foreach (var coinValue in userCoins)
                {
                    vendingMachineService.AddCoin(coinValue);
                }

                //Dispense change if needed
                if (change > 0)
                {
                    List<Coin> changeCoins = vendingMachineService.CalculateChange(change);
                    Console.WriteLine("CoinBank total before change has been removed: ");
                    vendingMachineService.CoinBankReport();
                    vendingMachineService.RemoveCoinsFromBank(changeCoins);
                    Console.WriteLine("CoinBank total after change has been removed: ");
                    vendingMachineService.CoinBankReport();
                    if (changeCoins.Count > 0)
                    {
                        Console.WriteLine("Your change:");
                        foreach (var coin in changeCoins)
                        {
                            Console.WriteLine($"{coin.Value} DKK");
                        }
                    }
                    else
                    {
                        vendingMachineService.CoinBankReport();
                        Console.WriteLine("No change to dispense.");
                    }
                }
                else
                {
                    vendingMachineService.CoinBankReport();
                    Console.WriteLine("No change to dispense.");
                }
                vendingMachineService.EjectItem(userSelectedSlot);
                vendingMachineService.RowReport();
                Console.WriteLine();
                Console.WriteLine("Thank you for your purchase!");
                Console.WriteLine("Returning to main menu in 5 seconds...");
                Thread.Sleep(5000);
                Console.Clear();
            } while (appRunning == 1);

        }
    }
}
        

