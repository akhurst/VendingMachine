using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.DisplayResult;

namespace VendingMachine
{
    public class AdminMenu : BaseMenu
    {
        public const string MenuFormatString = "Admin Menu\n1: Set Product Name\n2: Adjust Product Quantity\nQ: Quit to Menu";

        public AdminMenu(SodaMachine machine) : base(machine)
        {
            CommandsToHandlers.Add(Commands.NameItems,NavigateToNameItems);
            CommandsToHandlers.Add(Commands.AdjustQuantity,NavigateToAdjustQuantity);
            CommandsToHandlers.Add(Commands.ViewInventory, PrintInventory);
            CommandsToHandlers.Add(Commands.QuitToMenu, QuitToMenu);
            CommandsToHandlers.Add(Commands.QuitToMenuAlternative, QuitToMenu);
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

        public override string DisplayPrompt
        {
            get { return MenuFormatString; }
        }

        public static class Commands
        {
            public const string NameItems = "1";
            public const string AdjustQuantity = "2";
            public const string ViewInventory = "3";
            public const string QuitToMenu = "q";
            public const string QuitToMenuAlternative = "Q";
        }
    }
}
