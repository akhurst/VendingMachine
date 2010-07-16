using System;

namespace VendingMachine.Domain
{
    public class Slot
    {
        public const int MaximumQuantity = 20;
        public string ProductName { get; set; }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value <= MaximumQuantity && value >= 0)
                {
                    quantity = value;
                }
            }
        }

        public const double DefaultCost = .75;
        public double Cost { get { return DefaultCost; } }

        public bool IsEmpty
        {
            get{return Quantity == 0;}
        }
    }
}
