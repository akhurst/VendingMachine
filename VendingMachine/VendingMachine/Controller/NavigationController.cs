using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Controller
{
    public class NavigationController : ViewController
    {
        protected readonly Stack<ViewController> viewControllers;

        public ViewController TopViewController { get { return viewControllers.Peek(); } }

        public NavigationController(ViewController rootViewController)
        {            
            this.viewControllers = new Stack<ViewController>();
            this.viewControllers.Push(rootViewController);
            rootViewController.NavigationController = this;
        }

        public void PushViewController(ViewController viewController)
        {
            viewControllers.Push(viewController);
            viewController.NavigationController = this;
        }

        /// <summary>
        /// If the view controller at the top of the stack is the root view controller, this method does nothing. In other words, you cannot pop the last item on the stack.
        /// </summary>
        /// <returns></returns>
        public ViewController PopViewController()
        {
            if (viewControllers.Count == 1) return null;
            ViewController poppedController = viewControllers.Pop();
            poppedController.NavigationController = null;
            return poppedController;
        }

        public List<ViewController> PopToRootViewController()
        {
            List<ViewController> poppedControllers = new List<ViewController>();
            while (viewControllers.Count > 1)
            {
                poppedControllers.Add(PopViewController());
            }
            return poppedControllers;
        }
    }
}
