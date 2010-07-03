using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.DisplayResult;

namespace VendingMachine.Menu.SodaMenu
{
    public class MainMenu : BaseMenu
    {
        public MainMenu(SodaMachine machine) : base(machine, "Main Menu")
        {
            ActionCommandHandlers.Add(Commands.AdminMenu, NavigateToAdminMenu);
            ActionCommandHandlers.Add(Commands.AddMoney, HandleAddMoney);
            ActionCommandHandlers.Add(Commands.PrintCustomerBalance, PrintCustomerBalance);
            ActionCommandHandlers.Add(Commands.Quit, Quit);
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

        private TextResult NavigateToAdminMenu(string argument)
        {
            NavigationController.PushViewController(new AdminMenu(Machine));
            return new EmptyResult();
        }

        public static class Commands
        {

            public static readonly ActionCommand AdminMenu = new ActionCommand("1")
            {
                CommandDescription = "Admin Menu"
            };

            public static readonly ActionCommand AddMoney = new ActionCommand("2")
            {
                CommandDescription = "Add Money"
            };

            public static readonly ActionCommand PrintCustomerBalance = new ActionCommand("3")
            {
                CommandDescription = "Print Customer Balance"
            };

            public static readonly ActionCommand Quit = ActionCommandFactory.CreateQuitCommand();
        }
    }
}
