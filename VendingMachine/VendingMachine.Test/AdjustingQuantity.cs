using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachine.Test
{
    [TestClass]
    public class AdjustingQuantity
    {
        private SodaMachine machine;
        private SodaMachineUi ui;

        [TestInitialize]
        public void SetUp()
        {
            machine = new SodaMachine(10);
            ui = new SodaMachineUi(machine);
            ui.PerformAction(MainMenu.Commands.AdminMenu);
            ui.PerformAction(AdminMenu.Commands.AdjustQuantity);
        }

        [TestMethod]
        public void ShouldLoadAdjustQuantityMenu()
        {
            string expectedMenu = string.Format(AdjustQuantityMenu.MenuFormatString,Slot.MaximumQuantity);
            Assert.AreEqual(expectedMenu,ui.DisplayPrompt);
        }

        [TestMethod]
        public void ShouldStartWithZeroItems()
        {
            foreach (var slot in machine.Slots)
            {
                Assert.AreEqual(0,slot.Quantity);
            }
        }

        [TestMethod]
        public void ShouldBeAbleToAddItems()
        {
            ui.PerformAction("1 1");
            Assert.AreEqual(1, machine.Slots[0].Quantity);
        }

        [TestMethod]
        public void ShouldNotBeAbleToAddMoreThanTwentyItems()
        {
            string result = ui.PerformAction("3 21");
            Assert.AreEqual(0,machine.Slots[2].Quantity);
        }
    }
}
