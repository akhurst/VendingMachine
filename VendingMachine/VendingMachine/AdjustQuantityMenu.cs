using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class AdjustQuantityMenu : BaseMenu
    {
        public const string MenuFormatString = "Enter the slot number [1-10] then the new quantity[0-{0}] ex. [1 10]\nOr enter Q to Quit";
        public const string RenameConfirmationFormatString = "Slot {0}'s new quantity is {1}";

        public AdjustQuantityMenu(SodaMachine machine) : base(machine)
        {
        }

        public override string DisplayPrompt
        {
            get { return string.Format(MenuFormatString,Slot.MaximumQuantity); }
        }

        protected override ActionResult PerformMenuAction(string action, string argument)
        {
            int slotNumber;

            if (!int.TryParse(action, out slotNumber))
                return new ActionResult();

            if (slotNumber < 1 || slotNumber > 10)
                return new ActionResult();

            int newQuantity;

            if(!int.TryParse(argument, out newQuantity))
                return new ActionResult();

            Machine.Slots[slotNumber - 1].Quantity = newQuantity;
            this.IsActive = false;
            return new ActionResult(string.Format("Slot {0}'s new quantity is {1}", action, newQuantity));
        }

    }
}
