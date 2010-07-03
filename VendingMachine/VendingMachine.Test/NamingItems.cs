using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            ui.PerformAction(MainMenu.Commands.AdminMenu);
            ui.PerformAction(AdminMenu.Commands.NameItems);
        }

        [TestMethod]
        public void ShouldBeAbleToNameAnItem()
        {
            ui.PerformAction("1 Coca Cola");
            Assert.AreEqual("Coca Cola",machine.Slots[0].ProductName);
        }

        [TestMethod]
        public void ShouldHandleJunkItemNumber()
        {
            RecordCurrentNames();
            string result = ui.PerformAction("blah").ToString();
            Assert.AreEqual(NameItemMenu.InvalidSlotString,result);
            Assert.AreEqual(string.Format(NameItemMenu.MenuFormatString),ui.DisplayPrompt);
            AssertNoNamesHaveChanged();
        }

        private void AssertNoNamesHaveChanged()
        {
            for(int i =0;i<10;i++)
            {
                Assert.AreEqual(lastRecordedNames[i],machine.Slots[i].ProductName);
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
