using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.DisplayResult;

namespace VendingMachine.Menu.SodaMenu
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

        public override TextResult PerformAction(string userInput)
        {
            string action = ParseCommand(userInput);
            string argument = ParseArgument(userInput);

            if (action.Equals('q') || action.Equals('Q'))
            {
                NavigationController.PopToRootViewController();
                return new EmptyResult();
            }

            int slotNumber;

            if(!int.TryParse(action, out slotNumber))
                return new TextResult(InvalidSlotString);

            if(slotNumber < 1 || slotNumber > 10)
                return new TextResult(InvalidSlotString);

            if(string.IsNullOrEmpty(argument))
                return new TextResult(InvalidNameString);

            Machine.Slots[slotNumber - 1].ProductName = argument;            

            return new TextResult(string.Format("Slot {0}'s new name is {1}",action,argument));
        }
    }
}
