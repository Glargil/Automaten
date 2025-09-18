using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automaten.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten.Repository;
using Automaten.Models;
using Automaten.Models.Coins;
using System.Collections;

namespace Automaten.Service.Tests
{
    [TestClass()]
    public class VendingMachineServiceTests
    {
        //Arrange
        //[TestInitialize] tells the testfile to run the following method before each test
        [TestInitialize]
        public void Setup()
        { 
        IVendingMachineRepo vendingMachineRepo = new VendingMachineRepo();
        VendingMachineService vendingMachineService = new VendingMachineService(vendingMachineRepo);
        #region Add items and coins to the vending machine
        vendingMachineService.AddItem(0, new Item("Cola", 20, 25));
        vendingMachineService.AddItem(1, new Item("Fanta", 30, 35));
        vendingMachineService.AddItem(2, new Item("Snickers", 15, 20));
        vendingMachineService.AddItem(3, new Item("Water", 5, 10));
        vendingMachineService.AddCoin(1);
        vendingMachineService.AddCoin(2);
        vendingMachineService.AddCoin(5);
        vendingMachineService.AddCoin(10);
            #endregion
        }

        //Annotation
        [TestMethod()]
        public void CalculateChangeSetUpListOfCoins()
        {
            //Arrange
            #region initializing services, coins and expected list
            IVendingMachineRepo vendingMachineRepo = new VendingMachineRepo();
            VendingMachineService vendingMachineService = new VendingMachineService(vendingMachineRepo);
            Coin one = new Coin_One();
            Coin two = new Coin_Two();
            Coin five = new Coin_Five();
            Coin ten = new Coin_Ten();
            Coin twenty = new Coin_Twenty();
            List<Coin> expected = new List<Coin>() { twenty, five, two, one };

            #endregion

            //Act 28
            List<Coin>actualCoins = vendingMachineService.CalculateChange(28);

            //Assert
            CollectionAssert.AreEqual(expected, actualCoins, new CoinComparer());
        }

        [TestMethod()]
        public void RemoveCoinTest()
        {
            Assert.Fail();
        }

        //Helper class to compare two lists of coins
        public class CoinComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                var p1 = (Coin)x;
                var p2 = (Coin)y;
                return string.Compare(p1.Name, p2.Name, StringComparison.Ordinal);
            }
        }
    }
}