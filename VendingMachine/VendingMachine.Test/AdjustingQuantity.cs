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
            ui.PerformAction("1");
            ui.PerformAction("2");
        }

        [TestMethod]
        public void ShouldLoadAdjustQuantityMenu()
        {
            string expectedMenu = string.Format(AdjustQuantityMenu.MenuFormatString);
            Assert.AreEqual(expectedMenu,ui.DisplayPrompt);
        }

        [TestMethod]
        public void ShouldBeAbleToAddItems()
        {
            int previousQuantity = machine.Slots[0].Quantity;
            ui.PerformAction("1 1");
            int postQuantity = machine.Slots[0].Quantity;
            Assert.AreEqual(0, previousQuantity);
            Assert.AreEqual(1, postQuantity);
        }
    }
}
