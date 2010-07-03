using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.DisplayResult
{
    public class TextResult
    {
        private string result = string.Empty;

        public TextResult(string text) { result = text; }

        public override string ToString()
        {
            return result;
        }
    }
}
