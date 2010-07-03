using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
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

    }
}
