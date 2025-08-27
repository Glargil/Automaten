using Automaten.Models;

namespace Automaten.Repositories
{
    public interface IVendingMachineRepository
    {
        VendingMachine GetVendingMachine();
        void SetVendingMachine(VendingMachine vendingMachine);
    }
}
