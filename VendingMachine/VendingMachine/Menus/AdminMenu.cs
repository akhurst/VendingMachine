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
            ActionCommands.Add(new ActionCommand(Commands.NameItems, HandleNameItem));
            ActionCommands.Add(new ActionCommand(Commands.AdjustQuantity, HandleAdjustQuantity));
            ActionCommands.Add(new ActionCommand(Commands.ViewInventory, HandlePrintInventory));
            ActionCommands.Add(ActionCommandFactory.CreateQuitToPreviousMenuCommand(QuitToPreviousMenu));
        }

        private ActionResult QuitToPreviousMenu(string arg)
        {
            return new QuitMenuResult();
        }

        private ActionResult HandlePrintInventory(string arg)
        {
            return new TextResult(Machine.GetInventoryPrintout());
        }

        

        private ActionResult HandleAdjustQuantity(string arg)
        {
            string slotNumberInput = GetFirstArgumentToken(arg);
            string quantityInput = GetArgumentStringAfterFirstArgumentToken(arg);
            int slotNumber;

            if (!int.TryParse(slotNumberInput, out slotNumber))
                return new InvalidMenuOptionResult();

            if (slotNumber < 1 || slotNumber > 10)
                return new InvalidMenuOptionResult();

            int newQuantity;

            if (!int.TryParse(quantityInput, out newQuantity))
                return new InvalidMenuOptionResult();

            Machine.AdjustQuantity(slotNumber, newQuantity);

            return new TextResult(string.Format("Slot {0}'s new quantity is {1}", slotNumber, newQuantity));
        }

        private ActionResult HandleNameItem(string arg)
        {
            string slotNumberInput = GetFirstArgumentToken(arg);
            string productNameInput = GetArgumentStringAfterFirstArgumentToken(arg);

            int slotNumber;

            if (!int.TryParse(slotNumberInput, out slotNumber))
                return new InvalidMenuOptionResult();

            if (slotNumber < 1 || slotNumber > 10)
                return new InvalidMenuOptionResult();

            if (string.IsNullOrEmpty(productNameInput))
                return new InvalidMenuOptionResult();

            Machine.NameProduct(slotNumber, productNameInput);

            return new TextResult(string.Format("Slot {0}'s new name is {1}", slotNumberInput, productNameInput));
        }

        public static class Commands
        {
            public static readonly ActionCommandMetadata NameItems = new ActionCommandMetadata
            {
                Command = "setname",
                CommandDescription = "Set Product Name",
                ArgumentDescription = "<slot #> <product name>"
            };

            public static readonly ActionCommandMetadata AdjustQuantity = new ActionCommandMetadata
            {
                Command = "setqty",
                CommandDescription = "Adjust Product Quantity",
                ArgumentDescription = "<slot #> <quantity>"
            };

            public static readonly ActionCommandMetadata ViewInventory = new ActionCommandMetadata
            {
                Command = "inv",
                CommandDescription = "View Inventory"
            };
        }
    }
}
