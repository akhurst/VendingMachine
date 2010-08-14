using System;

namespace VendingMachine
{
    public class MainMenu : BaseMenu
    {
        public MainMenu(SodaMachine machine)
            : base(machine, "Main Menu")
        {
            ActionCommands.Add(new ActionCommand(Commands.StockerMenu, NavigateToAdminMenu));
            ActionCommands.Add(new ActionCommand(Commands.AddMoney, HandleAddMoney));
            ActionCommands.Add(new ActionCommand(Commands.PrintCustomerBalance, HandlePrintCustomerBalance));
            ActionCommands.Add(ActionCommandFactory.CreateQuitToPreviousMenuCommand(Quit));
        }

        private ActionResult Quit(string arg)
        {
            return new QuitMenuResult();
        }

        private TextResult HandlePrintCustomerBalance(string arg)
        {
            return new TextResult(string.Format("Customer Balance: {0:c}", Machine.CustomerBalance));
        }

        private TextResult HandleAddMoney(string arg)
        {
            double amountToAdd;

            if (double.TryParse(arg, out amountToAdd))
            {
                Machine.AddMoney(amountToAdd);
                return new TextResult(string.Format("New Balance: {0}", Machine.CustomerBalance));
            }

            return new InvalidArgumentResult();
        }

        private ActionResult NavigateToAdminMenu(string argument)
        {
            return new NavigateResult(new StockerMenu(Machine));
        }

        public static class Commands
        {
            public static readonly ActionCommandMetadata StockerMenu = new ActionCommandMetadata
            {
                Command = "sto",
                CommandDescription = "Stocker Menu"
            };

            public static readonly ActionCommandMetadata AddMoney = new ActionCommandMetadata
            {
                Command = "add",
                CommandDescription = "Add Money",
                ArgumentDescription = "<money amount>"
            };

            public static readonly ActionCommandMetadata PrintCustomerBalance = new ActionCommandMetadata
            {
                Command = "bal",
                CommandDescription = "Check Customer Balance"
            };
        }
    }
}
