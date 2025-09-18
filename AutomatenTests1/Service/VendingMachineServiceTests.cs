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
        }

        //Annotation
        [TestMethod()]
        public void CalculateChangeSetUpListOfCoins(int changeAmount)
        {
            List<Coin>
            //Act


            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveCoinTest()
        {
            Assert.Fail();
        }
    }
}