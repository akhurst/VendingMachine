using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Domain;
using VendingMachine.Framework;
using VendingMachine.Menus;

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
            ui.PerformAction(MainMenu.Commands.AdminMenu.Command);
        }

        [TestMethod]
        public void ShouldRenderViewInventory()
        {
            machine.Slots[2].ProductName = "Dr. Pepper";
            machine.Slots[2].Quantity = 9;
            machine.Slots[3].ProductName = "Coca Cola";
            machine.Slots[3].Quantity = 11;
            string result = ui.PerformAction(AdminMenu.Commands.ViewInventory.Command).ToString();
            string[] lines = result.Split('\n');
            Assert.IsTrue(lines[2].Contains("3"));
            Assert.IsTrue(lines[2].Contains("9"));
            Assert.IsTrue(lines[2].Contains("Dr. Pepper"));
            Assert.IsTrue(lines[3].Contains("4"));
            Assert.IsTrue(lines[3].Contains("11"));
            Assert.IsTrue(lines[3].Contains("Coca Cola"));
        }
    }
}
