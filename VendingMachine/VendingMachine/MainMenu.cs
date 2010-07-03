using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.DisplayResult;

namespace VendingMachine
{
    public class MainMenu : BaseMenu
    {
        public const string MainMenuFormat = "Main Menu\n1: Admin Menu\n2: Add Money With Amount ex. [2 .40]\n3: Print Customer Balance\nQ: Quit Program";

        public MainMenu(SodaMachine machine) : base(machine)
        {
            CommandsToHandlers.Add(Commands.AdminMenu, NavigateToAdminMenu);
            CommandsToHandlers.Add(Commands.AddMoney, HandleAddMoney);
            CommandsToHandlers.Add(Commands.PrintCustomerBalance, PrintCustomerBalance);
            CommandsToHandlers.Add(Commands.Quit, Quit);
            CommandsToHandlers.Add(Commands.QuitAlternative, Quit);
        }

        private TextResult Quit(string arg)
        {
            Environment.Exit(0);
            return new EmptyResult();
        }

        private TextResult PrintCustomerBalance(string arg)
        {
            return new TextResult(string.Format("Customer Balance: {0:c}",Machine.CustomerBalance));
        }

        private TextResult HandleAddMoney(string arg)
        {
            double amountToAdd;

            if(double.TryParse(arg, out amountToAdd))
            {
                Machine.AddMoney(amountToAdd);
                return new TextResult(string.Format("New Balance: {0}",Machine.CustomerBalance));
            }

            return new EmptyResult();
        }

        public override string DisplayPrompt
        {
            get
            {
                return string.Format(MainMenuFormat);
            }
        }

        private TextResult NavigateToAdminMenu(string argument)
        {
            NavigationController.PushViewController(new AdminMenu(Machine));
            return new EmptyResult();
        }
        
        public static class Commands
        {
            public const string PrintCustomerBalance = "3";
            public const string AddMoney = "2";
            public const string AdminMenu = "1";
            public const string Quit = "q";
            public const string QuitAlternative = "Q";
        }
    }
}
