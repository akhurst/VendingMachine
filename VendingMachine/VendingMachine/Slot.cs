using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class Slot
    {
        public string ProductName { get; set; }
        public int Quantity { get; private set; }

        public void AddItems(int numItems)
        {
            Quantity += numItems;
        }
    }
}
