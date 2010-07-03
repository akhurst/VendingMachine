using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Menu;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsoleMenu ui = new SodaMachineUi();

            while (true)
            {
                Console.WriteLine(ui.DisplayPrompt);
                Console.Write(">");
                Console.WriteLine(ui.PerformAction(Console.ReadLine()));
                Console.WriteLine("---------------------------------------------------------");
            }
        }
    }
}
