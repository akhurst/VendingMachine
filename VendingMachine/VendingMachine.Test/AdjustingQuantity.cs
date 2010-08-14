using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Domain;
using VendingMachine.Framework;
using VendingMachine.Menus;

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
            ui.PerformAction(MainMenu.Commands.StockerMenu.Command);
        }

        [TestMethod]
        public void ShouldStartWithZeroItems()
        {
            foreach (var slot in machine.Slots)
            {
                Assert.AreEqual(0, slot.Quantity);
            }
        }

        [TestMethod]
        public void ShouldBeAbleToAddItems()
        {
            ui.PerformAction(StockerMenu.Commands.AdjustQuantity.Command + " 1 1");
            Assert.AreEqual(1, machine.Slots[0].Quantity);
        }

        [TestMethod]
        public void ShouldNotBeAbleToAddMoreThanTwentyItems()
        {
            ui.PerformAction(StockerMenu.Commands.AdjustQuantity.Command + " 3 21");

            Assert.AreEqual(0, machine.Slots[2].Quantity);
        }
    }
}
