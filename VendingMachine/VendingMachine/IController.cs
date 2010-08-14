namespace VendingMachine
{
    public interface IController
    {
        string DisplayPrompt { get; }
        ActionResult PerformAction(string userInput);
    }
}
