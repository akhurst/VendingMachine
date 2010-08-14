using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class InvalidArgumentResult : TextResult
    {
        public InvalidArgumentResult() : base("You entered an invalid argument")
        {}
    }
}
