using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Framework.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(string message) : base(message) { }
    }
}
