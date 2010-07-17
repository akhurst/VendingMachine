using System;
using System.Text;
using VendingMachine.Domain;
using VendingMachine.Framework;
using VendingMachine.Framework.Results;
using VendingMachine.Framework.Exceptions;

namespace VendingMachine.Menus
{
    public class MainMenu : SodaMachineMenu
    {
        public MainMenu(SodaMachine machine)
            : base(machine, "Main Menu")
        {
            ActionCommands.Add(new ActionCommand(Commands.AdminMenu, NavigateToAdminMenu));

            ActionCommands.Add(ActionCommandFactory.CreateQuitToPreviousMenuCommand(Quit));
        }

        private ActionResult Quit(string arg)
        {
            return new QuitMenuResult();
        }

        private ActionResult NavigateToAdminMenu(string argument)
        {
            return new NavigateResult(new AdminMenu(Machine));
        }

        public static class Commands
        {
            public static readonly ActionCommandMetadata AdminMenu = new ActionCommandMetadata
            {
                Command = "admin",
                CommandDescription = "Admin Menu"
            };
        }
    }
}
