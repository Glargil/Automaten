using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten.Models;
using Automaten.Models.Coins;
using Automaten.Repository;

namespace Automaten.Service
{
    public class VendingMachineService
    {
        // Vending Machine Methods
        /// <summary>
        /// The vending machine interface
        /// </summary>
        private IVendingMachineRepo _vendingMachineInterface;
        /// <summary>
        /// Initializes a new instance of the <see cref="VendingMachineService"/> class.
        /// </summary>
        /// <param name="vendingMachineInterface">The vending machine interface.</param>
        public VendingMachineService(IVendingMachineRepo vendingMachineInterface)
        {
            _vendingMachineInterface = vendingMachineInterface;
        }
        /// <summary>
        /// Refills this instance.
        /// </summary>
        public void Refill()
        {
            _vendingMachineInterface.Refill();
        }
        /// <summary>
        /// Calculates the change.
        /// </summary>
        /// <param name="changeAmount">The change amount.</param>
        /// <returns></returns>
        public List<Coin> CalculateChange(int changeAmount)
        {
           return _vendingMachineInterface.CalculateChange(changeAmount);
        }
        /// <summary>
        /// Removes the coins from bank.
        /// </summary>
        /// <param name="coinsToRemove">The coins to remove.</param>
        public void RemoveCoinsFromBank(List<Coin> coinsToRemove)
        {
            _vendingMachineInterface.RemoveCoinsFromBank(coinsToRemove);
        }
        /// <summary>
        /// Dispenses the item.
        /// </summary>
        /// <param name="selectedRow">The selected row.</param>
        /// <returns></returns>
        public Item DispenseItem(Models.Row selectedRow)
        {
            return _vendingMachineInterface.DispenseItem(selectedRow);
        }



        // Coin Bank Methods
        /// <summary>
        /// Adds the coin.
        /// </summary>
        /// <param name="coin">The coin.</param>
        public void AddCoin(int coin)
        {
            _vendingMachineInterface.AddCoin(coin);
        }
        /// <summary>
        /// Removes the coin.
        /// </summary>
        /// <param name="coin">The coin.</param>
        public void RemoveCoin(int coin)
        {
            _vendingMachineInterface.RemoveCoin(coin);
        }
        /// <summary>
        /// Coins the bank report.
        /// </summary>
        public void CoinBankReport()
        {
            _vendingMachineInterface.CoinBankReport();
        }


        // Panel Methods
        /// <summary>
        /// Inserts the coin.
        /// </summary>
        /// <param name="coin">The coin.</param>
        public void InsertCoin(int coin)
        {
            _vendingMachineInterface.InsertCoin(coin);
        }
        /// <summary>
        /// Calculates the total.
        /// </summary>
        /// <returns></returns>
        public int CalcTotal()
        {
            return _vendingMachineInterface.CalcTotal();
        }


        // Row Methods
        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="itemToAdd">The item to add.</param>
        public void AddItem(int rowIndex, Item itemToAdd)
        {
            _vendingMachineInterface.AddItem(rowIndex, itemToAdd);
        }
        /// <summary>
        /// Gets the item price.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns></returns>
        public int GetItemPrice(int row)
        {
            return _vendingMachineInterface.GetItemPrice(row);
        }

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <returns></returns>
        public Row GetRow(int rowIndex)
        {
            return _vendingMachineInterface.GetRow(rowIndex);
        }

        /// <summary>
        /// Ejects the item.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <returns></returns>
        public Item EjectItem(int rowIndex)
        {
            return _vendingMachineInterface.EjectItem(rowIndex);
        }

        /// <summary>
        /// Rows to string.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns></returns>
        public string RowToString(Row row)
        {
            return _vendingMachineInterface.RowToString(row);
        }

        /// <summary>
        /// Rows the report.
        /// </summary>
        public void RowReport()
        {
            _vendingMachineInterface.RowReport();
        }

    }
}
