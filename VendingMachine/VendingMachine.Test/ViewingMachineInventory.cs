using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Menu.SodaMenu;

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
            ui.PerformAction(MainMenu.Commands.StockerMenu.Command);
        }

        [TestMethod]
        public void ShouldRenderViewInventory()
        {
            machine.Slots[2].ProductName = "Dr. Pepper";
            string result = ui.PerformAction(StockerMenu.Commands.ViewInventory.Command).ToString();
            Assert.IsTrue(result.Contains("Dr. Pepper"));
        }
    }
}
