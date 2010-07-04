using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.DisplayResult;

namespace VendingMachine.Menu.SodaMenu
{
    public class StockerMenu : BaseMenu
    {
        public StockerMenu(SodaMachine machine) : base(machine, "Stocker Menu")
        {
            ActionCommandHandlers.Add(Commands.NameItems,HandleNameItem);
            ActionCommandHandlers.Add(Commands.AdjustQuantity,HandleAdjustQuantity);
            ActionCommandHandlers.Add(Commands.ViewInventory, HandlePrintInventory);
            ActionCommandHandlers.Add(Commands.QuitToMenu, QuitToMenu);
        }

        private TextResult QuitToMenu(string arg)
        {
            NavigationController.PopToRootViewController();
            return new EmptyResult();
        }

        private TextResult HandlePrintInventory(string arg)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Machine.Slots.Count; i++)
            {
                result.AppendFormat("{0,2} [Qty: {1,2}] {2}", i + 1, Machine.Slots[i].Quantity, Machine.Slots[i].ProductName)
                    .AppendLine();
            }
            return new TextResult(result.ToString());
        }

        private TextResult HandleAdjustQuantity(string arg)
        {
            string slotNumberInput = GetFirstArgumentToken(arg);
            string quantityInput = GetArgumentStringAfterFirstArgumentToken(arg);
            int slotNumber;

            if (!int.TryParse(slotNumberInput, out slotNumber))
                return new InvalidInputResult();

            if (slotNumber < 1 || slotNumber > 10)
                return new InvalidInputResult();

            int newQuantity;

            if (!int.TryParse(quantityInput, out newQuantity))
                return new InvalidInputResult();

            Machine.Slots[slotNumber - 1].Quantity = newQuantity;
            return new TextResult(string.Format("Slot {0}'s new quantity is {1}", slotNumber, newQuantity));
        }

        private TextResult HandleNameItem(string arg)
        {
            string slotNumberInput = GetFirstArgumentToken(arg);
            string productNameInput = GetArgumentStringAfterFirstArgumentToken(arg);

            int slotNumber;

            if (!int.TryParse(slotNumberInput, out slotNumber))
                return new InvalidInputResult();

            if (slotNumber < 1 || slotNumber > 10)
                return new InvalidInputResult();

            if (string.IsNullOrEmpty(productNameInput))
                return new InvalidInputResult();

            Machine.Slots[slotNumber - 1].ProductName = productNameInput;

            return new TextResult(string.Format("Slot {0}'s new name is {1}", slotNumberInput, productNameInput));
        }

        public static class Commands
        {

            public static readonly ActionCommand NameItems = new ActionCommand("set")
            {
                CommandDescription = "Set Product Name",
                ArgumentDescription = "<slot #> <product name>"
            };

            public static readonly ActionCommand AdjustQuantity = new ActionCommand("qty")
            {
                CommandDescription = "Adjust Product Quantity",
                ArgumentDescription = "<slot #> <quantity>"
            };

            public static readonly ActionCommand ViewInventory = new ActionCommand("inv")
            {
                CommandDescription = "View Inventory"
            };

            public static readonly ActionCommand QuitToMenu = ActionCommandFactory.CreateQuitToMenuCommand();
        }
    }
}
