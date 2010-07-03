using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.DisplayResult
{
    public class EmptyResult : TextResult
    {
        public EmptyResult() : base(string.Empty) {}
        
    }
}
