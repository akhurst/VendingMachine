using VendingMachine.Framework.Results;

namespace VendingMachine.Framework
{
    public interface IController
    {
        string DisplayPrompt { get; }
        ActionResult PerformAction(string userInput);
    }
}
