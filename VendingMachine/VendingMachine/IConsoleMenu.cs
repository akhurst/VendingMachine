using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.DisplayResult;

namespace VendingMachine
{
    public interface IConsoleMenu
    {
        string DisplayPrompt { get; }
        TextResult PerformAction(string userInput);
    }
}
