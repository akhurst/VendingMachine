using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class StockMenu : IController
    {
        public const string StockMenuFormat = "Stock Menu\nQ: Quit";

        public StockMenu()
        {
            this.IsActive = true;
        }

        public bool IsActive
        {
            get; private set;
        }

        public string DisplayPrompt
        {
            get { return StockMenuFormat; }
        }

        public ActionResult PerformAction(string userInput)
        {
            switch (userInput)
            {
                case "q":
                case "Q":
                    return Quit();
            }

            return new ActionResult(CommonMessages.InvalidOptionMessage);
        }

        private ActionResult Quit()
        {
            this.IsActive = false;
            return new ActionResult();
        }
    }
}
