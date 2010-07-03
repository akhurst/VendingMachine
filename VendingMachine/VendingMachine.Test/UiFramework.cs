using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Menu.SodaMenu;
using VendingMachine.DisplayResult;

namespace VendingMachine.Test
{
    [TestClass]
    public class UiFramework
    {
        private SodaMachineUi ui;

        [TestInitialize]
        public void SetUp()
        {
            ui=new SodaMachineUi();
        }

        [TestMethod]
        public void ShouldStartWithMainMenu()
        {
            Assert.IsInstanceOfType(ui.TopViewController, typeof(MainMenu));
        }

        [TestMethod]
        public void ShouldDisplaySubMenu()
        {
            ui.PerformAction(MainMenu.Commands.AdminMenu.Commands[0]);
            Assert.IsInstanceOfType(ui.TopViewController, typeof(AdminMenu));
        }

        [TestMethod]
        public void ShouldGoBackToMainMenuAfterQuittingSubMenu()
        {
            ui.PerformAction(MainMenu.Commands.AdminMenu.Commands[0]);
            ui.PerformAction(AdminMenu.Commands.QuitToMenu.Commands[0]);

            Assert.IsInstanceOfType(ui.TopViewController, typeof(MainMenu));
        }

        [TestMethod]
        public void ShouldGetFeedbackWhenEnteringAnInvalidOptionOnMainMenu()
        {
            AssertGotInvalidOptionFeedback();
        }

        [TestMethod]
        public void ShouldGetFeedbackWhenEnteringAnInvalidOptionOnSubMenu()
        {
            ui.PerformAction(MainMenu.Commands.AdminMenu.Commands[0]);
            AssertGotInvalidOptionFeedback();
        }

        private void AssertGotInvalidOptionFeedback()
        {
            TextResult result = ui.PerformAction("junk");
            Assert.IsInstanceOfType(result, typeof(InvalidInputResult));
        }
    }
}
