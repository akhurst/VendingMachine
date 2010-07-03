using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Menu
{
    public sealed class ActionCommand
    {
        public string[] Commands { get; private set; }
        public string CommandDescription { get; set; }
        public string ArgumentDescription { get; set; }

        public ActionCommand(params string[] commands) 
        {
            if (commands.Length == 0) throw new Exception("ActionCommand must contain at least one command.");
            Commands = commands;
        }

        public override string ToString()
        {
            if (Commands.Length == 0) return string.Empty;
            return Commands[0];
        }

    }
}
