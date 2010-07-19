using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Domain;
using VendingMachine.Menus;

namespace VendingMachine.Test
{
    [TestClass]
    public class StockingItems
    {
        [TestMethod]
        public void ShouldBeAbleToNameAnItem()
        {
            SodaMachine machine = new SodaMachine(10);
            SodaMachineUi ui = new SodaMachineUi(machine);
            ui.PerformAction(MainMenu.Commands.AdminMenu.Command);
            ui.PerformAction(AdminMenu.Commands.SetName.Command+" 1 Dr. Pepper");

            Assert.AreEqual("Dr. Pepper", machine.Slots[0].ProductName);
        }

        [TestMethod]
        public void ShouldBeAbleToSetQuantity()
        {
            SodaMachine machine = new SodaMachine(10);
            SodaMachineUi ui = new SodaMachineUi(machine);

            ui.PerformAction(MainMenu.Commands.AdminMenu.Command);
            ui.PerformAction(AdminMenu.Commands.SetQuantity.Command + " 1 15");

            Assert.Equals(15, machine.Slots[0].Quantity);
        }
    }
}
