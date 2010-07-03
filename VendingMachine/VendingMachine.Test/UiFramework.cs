using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            AssertIsAtMainMenu();
        }

        [TestMethod]
        public void ShouldBeActiveWhenStarted()
        {
            Assert.IsTrue(ui.IsActive);
        }

        [TestMethod]
        public void ShouldBeInactiveAfterQuit()
        {
            ui.PerformAction("Q");
            Assert.IsFalse(ui.IsActive);
        }

        [TestMethod]
        public void ShouldDisplaySubMenu()
        {
            ui.PerformAction(MainMenu.Commands.AdminMenu);
            string expectedPrompt = string.Format(AdminMenu.MenuFormatString);
            Assert.AreEqual(expectedPrompt, ui.DisplayPrompt);
        }

        [TestMethod]
        public void ShouldGoBackToMainMenuAfterQuittingSubMenu()
        {
            ui.PerformAction(MainMenu.Commands.AdminMenu);
            ui.PerformAction("Q");
            AssertIsAtMainMenu();
        }

        [TestMethod]
        public void ShouldGetFeedbackWhenEnteringAnInvalidOptionOnMainMenu()
        {
            AssertGotInvalidOptionFeedback();
        }

        [TestMethod]
        public void ShouldGetFeedbackWhenEnteringAnInvalidOptionOnSubMenu()
        {
            ui.PerformAction(MainMenu.Commands.AdminMenu);
            AssertGotInvalidOptionFeedback();
        }

        private void AssertGotInvalidOptionFeedback()
        {
            string result = ui.PerformAction("junk");
            Assert.AreEqual(CommonMessages.InvalidOptionMessage, result);
        }

        private void AssertIsAtMainMenu()
        {
            string expectedPrompt = string.Format(MainMenu.MainMenuFormat);
            Assert.AreEqual(expectedPrompt, ui.DisplayPrompt);
        }
    }
}
