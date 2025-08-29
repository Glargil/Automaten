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
        void Refill();
        Item DispenseItem(Models.Row selectedRow);
        List<Coin> CalculateChange(int changeAmount);
        void RemoveCoinsFromBank(List<Coin> coinsToRemove);

    }
}
