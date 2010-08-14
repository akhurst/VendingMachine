using System.Collections.Generic;

namespace VendingMachine.Domain
{
    public class SodaMachine
    {
        private readonly IList<Slot> slots;
        public double CustomerBalance { get; private set; }
        public IList<Slot> Slots { get { return slots; } }

        public SodaMachine(int numSlots)
        {
            slots = new List<Slot>();

            for (int i = 0; i < numSlots; i++)
                slots.Add(new Slot());
        }

        public void AddMoney(double amountToAdd)
        {
            if (amountToAdd > 0 && amountToAdd*100 % 1 == 0)
            {
                CustomerBalance += amountToAdd;
            }
        }
    }
}
