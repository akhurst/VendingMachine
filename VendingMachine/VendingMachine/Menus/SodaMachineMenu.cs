using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Domain;
using VendingMachine.Framework;

namespace VendingMachine.Menus
{
    public abstract class SodaMachineMenu : BaseMenu
    {
        private readonly SodaMachine machine;

        protected SodaMachineMenu(SodaMachine machine)
        {
            this.machine = machine;
        }

        protected SodaMachineMenu(SodaMachine machine, string header)
            : base(header)
        {
            this.machine = machine;
        }

        protected SodaMachine Machine
        {
            get { return machine; }
        }
    }
}