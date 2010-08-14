using System.Collections.Generic;
using VendingMachine.Domain;
using VendingMachine.Framework.Results;
using VendingMachine.Menus;

namespace VendingMachine.Framework
{
    public class SodaMachineUi
    {
        private readonly Stack<IController> controllers;

        private SodaMachine machine;

        public SodaMachineUi():this(new SodaMachine(10)){}

        public SodaMachineUi(SodaMachine machine)
        {
            this.machine = machine;
            this.controllers = new Stack<IController>();
            this.controllers.Push(new MainMenu(machine));
            this.IsActive = true;
        }

        public bool IsActive { get; private set; }

        public IController ActiveController { get { return controllers.Peek(); } }

        public string DisplayPrompt
        {
            get
            {
                return ActiveController.DisplayPrompt;
            }
        }

        public string PerformAction(string userInput)
        {
            ActionResult result = ActiveController.PerformAction(userInput);

            if (result.QuitController)
            {
                controllers.Pop();

                if(controllers.Count == 0)
                    this.IsActive = false;
            }

            if(result.NextController != null)
            {
                controllers.Push(result.NextController);
            }

            return result.Output;
        }
    }
}
