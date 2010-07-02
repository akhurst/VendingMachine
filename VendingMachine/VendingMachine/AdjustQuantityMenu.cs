using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class AdjustQuantityMenu : BaseMenu
    {
        public const string MenuFormatString = "Enter the slot number [1-10] then the new quantity[0-20] ex. [1 10]\nOr enter Q to Quit";
        public const string InvalidQuantityString = "Please provide a valid quantity";
        public const string InvalidSlotString = "Please provide a valid slot number";
        public const string RenameConfirmationFormatString = "Slot {0}'s new quantity is {1}";

        public AdjustQuantityMenu(SodaMachine machine) : base(machine)
        {
        }

        public override string DisplayPrompt
        {
            get { return MenuFormatString; }
        }

        protected override ActionResult PerformMenuAction(string action, string argument)
        {
            int slotNumber;

            if (!int.TryParse(action, out slotNumber))
                return new ActionResult(InvalidSlotString);

            if (slotNumber < 1 || slotNumber > 10)
                return new ActionResult(InvalidSlotString);

            int newQuantity;

            if(!int.TryParse(argument, out newQuantity))
                return new ActionResult(InvalidQuantityString);

            if(slotNumber < 0 || slotNumber > 20)
                return new ActionResult(InvalidQuantityString);

            Machine.Slots[slotNumber - 1].Quantity = newQuantity;
            this.IsActive = false;

            return new ActionResult(string.Format("Slot {0}'s new quantity is {1}", action, newQuantity));
        }

    }
}
