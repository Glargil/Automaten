using Automaten.Models;

namespace Automaten.Repositories
{
    public class VendingMachineRepository : IVendingMachineRepository
    {
        private VendingMachine _vendingMachine;

        public VendingMachineRepository(VendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;
        }

        public VendingMachine GetVendingMachine()
        {
            return _vendingMachine;
        }

        public void SetVendingMachine(VendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;
        }
    }
}
