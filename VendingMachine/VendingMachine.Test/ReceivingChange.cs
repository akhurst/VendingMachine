using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Domain;
using VendingMachine.Framework;
using VendingMachine.Menus;

namespace VendingMachine.Test
{
    [TestClass]
    public class ReceivingChange
    {
        private SodaMachine machine;
        private SodaMachineUi ui;

        [TestInitialize]
        public void SetUp()
        {
            machine=new SodaMachine(10);
            ui = new SodaMachineUi(machine);
        }

        [TestMethod]
        public void ShouldReceiveTheSameAmountDeposited()
        {
            ui.PerformAction(MainMenu.Commands.AddMoney + " 1.25");
            string result = ui.PerformAction(MainMenu.Commands.ReturnChange.Command);

            Assert.IsTrue(result.Contains("1.25"));
        }

        [TestMethod]
        public void ShouldUpdateCustomerBalance()
        {
            ui.PerformAction(MainMenu.Commands.AddMoney + " 1.25");
            ui.PerformAction(MainMenu.Commands.ReturnChange.Command);

            Assert.AreEqual(0,machine.CustomerBalance);
        }

        [TestMethod]
        public void ShouldNotChangeMachineBalance()
        {
            machine.DepositMachineMoney(2.25);

            ui.PerformAction(MainMenu.Commands.AddMoney + " 1.25");
            ui.PerformAction(MainMenu.Commands.ReturnChange.Command);

            Assert.AreEqual(2.25,machine.MachineBalance);
        }

        [TestMethod]
        public void ShouldReceiveCorrectChangeAfterPurchase()
        {
            machine.Slots[0].Quantity = 10;
            ui.PerformAction(MainMenu.Commands.AddMoney + " 1.25");
            string result = ui.PerformAction(MainMenu.Commands.ChooseItem + " 1");

            Assert.IsTrue(result.Contains("0.50"));
        }
    }
}
