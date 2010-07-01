using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class SodaMachineUi
    {
        private Stack<IController> controllers;

        public SodaMachineUi()
        {
            this.controllers = new Stack<IController>();
            this.controllers.Push(new MainMenu());
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
