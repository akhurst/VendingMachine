using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachine.Test
{
    [TestClass]
    public class ViewingCustomerBalance
    {
        [TestMethod]
        public void ShouldPrintCorrectCustomerBalance()
        {
            SodaMachine machine = new SodaMachine(10);
            SodaMachineUi machineUi = new SodaMachineUi(machine);
            machine.AddMoney(2.25);
            string result = machineUi.PerformAction(MainMenu.Commands.PrintCustomerBalance);
            Assert.IsTrue(result.Contains("2.25"), string.Format("Result should contain 2.25, actual result was {0}",result));
        }
    }
}
