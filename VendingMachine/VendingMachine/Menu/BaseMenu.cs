using System;
using System.Linq;
using System.Collections.Generic;
using VendingMachine.Controller;
using VendingMachine.DisplayResult;
using System.Text;

namespace VendingMachine.Menu
{
    public abstract class BaseMenu : ViewController, IConsoleMenu
    {
        private readonly IDictionary<ActionCommand, Func<string, TextResult>> actionCommandHandlers =
            new Dictionary<ActionCommand, Func<string, TextResult>>();

        private readonly SodaMachine machine;

        private string header = string.Empty;
        public virtual string DisplayPrompt
        {
            get
            {
                StringBuilder promptBuilder = new StringBuilder();
                promptBuilder.AppendLine(header).AppendLine();
                foreach(ActionCommand actionCommand in actionCommandHandlers.Keys) 
                {
                    promptBuilder.AppendLine(FormatActionCommand(actionCommand));
                }
                return promptBuilder.ToString();
            }
        }

        public string FormatActionCommand(ActionCommand actionCommand) {
            string formattedActionCommand = string.Format("{0}\t{1}", actionCommand.Commands[0], actionCommand.CommandDescription);
            if (!string.IsNullOrEmpty(actionCommand.ArgumentDescription))
            {
                formattedActionCommand += string.Format("\r\n\t{0}", actionCommand.ArgumentDescription);
            }
            return formattedActionCommand;
        }

        protected IDictionary<ActionCommand, Func<string, TextResult>> ActionCommandHandlers
        {
            get { return actionCommandHandlers; }
        }

        protected BaseMenu(SodaMachine machine)
        {
            this.machine = machine;
        }

        protected BaseMenu(SodaMachine machine, string header)
        {
            this.machine = machine;
            this.header = header;
        }

        protected SodaMachine Machine
        {
            get { return machine; }
        }

        public virtual TextResult PerformAction(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
                return new InvalidInputResult();

            string[] userInputSplit = userInput.Split();

            if (userInputSplit.Length == 0)
                return new InvalidInputResult();

            string command = ParseCommand(userInput);
            string argument = ParseArgument(userInput);

            ActionCommand selectedActionCommand = null;
            foreach (ActionCommand actionCommand in actionCommandHandlers.Keys)
            {
                if (actionCommand.Commands.Contains(command))
                {
                    selectedActionCommand = actionCommand;
                    break;
                }
            }
            if (selectedActionCommand == null) 
                return new InvalidInputResult();

            return actionCommandHandlers[selectedActionCommand](argument);
        }

        public string ParseCommand(string userInput)
        {
            string[] userInputSplit = userInput.Split();
            if (userInputSplit.Length < 1) return string.Empty;
            return userInputSplit[0].Trim();
        }
        public string ParseArgument(string userInput)
        {
            string command = ParseCommand(userInput);
            if (string.IsNullOrEmpty(command)) return string.Empty;

            return userInput.Substring(userInput.IndexOf(command) + command.Length).Trim();
        }
    }
}