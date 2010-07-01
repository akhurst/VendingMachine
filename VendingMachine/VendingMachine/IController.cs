namespace VendingMachine
{
    public interface IController
    {
        bool IsActive { get; }
        string DisplayPrompt { get; }
        ActionResult PerformAction(string userInput);
    }
}
