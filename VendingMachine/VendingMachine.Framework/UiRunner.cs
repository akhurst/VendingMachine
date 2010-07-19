using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Framework
{
    public class UiRunner
    {
        public void Run(Ui ui)
        {
            while (ui.IsActive)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine(ui.DisplayPrompt);
                Console.Write(">");
                Console.WriteLine(ui.PerformAction(Console.ReadLine()));
            }
        }
    }
}
