using System;
using System.Collections.Generic;
using VendingMachine.Controller;
using VendingMachine.DisplayResult;

namespace VendingMachine
{
    public abstract class BaseMenu : ViewController, IConsoleMenu
    {
        private readonly IDictionary<string, Func<string, TextResult>> commandsToHandlers =
            new Dictionary<string, Func<string, TextResult>>();

        private readonly SodaMachine machine;

        public abstract string DisplayPrompt { get; }

        protected IDictionary<string, Func<string, TextResult>> CommandsToHandlers
        {
            get { return commandsToHandlers; }
        }

        protected BaseMenu(SodaMachine machine)
        {
            this.machine = machine;
        }

        protected SodaMachine Machine
        {
            get { return machine; }
        }

        public virtual TextResult PerformAction(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
                return InvalidInput();

            string[] userInputSplit = userInput.Split();

            if (userInputSplit.Length == 0)
                return InvalidInput();

            string action = ParseAction(userInput);
            string argument = ParseArgument(userInput);
            if (!CommandsToHandlers.ContainsKey(action))
                return InvalidInput();

            return CommandsToHandlers[action](argument);
        }

        private TextResult InvalidInput()
        {
            return new TextResult(CommonMessages.InvalidOptionMessage);
        }

        public string ParseAction(string userInput)
        {
            string[] userInputSplit = userInput.Split();
            if (userInputSplit.Length < 1) return string.Empty;
            return userInputSplit[0].Trim();
        }
        public string ParseArgument(string userInput)
        {
            string action = ParseAction(userInput);
            if (string.IsNullOrEmpty(action)) return string.Empty;

            return userInput.Substring(userInput.IndexOf(action) + action.Length).Trim();
        }
    }
}