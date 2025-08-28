using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten.Models.Coins;

namespace Automaten.Repository
{
    public interface IVendingMachineRepo
    {
        void Refill();
        List<Coin> CalculateChange(int changeAmount);
        void RemoveCoinsFromBank(List<Coin> coinsToRemove);
    }
}
