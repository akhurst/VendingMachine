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

            new UiRunner().Run(ui);
        }
    }
}
