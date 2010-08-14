using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class ActionResult
    {
        public ActionResult() : this(string.Empty, null){}
        public ActionResult(string output) : this(output, null){}
        public ActionResult(IController nextController) : this(string.Empty, nextController){}

        public ActionResult(string output, IController nextController)
        {
            this.Output = output;
            this.NextController = nextController;
        }

        public IController NextController { get; private set; }
        public string Output { get; private set; }
        public bool QuitController { get; set; }
    }
}
