using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class MainMenu : BaseMenu
    {
        public const string MainMenuFormat = "Main Menu\n1: Admin Menu\nQ: Quit";

        public MainMenu(SodaMachine machine) : base(machine)
        {
            CommandsToHandlers.Add("1", NavigateToAdminMenu);
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
    }
}
