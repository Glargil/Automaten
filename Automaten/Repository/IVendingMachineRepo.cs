using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten.Models.Coins;
using Automaten.Models;

namespace Automaten.Repository
{
    public interface IVendingMachineRepo
    {

        // Vending Machine Methods
        void Refill();
        Item DispenseItem(Models.Row selectedRow);
        List<Coin> CalculateChange(int changeAmount);
        void RemoveCoinsFromBank(List<Coin> coinsToRemove);




        // Coin Bank Methods
        void AddCoin(int coin);
        void RemoveCoin(int coin);
        void CoinBankReport();




        // Panel Methods
        void InsertCoin(int coin);
        int CalcTotal();


        // Row Methods
        void AddItem(int rowIndex, Item itemToAdd);
        int GetItemPrice(Row row);
        Item EjectItem(Row row);
        string RowToString(Row row);
    }
}
