using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class MainMenu : IController
    {
        public const string MainMenuFormat = "Main Menu\n1: Stock Items\nQ: Quit";

        public MainMenu()
        {
            this.IsActive = true;
        }

        public bool IsActive
        {
            get; private set;
        }

        public string DisplayPrompt
        {
            get
            {
                return string.Format(MainMenuFormat);
            }
        }

        public ActionResult PerformAction(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    return NavigateToStockMenu();
                case "q":
                case "Q":
                    return Quit();
            }

            return new ActionResult(CommonMessages.InvalidOptionMessage);
        }

        private ActionResult NavigateToStockMenu()
        {
            return new ActionResult(new StockMenu());
        }

        private ActionResult Quit()
        {
            this.IsActive = false;
            return new ActionResult();
        }
    }
}
