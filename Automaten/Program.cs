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
            IVendingMachineRepo vendingMachineRepo = new VendingMachineRepo();
            VendingMachineService vendingMachineService = new VendingMachineService(vendingMachineRepo);

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

            #region Add coins to the coin bank
            vendingMachineService.AddCoin(1);
            vendingMachineService.AddCoin(2);
            vendingMachineService.AddCoin(5);
            vendingMachineService.AddCoin(10);
            vendingMachineService.AddCoin(1);
            vendingMachineService.AddCoin(2);
            vendingMachineService.AddCoin(5);
            #endregion

            int appRunning = 1;
            do
            {
                try
                {
                    Console.Clear();
                    vendingMachineService.CoinBankReport();
                    Console.WriteLine();
                    vendingMachineService.RowReport();

                    Console.WriteLine("Are you a customer or an administrator? Type 'customer' or 'admin'.");
                    string userType = Console.ReadLine();
                    if (userType == "customer")
                    {
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
                        string userInput = Console.ReadLine();
                        if (!int.TryParse(userInput, out int userSelectedSlot))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            Thread.Sleep(2000);
                            continue;
                        }

                        if (userSelectedSlot == 9)
                        {
                            appRunning = 0;
                            Console.WriteLine("Exiting application. Goodbye!");
                            break;
                        }

                        if (userSelectedSlot < 0 || userSelectedSlot >= 5)
                        {
                            Console.WriteLine("Invalid slot number. Please try again.");
                            Thread.Sleep(2000);
                            continue;
                        }

                        Row selectedRow;
                        try
                        {
                            selectedRow = vendingMachineService.GetRow(userSelectedSlot);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error accessing row: {ex.Message}");
                            Thread.Sleep(2000);
                            continue;
                        }

                        if (selectedRow.ItemQueue.Count < 1)
                        {
                            Console.WriteLine("Selected row is empty. Please choose another row.");
                            Thread.Sleep(2000);
                            continue;
                        }

                        int itemPrice;
                        try
                        {
                            itemPrice = vendingMachineService.GetItemPrice(userSelectedSlot);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error getting item price: {ex.Message}");
                            Thread.Sleep(2000);
                            continue;
                        }

                        Console.WriteLine("Please insert " + itemPrice + " DKK.-");

                        int[] acceptedCoins = { 1, 2, 5, 10, 20 };
                        int insertedCoins = 0;
                        List<int> userCoins = new List<int>();

                        while (insertedCoins < itemPrice)
                        {
                            Console.WriteLine($"Amount remaining: {itemPrice - insertedCoins} DKK. Insert coin (accepted: 1, 2, 5, 10, 20):");
                            string input = Console.ReadLine();
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
                        int change = insertedCoins - itemPrice;

                        foreach (var coinValue in userCoins)
                        {
                            vendingMachineService.AddCoin(coinValue);
                        }

                        if (change > 0)
                        {
                            List<Coin> changeCoins;
                            try
                            {
                                changeCoins = vendingMachineService.CalculateChange(change);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error calculating change: {ex.Message}");
                                changeCoins = new List<Coin>();
                            }

                            Console.WriteLine("CoinBank total before change has been removed: ");
                            vendingMachineService.CoinBankReport();

                            try
                            {
                                vendingMachineService.RemoveCoinsFromBank(changeCoins);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error removing coins from bank: {ex.Message}");
                            }

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

                        try
                        {
                            vendingMachineService.EjectItem(userSelectedSlot);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error dispensing item: {ex.Message}");
                        }

                        vendingMachineService.RowReport();
                        Console.WriteLine();
                        Console.WriteLine("Thank you for your purchase!");
                        Console.WriteLine("Returning to main menu in 5 seconds...");
                        Thread.Sleep(5000);
                        Console.Clear();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    Console.WriteLine("Returning to main menu in 5 seconds...");
                    Thread.Sleep(5000);
                }
            } while (appRunning == 1);
        }
        }
    }

