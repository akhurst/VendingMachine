using System;

namespace VendingMachine
{
    public sealed class ActionCommand
    {
        private readonly ActionCommandMetadata metadata;

        public ActionCommand(ActionCommandMetadata metadata, Func<string, ActionResult> handler)
        {
            CommandHandler = handler;
            this.metadata = metadata;
        }

        public string ArgumentDescription
        {
            get { return metadata.ArgumentDescription; }
        }

        public string Command
        {
            get { return metadata.Command; }
        }

        public string CommandDescription
        {
            get { return metadata.CommandDescription; }
        }

        public Func<string, ActionResult> CommandHandler { get; private set; }

        public override string ToString()
        {
            return Command;
        }
    }

    public sealed class ActionCommandMetadata
    {
        public string ArgumentDescription { get; set; }
        public string Command { get; set; }
        public string CommandDescription { get; set; }

        public override string ToString()
        {
            return Command;
        }
    }

    public static class ActionCommandFactory
    {
        public static readonly ActionCommandMetadata QuitToPreviousMenuMetadata = new ActionCommandMetadata
                                                        {
                                                            Command = "q",
                                                            CommandDescription =
                                                                "Exit Current Menu."
                                                        };

        public static ActionCommand CreateQuitToPreviousMenuCommand(Func<string, ActionResult> handler)
        {

            return new ActionCommand(QuitToPreviousMenuMetadata, handler)
            ;
        }
    }
}