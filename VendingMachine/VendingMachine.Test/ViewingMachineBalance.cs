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
    public class ViewingMachineBalance
    {
        private SodaMachine machine;
        private SodaMachineUi ui;

        [TestInitialize]
        public void SetUp()
        {
            machine = new SodaMachine(10);
            ui = new SodaMachineUi(machine);
            ui.PerformAction(MainMenu.Commands.StockerMenu.Command);
        }

        [TestMethod]
        public void MachineBalanceShouldStartAtZero()
        {
            Assert.AreEqual(0,machine.MachineBalance);
        }

        [TestMethod]
        public void ShouldDisplayMachineBalance()
        {
            machine.DepositMachineMoney(5);
            string result = ui.PerformAction(AdminMenu.Commands.ViewMachineBalance.Command);
            Assert.IsTrue(result.Contains("$5.00"));
        }
    }
}
