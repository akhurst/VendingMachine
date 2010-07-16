using System;

namespace VendingMachine.Framework.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(string message) : base(message) { }
    }
}
