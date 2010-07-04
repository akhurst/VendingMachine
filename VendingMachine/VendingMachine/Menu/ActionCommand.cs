using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Menu
{
    public sealed class ActionCommand
    {
        public string Command { get; private set; }
        public string CommandDescription { get; set; }
        public string ArgumentDescription { get; set; }

        public ActionCommand(string command) 
        {
            this.Command = command;
        }

        public override string ToString()
        {            
            return Command;
        }

    }
}
