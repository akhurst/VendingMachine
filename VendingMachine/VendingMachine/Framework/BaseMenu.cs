using System.Linq;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Domain;
using VendingMachine.Framework.Results;

namespace VendingMachine.Framework
{
    public abstract class BaseMenu : IController
    {
        private readonly IList<ActionCommand> actionCommands =
            new List<ActionCommand>();

        private readonly SodaMachine machine;

        private string header = string.Empty;
        public virtual string DisplayPrompt
        {
            get
            {
                StringBuilder promptBuilder = new StringBuilder();
                promptBuilder.AppendLine(header).AppendLine();
                foreach (ActionCommand actionCommand in actionCommands)
                {
                    promptBuilder.AppendLine(FormatActionCommand(actionCommand));
                }
                return promptBuilder.ToString();
            }
        }

        public string FormatActionCommand(ActionCommand actionCommand)
        {
            string formattedActionCommand = string.Format("{0}:\t{1}", actionCommand.Command, actionCommand.CommandDescription);
            if (!string.IsNullOrEmpty(actionCommand.ArgumentDescription))
            {
                formattedActionCommand += string.Format("\r\n\t\t{0}", actionCommand.ArgumentDescription);
            }
            return formattedActionCommand;
        }

        protected IList<ActionCommand> ActionCommands
        {
            get { return actionCommands; }
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

        public virtual ActionResult PerformAction(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
                return new InvalidMenuOptionResult();

            string[] userInputSplit = userInput.Split();

            if (userInputSplit.Length == 0)
                return new InvalidMenuOptionResult();

            string inputCommand = GetFirstArgumentToken(userInput);
            string inputArgument = GetArgumentStringAfterFirstArgumentToken(userInput);

            ActionCommand selectedActionCommand = actionCommands.SingleOrDefault(c => c.Command.ToLower().Equals(inputCommand.ToLower()));

            if (selectedActionCommand == null)
                return new InvalidMenuOptionResult();

            return selectedActionCommand.CommandHandler(inputArgument);
        }

        public string GetFirstArgumentToken(string userInput)
        {
            string[] userInputSplit = userInput.Split();
            if (userInputSplit.Length < 1) return string.Empty;
            return userInputSplit[0].Trim();
        }
        public string GetArgumentStringAfterFirstArgumentToken(string userInput)
        {
            string command = GetFirstArgumentToken(userInput);
            if (string.IsNullOrEmpty(command)) return string.Empty;

            return userInput.Substring(userInput.IndexOf(command) + command.Length).Trim();
        }
    }
}