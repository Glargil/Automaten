using Automaten.Models;

namespace Automaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Item cola = new Item("Cola", 20, 25);
           Item fanta = new Item("Fanta", 30, 35);
           VendingMachine vendingMachine1 = new VendingMachine(new Panel("", 0, 0), new CoinBank(), new Row[2]);

            vendingMachine1.Rows[0].AddItem(cola);
            vendingMachine1.Rows[0].AddItem(cola);
            vendingMachine1.Rows[0].AddItem(cola);
            vendingMachine1.Rows[1].AddItem(fanta);
            vendingMachine1.Rows[1].AddItem(fanta);
        }
    }
}
