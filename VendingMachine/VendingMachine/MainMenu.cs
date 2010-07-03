using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class MainMenu : BaseMenu
    {
        public const string MainMenuFormat = "Main Menu\n1: Admin Menu\n2: Add Money With Amount ex. [2 .40]\n3: Print Customer Balance\nQ: Quit";

        public MainMenu(SodaMachine machine) : base(machine)
        {
            CommandsToHandlers.Add(Commands.AdminMenu, NavigateToAdminMenu);
            CommandsToHandlers.Add(Commands.AddMoney, HandleAddMoney);
            CommandsToHandlers.Add(Commands.PrintCustomerBalance, PrintCustomerBalance);
        }

        private ActionResult PrintCustomerBalance(string arg)
        {
            return new ActionResult(string.Format("Customer Balance: {0:c}",Machine.CustomerBalance));
        }

        private ActionResult HandleAddMoney(string arg)
        {
            double amountToAdd;

            if(double.TryParse(arg, out amountToAdd))
            {
                Machine.AddMoney(amountToAdd);
                return new ActionResult(string.Format("New Balance: {0}",Machine.CustomerBalance));
            }

            return new ActionResult();
        }

        public override string DisplayPrompt
        {
            get
            {
                return string.Format(MainMenuFormat);
            }
        }

        private ActionResult NavigateToAdminMenu(string argument)
        {
            return new ActionResult(new AdminMenu(Machine));
        }
        
        public static class Commands
        {
            public const string PrintCustomerBalance = "3";
            public const string AddMoney = "2";
            public const string AdminMenu = "1";
        }
    }
}
