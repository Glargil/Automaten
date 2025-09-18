using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten.Models;
using Automaten;
using Automaten.Models.Coins;
using Xunit;

namespace Automaten.Tests
{
    public class VendingMachineTests
    {
        [Fact]
        public Item DispenseItem_DequeueItemFromGivenRowQueue(Row selectedRow)
        {
            // Arrange HER SKAL DU INSTANTIERE DIT REPO SERVICES OG ADDITEM ETC
            Item expected = selectedRow.ItemQueue.Dequeue();

            // Act
            Item actual = DispenseItem();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
