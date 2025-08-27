using System.Collections.Generic;

namespace Automaten.Services
{
    public interface IVendingMachineService
    {
        /// <summary>
        /// Attempts to purchase an item from the specified slot.
        /// </summary>
        /// <param name="slot">The slot number to purchase from.</param>
        /// <param name="insertedCoins">A list of inserted coin values.</param>
        /// <param name="message">Result message for the UI.</param>
        /// <param name="change">Dictionary of coin value to count for change to return.</param>
        /// <returns>True if purchase was successful, false otherwise.</returns>
        bool TryPurchaseItem(int slot, List<int> insertedCoins, out string message, out Dictionary<int, int> change);

        /// <summary>
        /// Refills all rows with their respective items.
        /// </summary>
        void RefillAllRows();
    }
}
