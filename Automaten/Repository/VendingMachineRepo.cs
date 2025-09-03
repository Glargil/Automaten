using System;
using System.Collections.Generic;
using Automaten.Models.Coins;
using Automaten.Models;

namespace Automaten.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Automaten.Repository.IVendingMachineRepo" />
    public class VendingMachineRepo : IVendingMachineRepo
    {
        // List to hold the coins in the coin bank
        /// <summary>
        /// Gets or sets the banked coins.
        /// </summary>
        /// <value>
        /// The banked coins.
        /// </value>
        public List<Coin> BankedCoins { get; set; } = new List<Coin>();

        // List to hold the coins inserted by the user
        /// <summary>
        /// Gets or sets the inserted coins.
        /// </summary>
        /// <value>
        /// The inserted coins.
        /// </value>
        public List<Coin> InsertedCoins { get; set; } = new List<Coin>();

        // Coin denominations in descending order
        /// <summary>
        /// The coin denominations
        /// </summary>
        private static readonly int[] CoinDenominations = { 20, 10, 5, 2, 1 };

        // Array of rows in the vending machine
        /// <summary>
        /// Gets or sets the rows.
        /// </summary>
        /// <value>
        /// The rows.
        /// </value>
        public Row[] Rows { get; set; } = new Row[5];

        /// <summary>
        /// Initializes a new instance of the <see cref="VendingMachineRepo"/> class.
        /// </summary>
        public VendingMachineRepo()
        {
            for (int i = 0; i < Rows.Length; i++)
            {
                Rows[i] = new Row();
            }
        }


        // ###################################################
        // ############# Vending Machine Methods #############
        // ###################################################


        /// <summary>
        /// Refills this instance.
        /// </summary>
        public void Refill()
        {
            // Print all items in the machine prior to refill
            Console.WriteLine("Items in the machine prior to refill:");
            for (int i = 0; i < Rows.Length; i++)
            {
                Console.Write($"Row {i + 1}: ");
                foreach (var item in Rows[i].ItemQueue)
                {
                    Console.Write($"{item.Name} ");
                }
                Console.WriteLine();
            }

            // Define the items for each row
            Item[] items = new Item[]
            {
                new Item("Cola", 20, 25),
                new Item("Fanta", 30, 35),
                new Item("Snickers", 15, 20),
                new Item("Apple", 10, 15),
                new Item("Water", 5, 10)
            };

            // For each row, clear and refill with 5 items
            for (int i = 0; i < Rows.Length; i++)
            {
                Rows[i].ItemQueue.Clear();
                for (int j = 0; j < 5; j++)
                {
                    Rows[i].ItemQueue.Enqueue(
                        new Item(items[i].Name, items[i].MarketPrice, items[i].Price)
                    );
                }
            }

            // Print all items in the machine post refill
            Console.WriteLine("Items in the machine after refill:");
            for (int i = 0; i < Rows.Length; i++)
            {
                Console.Write($"Row {i + 1}: ");
                foreach (var item in Rows[i].ItemQueue)
                {
                    Console.Write($"{item.Name} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Dispenses the item.
        /// </summary>
        /// <param name="selectedRow">The selected row.</param>
        /// <returns></returns>
        public Item DispenseItem(Row selectedRow)
        {
            Item itemToDequeue = selectedRow.ItemQueue.Dequeue();
            return itemToDequeue;
        }


        // Calculates the coins to return as change for a given amount
        /// <summary>
        /// Calculates the change.
        /// </summary>
        /// <param name="changeAmount">The change amount.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Removes the coins from bank.
        /// </summary>
        /// <param name="coinsToRemove">The coins to remove.</param>
        public void RemoveCoinsFromBank(List<Coin> coinsToRemove)
        {

            try
            {
                for (int i = 0; i < coinsToRemove.Count; i++)
                {
                    Coin coinToRemove = coinsToRemove[i];
                    // Find the first coin in the bank with the same value
                    for (int j = 0; j < BankedCoins.Count; j++)
                    {
                        Coin bankCoin = BankedCoins[j];
                        if (bankCoin.Value == coinToRemove.Value)
                        {
                            BankedCoins.RemoveAt(j);
                            break; // Remove only one matching coin per coinToRemove
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error removing coins from bank: " + ex.Message);
            }
        }

        // Helper method to create Coin objects based on value
        /// <summary>
        /// Creates the coin by value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
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

        // ###############################################
        // ########### End Vending Machine Methods #######
        // ###############################################



        // ###############################################
        // ########### Coin Bank Methods #################
        // ###############################################



        /// <summary>
        /// Adds the coin.
        /// </summary>
        /// <param name="coin">The coin.</param>
        public void AddCoin(int coin)
        {
            if (coin == 1)
            {
                Coin_One oneKr = new Coin_One();
                BankedCoins.Add(oneKr);
            }
            else if (coin == 2)
            {
                Coin_Two twoKr = new Coin_Two();
                BankedCoins.Add(twoKr);
            }
            else if (coin == 5)
            {
                Coin_Five fiveKr = new Coin_Five();
                BankedCoins.Add(fiveKr);
            }
            else if (coin == 10)
            {
                Coin_Ten tenKr = new Coin_Ten();
                BankedCoins.Add(tenKr);
            }
            else if (coin == 20)
            {
                Coin_Twenty twentyKr = new Coin_Twenty();
                BankedCoins.Add(twentyKr);
            }
        }

        /// <summary>
        /// Removes the coin.
        /// </summary>
        /// <param name="coin">The coin.</param>
        public void RemoveCoin(int coin)
        {
            if (coin == 1)
            {
                Coin_One oneKr = new Coin_One();
                BankedCoins.Remove(oneKr);
            }
            else if (coin == 2)
            {
                Coin_Two twoKr = new Coin_Two();
                BankedCoins.Remove(twoKr);
            }
            else if (coin == 5)
            {
                Coin_Five fiveKr = new Coin_Five();
                BankedCoins.Remove(fiveKr);
            }
            else if (coin == 10)
            {
                Coin_Ten tenKr = new Coin_Ten();
                BankedCoins.Remove(tenKr);
            }
            else if (coin == 20)
            {
                Coin_Twenty twentyKr = new Coin_Twenty();
                BankedCoins.Remove(twentyKr);
            }
        }

        /// <summary>
        /// Coins the bank report.
        /// </summary>
        public void CoinBankReport()
        {
            Console.WriteLine("CoinBank report:");
            Console.WriteLine();
            foreach (Coin coin in BankedCoins)
            {
                Console.WriteLine("CoinBank contains " + coin.Name + " coins.");
            }
        }

        // ###############################################
        // ########### End Coin Bank Methods #############
        // ###############################################


        // ###############################################
        // ############ Panel Methods ####################
        // ###############################################

        /// <summary>
        /// Inserts the coin.
        /// </summary>
        /// <param name="coin">The coin.</param>
        public void InsertCoin(int coin)
        {

            if (coin == 1)
            {
                Coin_One oneKr = new Coin_One();
                InsertedCoins.Add(oneKr);
            }
            else if (coin == 2)
            {
                Coin_Two twoKr = new Coin_Two();
                InsertedCoins.Add(twoKr);
            }
            else if (coin == 5)
            {
                Coin_Five fiveKr = new Coin_Five();
                InsertedCoins.Add(fiveKr);
            }
            else if (coin == 10)
            {
                Coin_Ten tenKr = new Coin_Ten();
                InsertedCoins.Add(tenKr);
            }
            else if (coin == 20)
            {
                Coin_Twenty twentyKr = new Coin_Twenty();
                InsertedCoins.Add(twentyKr);
            }

        }
        /// <summary>
        /// Calculates the total.
        /// </summary>
        /// <returns></returns>
        public int CalcTotal()
        {
            int total = 0;
            foreach (var coin in InsertedCoins)
            {
                total += coin.Value;
            }
            return total;
        }

        // ###############################################
        // ############ End Panel Methods ################
        // ###############################################



        // ###############################################
        // ############ Row Methods ######################
        // ###############################################

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="itemToAdd">The item to add.</param>
        public void AddItem(int rowIndex, Item itemToAdd)
        {
            if (rowIndex < 0 || rowIndex >= Rows.Length)
            {
                Console.WriteLine("Invalid row index.");
                return;
            }
            Rows[rowIndex].ItemQueue.Enqueue(itemToAdd);
            Console.WriteLine(itemToAdd.Name + " added to row " + Rows[rowIndex].Slot);
        }

        /// <summary>
        /// Gets the item price.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <returns></returns>
        public int GetItemPrice(int rowIndex)
        {
            return Rows[rowIndex].ItemQueue.Peek().Price;
        }

        /// <summary>
        /// Ejects the item.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <returns></returns>
        public Item EjectItem(int rowIndex)
        {
            return Rows[rowIndex].ItemQueue.Dequeue();
        }

        /// <summary>
        /// Rows to string.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns></returns>
        public string RowToString(Row row)
        {
            return "Row: " + row.Slot + " contains " + row.ItemQueue.Count + " items.";
        }

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <returns></returns>
        public Row GetRow(int rowIndex)
        {
            return Rows[rowIndex];
        }

        /// <summary>
        /// Rows the report.
        /// </summary>
        public void RowReport()
        {
            Console.WriteLine("Row Report:");
            Console.WriteLine();
            foreach (Row row in Rows)
            {
                Console.WriteLine("Row " + row.Slot + " Contains " + row.ItemQueue.Count + " items");
            }
        }

        // ###############################################
        // ############ End Row Methods ##################
        // ###############################################


    }
}
