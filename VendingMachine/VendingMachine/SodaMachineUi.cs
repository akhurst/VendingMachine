using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
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

        public string DisplayPrompt
        {
            get
            {
                return controllers.Peek().DisplayPrompt;
            }
        }

        public string PerformAction(string userInput)
        {
            ActionResult result = controllers.Peek().PerformAction(userInput);

            if (!controllers.Peek().IsActive)
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
