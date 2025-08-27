using Automaten.Models;

namespace Automaten
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Item cola = new Item("Cola", 20, 25);
            Item fanta = new Item("Fanta", 30, 35);
            Item snickers = new Item("Snickers", 15, 20);
            Item apple = new Item("Apple", 10, 15);
            Item water = new Item("Water", 5, 10);
            VendingMachine vendingMachine1 = new VendingMachine(new Panel("", 0, 0), new CoinBank(), new Row[4]);
            vendingMachine1.Rows[0].AddItem(cola);
            vendingMachine1.Rows[0].AddItem(cola);
            vendingMachine1.Rows[0].AddItem(cola);
            vendingMachine1.Rows[1].AddItem(fanta);
            vendingMachine1.Rows[1].AddItem(fanta);

            Console.WriteLine("Vending Machine Simulation");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Please enter the slot number of the item you wish to purchase.");
            Console.WriteLine("Available slots:");
            Console.WriteLine("0: Cola (25kr)");
            Console.WriteLine("1: Fanta PRIME(35kr)");
            Console.WriteLine("2: Snickers (20kr)");
            Console.WriteLine("3: Apple (15kr)");
            Console.WriteLine("4: Water (10kr)");

            int appRunning = 1;
            while (appRunning == 1)
            {
                int userSelectedSlot = int.Parse(Console.ReadLine());
                if (userSelectedSlot < 0 || userSelectedSlot > 4)
                {
                    Console.WriteLine("Invalid slot number. Please try again.");
                }
                else
                {
                    // Calculate total price of selected item ask to insert coins
                    Console.WriteLine("you have selected slot " + userSelectedSlot);
                    Console.WriteLine("The price of your selected item is " + vendingMachine1.Rows[userSelectedSlot].GetItemPrice() + "kr");
                    Console.WriteLine("Please insert coins (accepted coins: 1kr, 2kr, 5kr, 10kr, 20kr). Type 'done' when finished.");
                    int totalInsertedAmount = 0;
                    while (true)
                    {
                        string userInput = Console.ReadLine();
                        if (userInput.ToLower() == "done")
                        {
                            break;
                        }
                        int insertedCoin;
                        if (int.TryParse(userInput, out insertedCoin) && (insertedCoin == 1 || insertedCoin == 2 || insertedCoin == 5 || insertedCoin == 10 || insertedCoin == 20))
                        {
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
