using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class SodaMachine
    {
        private readonly IList<Slot> slots;
        private readonly int numberOfSlots;
        public int NumberOfSlots { get { return this.numberOfSlots; } }
        public double CustomerBalance { get; private set; }
        public IList<Slot> Slots { get { return slots; } }

        public SodaMachine(int numSlots)
        {
            this.numberOfSlots = numSlots;
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
