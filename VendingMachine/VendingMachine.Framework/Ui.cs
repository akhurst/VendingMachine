using System.Collections.Generic;
using VendingMachine.Framework.Results;

namespace VendingMachine.Framework
{
    public abstract class Ui
    {
        protected Stack<IController> Controllers{ get; private set;}

        public Ui()
        {
            this.Controllers = new Stack<IController>();
            this.IsActive = true;
        }

        public bool IsActive { get; private set; }

        public IController ActiveController { get { return Controllers.Peek(); } }

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
                Controllers.Pop();

                if (Controllers.Count == 0)
                    this.IsActive = false;
            }

            if(result.NextController != null)
            {
                Controllers.Push(result.NextController);
            }

            return result.Output;
        }
    }
}
