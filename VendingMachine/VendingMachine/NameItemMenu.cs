using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class NameItemMenu : BaseMenu
    {
        public const string MenuFormatString = "Enter the slot number [1-10] then the new name ex. [1 Coca Cola]\nOr enter Q to Quit";
        public const string InvalidNameString = "Please provide a valid product name";
        public const string InvalidSlotString = "Please provide a valid slot number";
        public const string RenameConfirmationFormatString = "Slot {0}'s new name is {1}";

        public NameItemMenu(SodaMachine machine) : base(machine){}

        public override string DisplayPrompt
        {
            get { return MenuFormatString; }
        }

        protected override ActionResult PerformMenuAction(string action, string argument)
        {
            int slotNumber;

            if(!int.TryParse(action, out slotNumber))
                return new ActionResult(InvalidSlotString);

            if(slotNumber < 1 || slotNumber > 10)
                return new ActionResult(InvalidSlotString);

            if(string.IsNullOrEmpty(argument))
                return new ActionResult(InvalidNameString);

            Machine.Slots[slotNumber - 1].ProductName = argument;            

            return new ActionResult(string.Format("Slot {0}'s new name is {1}",action,argument)){QuitController = true};
        }
    }
}
