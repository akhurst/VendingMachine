using System;
using System.Text;
using VendingMachine.Domain;
using VendingMachine.Framework;
using VendingMachine.Framework.Results;
using VendingMachine.Framework.Exceptions;

namespace VendingMachine.Menus
{
    public class MainMenu : BaseMenu
    {
        public MainMenu(SodaMachine machine)
            : base(machine, "Main Menu")
        {
            ActionCommands.Add(new ActionCommand(Commands.StockerMenu, NavigateToAdminMenu));
            ActionCommands.Add(new ActionCommand(Commands.AddMoney, HandleAddMoney));
            ActionCommands.Add(new ActionCommand(Commands.PrintCustomerBalance, HandlePrintCustomerBalance));
            ActionCommands.Add(new ActionCommand(Commands.ViewProductList,HandleViewProductList));
            ActionCommands.Add(new ActionCommand(Commands.ChooseItem, HandleBuyAnItem));
            ActionCommands.Add(new ActionCommand(Commands.ReturnChange, HandleReturnChange));

            ActionCommands.Add(ActionCommandFactory.CreateQuitToPreviousMenuCommand(Quit));
        }

        private ActionResult HandleReturnChange(string arg)
        {
            return new TextResult(string.Format("You receive {0:c} change.",Machine.ReturnChange()));
        }

        private ActionResult Quit(string arg)
        {
            return new QuitMenuResult();
        }

        private TextResult HandleBuyAnItem(string arg)
        {
            int slotNumber;

            if (!int.TryParse(arg, out slotNumber))
                return new InvalidMenuOptionResult();

            try
            {
                string productName = Machine.BuyItem(slotNumber);
                return new TextResult("You received one " + productName);
            }
            catch(ApplicationException e)
            {
                return new TextResult(e.Message);
            }
        }

        private ActionResult HandleViewProductList(string arg)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Machine.Slots.Count; i++)
            {
                result.AppendFormat("{0,2} {1}", i + 1, Machine.Slots[i].ProductName)
                    .AppendLine();
            }
            return new TextResult(result.ToString());
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
                Machine.DepositCustomerMoney(amountToAdd);
                return new TextResult(string.Format("New Balance: {0}", Machine.CustomerBalance));
            }

            return new InvalidArgumentResult();
        }

        private ActionResult NavigateToAdminMenu(string argument)
        {
            return new NavigateResult(new AdminMenu(Machine));
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

            public static readonly ActionCommandMetadata ChooseItem = new ActionCommandMetadata
            {
                Command = "buy",
                CommandDescription = "Chooses an item.",
                ArgumentDescription = "<slot number>"

            };

            public static readonly ActionCommandMetadata ViewProductList = new ActionCommandMetadata
            {
                Command = "list",
                CommandDescription = "List products"
            };

            public static readonly ActionCommandMetadata ReturnChange = new ActionCommandMetadata
            {
                Command = "change",
                CommandDescription = "Return change"
            };
        }
    }
}
