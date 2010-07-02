using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class AdminMenu : BaseMenu
    {
        public const string MenuFormatString = "Admin Menu\n1: Set Product Name\n2: Adjust Product Quantity";

        public AdminMenu(SodaMachine machine) : base(machine)
        {
            CommandsToHandlers.Add("1",NavigateToNameItems);
        }

        private ActionResult NavigateToNameItems(string arg)
        {
            return new ActionResult(new NameItemMenu(Machine));
        }

        public override string DisplayPrompt
        {
            get { return MenuFormatString; }
        }
    }
}
