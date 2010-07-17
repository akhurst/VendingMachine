using System.Text;
using VendingMachine.Domain;
using VendingMachine.Framework;
using VendingMachine.Framework.Results;

namespace VendingMachine.Menus
{
    public class AdminMenu : SodaMachineMenu
    {
        public AdminMenu(SodaMachine machine)
            : base(machine, "Stocker Menu")
        {
            ActionCommands.Add(ActionCommandFactory.CreateQuitToPreviousMenuCommand(QuitToPreviousMenu));
        }

        private ActionResult QuitToPreviousMenu(string arg)
        {
            return new QuitMenuResult();
        }

        public static class Commands
        {
        }
    }
}
