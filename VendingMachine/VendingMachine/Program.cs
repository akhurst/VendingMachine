using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Framework;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            SodaMachineUi ui = new SodaMachineUi();

            while (ui.IsActive)
            {
                Console.WriteLine(ui.DisplayPrompt);
                Console.WriteLine(ui.PerformAction(Console.ReadLine()));
            }
        }
    }
}
