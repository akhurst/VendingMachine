using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Framework;
using VendingMachine.Framework.Results;
using VendingMachine.Menus;

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
            Assert.IsInstanceOfType(ui.ActiveController, typeof(MainMenu));
        }

        [TestMethod]
        public void ShouldDisplaySubMenu()
        {
            ui.PerformAction(MainMenu.Commands.StockerMenu.Command);
            Assert.IsInstanceOfType(ui.ActiveController, typeof(AdminMenu));
        }

        [TestMethod]
        public void ShouldGoBackToMainMenuAfterQuittingSubMenu()
        {
            ui.PerformAction(MainMenu.Commands.StockerMenu.Command);
            ui.PerformAction(ActionCommandFactory.QuitToPreviousMenuMetadata.Command);

            Assert.IsInstanceOfType(ui.ActiveController, typeof(MainMenu));
        }

        [TestMethod]
        public void ShouldGetFeedbackWhenEnteringAnInvalidOptionOnMainMenu()
        {
            AssertGotInvalidOptionFeedback();
        }

        [TestMethod]
        public void ShouldGetFeedbackWhenEnteringAnInvalidOptionOnSubMenu()
        {
            ui.PerformAction(MainMenu.Commands.StockerMenu.Command);
            AssertGotInvalidOptionFeedback();
        }

        private void AssertGotInvalidOptionFeedback()
        {
            string result = ui.PerformAction("junk");
            Assert.AreEqual(result, new InvalidMenuOptionResult().Output);
        }
    }
}
