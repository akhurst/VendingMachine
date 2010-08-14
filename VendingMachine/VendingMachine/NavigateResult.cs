using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class NavigateResult : ActionResult
    {
        public NavigateResult(IController nextController) : base(string.Empty, nextController, false){}
    }
}
