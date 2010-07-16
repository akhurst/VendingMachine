using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Framework.Exceptions
{
    public class SoldOutException : ApplicationException
    {
        public const string MessageFormat = "{0} is sold out";
        public SoldOutException(string productName) : base(string.Format(MessageFormat,productName))
        {}
    }
}
