using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.DisplayResult
{
    public class InvalidInputResult : TextResult
    {
        public InvalidInputResult() : base("Invalid input. Please try again.") { }
    }
}
