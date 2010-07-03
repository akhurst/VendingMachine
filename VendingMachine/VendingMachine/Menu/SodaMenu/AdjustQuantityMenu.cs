using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.DisplayResult;

namespace VendingMachine.Menu.SodaMenu
{
    public class AdjustQuantityMenu : BaseMenu
    {
        public const string MenuFormatString = "Enter the slot number [1-10] then the new quantity[0-{0}] ex. [1 10]\nOr enter Q to Quit To Menu";
        public const string RenameConfirmationFormatString = "Slot {0}'s new quantity is {1}";

        public AdjustQuantityMenu(SodaMachine machine) : base(machine)
        {
        }

        public override string DisplayPrompt
        {
            get { return string.Format(MenuFormatString,Slot.MaximumQuantity); }
        }

        public override TextResult PerformAction(string userInput)
        {
            string action = ParseCommand(userInput);
            string argument = ParseArgument(userInput);

            if(action.Equals("q") || action.Equals("Q")) 
            {
                NavigationController.PopToRootViewController();
                return new EmptyResult();
            }
            int slotNumber;

            if (!int.TryParse(action, out slotNumber))
                return new EmptyResult();

            if (slotNumber < 1 || slotNumber > 10)
                return new EmptyResult();

            int newQuantity;

            if(!int.TryParse(argument, out newQuantity))
                return new EmptyResult();

            Machine.Slots[slotNumber - 1].Quantity = newQuantity;
            return new TextResult(string.Format("Slot {0}'s new quantity is {1}", action, newQuantity));
        }

    }
}
