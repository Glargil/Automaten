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
        private IVendingMachineRepo _vendingMachineInterface;
        public VendingMachineService(IVendingMachineRepo vendingMachineInterface)
        {
            _vendingMachineInterface = vendingMachineInterface;
        }
        public void Refill()
        {
            _vendingMachineInterface.Refill();
        }
        public List<Coin> CalculateChange(int changeAmount)
        {
           return _vendingMachineInterface.CalculateChange(changeAmount);
        }
        public void RemoveCoinsFromBank(List<Coin> coinsToRemove)
        {
            _vendingMachineInterface.RemoveCoinsFromBank(coinsToRemove);
        }
        public Item DispenseItem(Models.Row selectedRow)
        {
            return _vendingMachineInterface.DispenseItem(selectedRow);
        }



        // Coin Bank Methods
        public void AddCoin(int coin)
        {
            _vendingMachineInterface.AddCoin(coin);
        }
        public void RemoveCoin(int coin)
        {
            _vendingMachineInterface.RemoveCoin(coin);
        }
        public void CoinBankReport()
        {
            _vendingMachineInterface.CoinBankReport();
        }


        // Panel Methods
        public void InsertCoin(int coin)
        {
            _vendingMachineInterface.InsertCoin(coin);
        }
        public int CalcTotal()
        {
            return _vendingMachineInterface.CalcTotal();
        }


        // Row Methods
        public void AddItem(int rowIndex, Item itemToAdd)
        {
            _vendingMachineInterface.AddItem(rowIndex, itemToAdd);
        }
        public int GetItemPrice(int row)
        {
            return _vendingMachineInterface.GetItemPrice(row);
        }

        public Row GetRow(int rowIndex)
        {
            return _vendingMachineInterface.GetRow(rowIndex);
        }

        public Item EjectItem(int rowIndex)
        {
            return _vendingMachineInterface.EjectItem(rowIndex);
        }

        public string RowToString(Row row)
        {
            return _vendingMachineInterface.RowToString(row);
        }

        public void RowReport()
        {
            _vendingMachineInterface.RowReport();
        }

    }
}
