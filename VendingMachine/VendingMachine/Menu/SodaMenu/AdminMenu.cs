using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.DisplayResult;

namespace VendingMachine.Menu.SodaMenu
{
    public class AdminMenu : BaseMenu
    {
        public AdminMenu(SodaMachine machine) : base(machine, "Admin Menu")
        {
            ActionCommandHandlers.Add(Commands.NameItems,NavigateToNameItems);
            ActionCommandHandlers.Add(Commands.AdjustQuantity,NavigateToAdjustQuantity);
            ActionCommandHandlers.Add(Commands.ViewInventory, PrintInventory);
            ActionCommandHandlers.Add(Commands.QuitToMenu, QuitToMenu);
        }

        private TextResult QuitToMenu(string arg)
        {
            NavigationController.PopToRootViewController();
            return new EmptyResult();
        }

        private TextResult PrintInventory(string arg)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Machine.Slots.Count; i++)
            {
                result.AppendFormat("{0} [Qty: {1}] {2}", i + 1, Machine.Slots[i].Quantity, Machine.Slots[i].ProductName)
                    .AppendLine();
            }
            return new TextResult(result.ToString());
        }

        private TextResult NavigateToAdjustQuantity(string arg)
        {
            NavigationController.PushViewController(new AdjustQuantityMenu(Machine));
            return new EmptyResult();
        }

        private TextResult NavigateToNameItems(string arg)
        {
            NavigationController.PushViewController(new NameItemMenu(Machine));
            return new EmptyResult();
        }

        public static class Commands
        {

            public static readonly ActionCommand NameItems = new ActionCommand("1")
            {
                CommandDescription = "Set Product Name"
            };

            public static readonly ActionCommand AdjustQuantity = new ActionCommand("2")
            {
                CommandDescription = "Adjust Product Quantity"
            };

            public static readonly ActionCommand ViewInventory = new ActionCommand("3")
            {
                CommandDescription = "View Inventory"
            };

            public static readonly ActionCommand QuitToMenu = ActionCommandFactory.CreateQuitToMenuCommand();
        }
    }
}
