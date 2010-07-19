using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Framework.Exceptions;

namespace VendingMachine.Domain
{
    public class SodaMachine
    {
        private readonly IList<Slot> slots;
        public IList<Slot> Slots { get { return slots; } }

        public SodaMachine(int numSlots)
        {
            slots = new List<Slot>();

            for (int i = 0; i < numSlots; i++)
                slots.Add(new Slot());
        }

        public void AdjustQuantity(int slotNumber, int newQuantity)
        {
            Slot selectedSlot = GetSlot(slotNumber);
            selectedSlot.Quantity = newQuantity;
        }

        public void NameProduct(int slotNumber, string productNameInput)
        {
            Slot selectedSlot = GetSlot(slotNumber);
            selectedSlot.ProductName = productNameInput;
        }

        private Slot GetSlot(int slotNumber)
        {
            return Slots[slotNumber - 1];
        }

        public string GetInventoryPrintout()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Slots.Count; i++)
            {
                result.AppendFormat("{0,2} [Qty: {1,2}] {2}", i + 1, Slots[i].Quantity, Slots[i].ProductName)
                    .AppendLine();
            }
            return result.ToString();
        }
    }
}
