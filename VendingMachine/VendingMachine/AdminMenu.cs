using System.Text;

namespace VendingMachine
{
    public class StockerMenu : BaseMenu
    {
        public StockerMenu(SodaMachine machine)
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
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Machine.Slots.Count; i++)
            {
                result.AppendFormat("{0,2} [Qty: {1,2}] {2}", i + 1, Machine.Slots[i].Quantity, Machine.Slots[i].ProductName)
                    .AppendLine();
            }
            return new TextResult(result.ToString());
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

            Machine.Slots[slotNumber - 1].Quantity = newQuantity;
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

            Machine.Slots[slotNumber - 1].ProductName = productNameInput;

            return new TextResult(string.Format("Slot {0}'s new name is {1}", slotNumberInput, productNameInput));
        }

        public static class Commands
        {

            public static readonly ActionCommandMetadata NameItems = new ActionCommandMetadata
            {
                Command = "set",
                CommandDescription = "Set Product Name",
                ArgumentDescription = "<slot #> <product name>"
            };

            public static readonly ActionCommandMetadata AdjustQuantity = new ActionCommandMetadata
            {
                Command = "qty",
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
