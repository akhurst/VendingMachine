using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public abstract class ActionResult
    {
        protected ActionResult() : this(string.Empty, null, false){}
        protected ActionResult(string output) : this(output, null, false){}
        protected ActionResult(IController nextController) : this(string.Empty, nextController, false){}
        protected ActionResult(bool quitController) : this(string.Empty, null, quitController){}

        protected ActionResult(string output, IController nextController, bool quitController)
        {
            this.Output = output;
            this.NextController = nextController;
            this.QuitController = quitController;
        }

        public IController NextController { get; private set; }
        public string Output { get; private set; }
        public bool QuitController { get; set; }
    }
}
