using System;
using System.Collections.Generic;
using VendingMachine.Framework.Exceptions;

namespace VendingMachine.Domain
{
    public class SodaMachine
    {
        private readonly IList<Slot> slots;
        public double CustomerBalance { get; private set; }
        public IList<Slot> Slots { get { return slots; } }

        public double MachineBalance { get; private set; }

        public SodaMachine(int numSlots)
        {
            slots = new List<Slot>();

            for (int i = 0; i < numSlots; i++)
                slots.Add(new Slot());
        }

        public void DepositCustomerMoney(double amountToAdd)
        {
            if (amountToAdd > 0 && amountToAdd*100 % 1 == 0)
            {
                CustomerBalance += amountToAdd;
            }
        }

        public string BuyItem(int slotNumber)
        {
            Slot selectedSlot = Slots[slotNumber - 1];

            ValidateCanPurchase(selectedSlot);

            selectedSlot.Quantity--;
                CustomerBalance -= selectedSlot.Cost;
                MachineBalance += selectedSlot.Cost;
                return selectedSlot.ProductName;
        }

        public double ReturnChange()
        {
            double change = CustomerBalance;
            CustomerBalance = 0;
            return change;
        }

        private void ValidateCanPurchase(Slot selectedSlot)
        {
            if (CustomerBalance < selectedSlot.Cost)
                throw new ValidationException("You did not put enough money to purchase a " + selectedSlot.ProductName);

            if (selectedSlot.IsEmpty)
                throw new SoldOutException(selectedSlot.ProductName);
        }

        public void DepositMachineMoney(double money)
        {
            MachineBalance += money;
        }
    }
}
