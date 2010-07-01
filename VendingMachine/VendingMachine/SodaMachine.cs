using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class SodaMachine
    {
        private readonly IList<Slot> slots;
        public IList<Slot> Slots { get { return slots; } }

        public SodaMachine(int numSlots)
        {
            slots = new List<Slot>();

            for(int i=0;i<numSlots;i++)
                slots.Add(new Slot());
        }
    }
}
