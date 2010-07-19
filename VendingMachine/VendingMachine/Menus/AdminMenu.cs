using System;
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
            ActionCommands.Add(new ActionCommand(Commands.SetName,HandleSetName));
            ActionCommands.Add(new ActionCommand(Commands.SetQuantity, HandleSetQuantity));
            ActionCommands.Add(ActionCommandFactory.CreateQuitToPreviousMenuCommand(QuitToPreviousMenu));
        }

        private ActionResult HandleSetQuantity(string arg)
        {
            int slotNumber;
            int quantity;

            string firstArgument = this.GetFirstArgumentToken(arg);
            string secondArgument = this.GetArgumentStringAfterFirstArgumentToken(arg);

            if (!int.TryParse(firstArgument, out slotNumber))
                return new InvalidArgumentResult();

            if (!int.TryParse(secondArgument, out quantity))
                return new InvalidArgumentResult();

            Machine.SetQuantity(slotNumber, quantity);

            return new TextResult("Slot {0} now contains {1} items");
        }

        private ActionResult HandleSetName(string arg)
        {
            int slotNumber;

            string firstArgument = this.GetFirstArgumentToken(arg);
            string productName = this.GetArgumentStringAfterFirstArgumentToken(arg);

            if(!int.TryParse(firstArgument,out slotNumber))
            {
                return new InvalidArgumentResult();
            }
            Machine.SetName(slotNumber, productName);
            return new TextResult(string.Format("Slot number {0} is now {1}.", slotNumber, productName));
        }

        private ActionResult QuitToPreviousMenu(string arg)
        {
            return new QuitMenuResult();
        }

        public static class Commands
        {
            public static ActionCommandMetadata SetName = new ActionCommandMetadata
                                                       {
                                                           Command = "setname",
                                                           CommandDescription = "Setting the name of the slot",
                                                           ArgumentDescription = "<slot number> <product name>"

                                                       };

            public static ActionCommandMetadata SetQuantity = new ActionCommandMetadata
                                                                  {
                                                                      Command = "setquantity",
                                                                      CommandDescription = "Set a slots quantity",
                                                                      ArgumentDescription = "<slot number> <product name>"
        };
        }
    }
}
