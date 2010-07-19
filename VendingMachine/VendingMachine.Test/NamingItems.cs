using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Domain;
using VendingMachine.Framework;
using VendingMachine.Framework.Results;
using VendingMachine.Menus;

namespace VendingMachine.Test
{
    [TestClass]
    public class NamingItems
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
        public void ShouldBeAbleToNameAnItem()
        {
            ui.PerformAction(AdminMenu.Commands.NameItems.Command + " 1 Coca Cola");
            Assert.AreEqual("Coca Cola", machine.Slots[0].ProductName);
        }

        [TestMethod]
        public void ShouldHandleJunkItemNumber()
        {
            RecordCurrentNames();
            string result = ui.PerformAction(AdminMenu.Commands.NameItems.Command + " blah");
            Assert.AreEqual(result, new InvalidMenuOptionResult().Output);
            AssertNoNamesHaveChanged();
        }

        private void AssertNoNamesHaveChanged()
        {
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(lastRecordedNames[i], machine.Slots[i].ProductName);
            }
        }

        private List<string> lastRecordedNames;

        private void RecordCurrentNames()
        {
            lastRecordedNames = new List<string>();
            foreach (var slot in machine.Slots)
            {
                lastRecordedNames.Add(slot.ProductName);
            }
        }
    }
}
