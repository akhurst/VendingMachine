using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class AdminMenu : BaseMenu
    {
        public const string MenuFormatString = "Admin Menu\n1: Set Product Name\n2: Adjust Product Quantity\nQ: Quit";

        public AdminMenu(SodaMachine machine) : base(machine)
        {
            CommandsToHandlers.Add(Commands.NameItems,NavigateToNameItems);
            CommandsToHandlers.Add(Commands.AdjustQuantity,NavigateToAdjustQuantity);
            CommandsToHandlers.Add(Commands.ViewInventory, PrintInventory);
        }

        private ActionResult PrintInventory(string arg)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Machine.Slots.Count; i++)
            {
                result.AppendFormat("{0} [Qty: {1}] {2}", i + 1, Machine.Slots[i].Quantity, Machine.Slots[i].ProductName)
                    .AppendLine();
            }
            return new ActionResult(result.ToString());
        }

        private ActionResult NavigateToAdjustQuantity(string arg)
        {
            return new ActionResult(new AdjustQuantityMenu(Machine));
        }

        private ActionResult NavigateToNameItems(string arg)
        {
            return new ActionResult(new NameItemMenu(Machine));
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
        }
    }
}
