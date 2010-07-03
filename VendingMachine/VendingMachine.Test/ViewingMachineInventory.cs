using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachine.Test
{
    [TestClass]
    public class ViewingMachineInventory
    {
        private SodaMachine machine;
        private SodaMachineUi ui;

        [TestInitialize]
        public void SetUp()
        {
            machine = new SodaMachine(10);
            ui = new SodaMachineUi(machine);
            ui.PerformAction(MainMenu.Commands.AdminMenu);
        }

        [TestMethod]
        public void ShouldRenderViewInventory()
        {
            machine.Slots[2].ProductName = "Dr. Pepper";
            string result = ui.PerformAction(AdminMenu.Commands.ViewInventory);
            Assert.IsTrue(result.Contains("Dr. Pepper"));
        }
    }
}
