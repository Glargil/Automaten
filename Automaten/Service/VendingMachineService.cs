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
        private IVendingMachineRepo _vendingMachineInterface;
        public VendingMachineService(IVendingMachineRepo vendingMachineInterface)
        {
            _vendingMachineInterface = vendingMachineInterface;
        }
        public void Refill()
        {

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
    }
}
