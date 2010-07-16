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
    public class ViewingProductList
    {
        private SodaMachine machine;
        private SodaMachineUi ui;

        [TestInitialize]
        public void SetUp()
        {
            machine = new SodaMachine(10);
            ui = new SodaMachineUi(machine);
        }

        [TestMethod]
        public void ShouldRenderProductList()
        {
            machine.Slots[2].ProductName = "Dr. Pepper";
            machine.Slots[3].ProductName = "Coca Cola";
            string result = ui.PerformAction(MainMenu.Commands.ViewProductList.Command);
            string[] lines = result.Split('\n');
            Assert.IsTrue(lines[2].Contains("3"));
            Assert.IsTrue(lines[2].Contains("Dr. Pepper"));
            Assert.IsTrue(lines[3].Contains("4"));
            Assert.IsTrue(lines[3].Contains("Coca Cola"));
        }
    }
}
