using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public abstract class BaseMenu : IController
    {
        private readonly IDictionary<string, Func<string, ActionResult>> commandsToHandlers =
            new Dictionary<string, Func<string, ActionResult>>();

        private readonly SodaMachine machine;

        protected BaseMenu(SodaMachine machine)
        {
            this.machine = machine;
            IsActive = true;
        }

        protected IDictionary<string, Func<string, ActionResult>> CommandsToHandlers
        {
            get { return commandsToHandlers; }
        }

        public abstract string DisplayPrompt { get; }
        public bool IsActive { get; protected set; }

        protected SodaMachine Machine
        {
            get { return machine; }
        }

        public virtual ActionResult PerformAction(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
                return new ActionResult(CommonMessages.InvalidOptionMessage);

            string[] userInputSplit = userInput.Split();

            if(userInputSplit.Length == 0)
                return new ActionResult(CommonMessages.InvalidOptionMessage);

            string action = userInputSplit[0].Trim();
            string argument = userInput.Substring(userInput.IndexOf(action) + action.Length).Trim();

            switch (action)
            {
                case "q":
                case "Q":
                    return Quit();
                default:
                    return PerformMenuAction(action, argument);
            }
        }

        protected virtual ActionResult InvalidInput()
        {
            return new ActionResult(CommonMessages.InvalidOptionMessage);
        }

        protected virtual ActionResult PerformMenuAction(string action, string argument)
        {
            if (!CommandsToHandlers.ContainsKey(action))
                return InvalidInput();

            return CommandsToHandlers[action](argument);
        }

        protected virtual ActionResult Quit()
        {
            IsActive = false;
            return new ActionResult();
        }
    }
}