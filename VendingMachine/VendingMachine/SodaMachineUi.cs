using VendingMachine.Domain;
using VendingMachine.Framework;
using VendingMachine.Menus;

namespace VendingMachine
{
    public class SodaMachineUi : Ui
    {
        private SodaMachine machine;

        public SodaMachineUi():this(new SodaMachine(10)){}

        public SodaMachineUi(SodaMachine machine)
        {
            this.machine = machine;
            this.Controllers.Push(new MainMenu(machine));
        }
    }
}
