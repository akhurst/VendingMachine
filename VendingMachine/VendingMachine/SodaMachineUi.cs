using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Controller;
using VendingMachine.DisplayResult;
using VendingMachine.Menu;
using VendingMachine.Menu.SodaMenu;

namespace VendingMachine
{
    public class SodaMachineUi : NavigationController, IConsoleMenu
    {
        private SodaMachine machine;

        public SodaMachineUi():this(new SodaMachine(10)){}

        public SodaMachineUi(SodaMachine machine) : base(new MainMenu(machine))
        {      
            this.machine = machine;
        }

        public string DisplayPrompt
        {
            get
            {
                IConsoleMenu uiMenu = TopViewController as IConsoleMenu;
                return uiMenu.DisplayPrompt;
            }
        }

        public TextResult PerformAction(string userInput)
        {
            IConsoleMenu uiMenu = TopViewController as IConsoleMenu;
            return uiMenu.PerformAction(userInput);
        }
    }
}
