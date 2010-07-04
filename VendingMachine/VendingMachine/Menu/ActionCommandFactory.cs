using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Menu
{
    public static class ActionCommandFactory
    {
        public static ActionCommand CreateQuitCommand()
        {
            return new ActionCommand("q") 
            { CommandDescription = "Quit Program." };
        }

        public static ActionCommand CreateQuitToMenuCommand()
        {
            return new ActionCommand("q") 
            { CommandDescription = "Quit to Main Menu." };
        }
    }
}
