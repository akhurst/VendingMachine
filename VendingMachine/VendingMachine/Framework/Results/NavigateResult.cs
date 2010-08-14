namespace VendingMachine.Framework.Results
{
    public class NavigateResult : ActionResult
    {
        public NavigateResult(IController nextController) : base(string.Empty, nextController, false){}
    }
}
