using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Domain;
using VendingMachine.Framework;
using VendingMachine.Framework.Exceptions;
using VendingMachine.Menus;

namespace VendingMachine.Test
{
    [TestClass]
    public class SelectingAnItem
    {
        SodaMachine machine;
        SodaMachineUi ui;

        [TestInitialize]
        public void SetUp()
        {
            machine= new SodaMachine(10);
            ui = new SodaMachineUi(machine);
            machine.Slots[0].Quantity = 10;
        }

        [TestMethod]
        public void ShouldBeAbleToSelectAnItem()
        {
            machine.DepositCustomerMoney(2);
            ui.PerformAction(MainMenu.Commands.ChooseItem.Command + " 1");
            Assert.AreEqual(9, machine.Slots[0].Quantity);
        }

        [TestMethod]
        public void ItemsShouldDefaultTo75Cents()
        {
            Assert.AreEqual(.75, machine.Slots[0].Cost);
        }

        [TestMethod]
        public void ShouldNotDispenseItemIfNotEnoughMoney()
        {
            ui.PerformAction(MainMenu.Commands.ChooseItem.Command + " 1");
            Assert.AreEqual(10, machine.Slots[0].Quantity);
        }

        [TestMethod]
        public void ShouldVendCorrectItem()
        {
            machine.Slots[2].Quantity = 10;
            machine.Slots[2].ProductName = "Coca Cola";
            string result = ui.PerformAction(MainMenu.Commands.ChooseItem.Command + " 3");
            Assert.IsTrue(result.Contains("Coca Cola"));
        }

        [TestMethod]
        public void ShouldUpdateTheCustomersBalanceAfterBuyingAnItem()
        {
            machine.DepositCustomerMoney(2);
            ui.PerformAction(MainMenu.Commands.ChooseItem.Command + " 1");
            Assert.AreEqual(1.25, machine.CustomerBalance);
        }

        [TestMethod]
        public void ShouldUpdateTheMachineBalanceAfterPurchase()
        {
            machine.DepositCustomerMoney(2);
            ui.PerformAction(MainMenu.Commands.ChooseItem.Command + " 1");

            Assert.AreEqual(0.75, machine.MachineBalance);
        }

        [TestMethod]
        public void ShouldNotifyCustomerIfItemSoldOut()
        {
            machine.DepositCustomerMoney(2);
            string result = ui.PerformAction(MainMenu.Commands.ChooseItem.Command + " 9");

            Assert.AreEqual(string.Format(SoldOutException.MessageFormat, string.Empty), result);
        }
    }
}
