using System;

namespace VendingMachine.Framework.Exceptions
{
    public class SoldOutException : ApplicationException
    {
        public const string MessageFormat = "{0} is sold out";
        public SoldOutException(string productName) : base(string.Format(MessageFormat,productName))
        {}
    }
}
