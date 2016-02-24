using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using MVCIoC.Controllers;
using MVCIoC.Models;

namespace MVCIoC.Infrastructure
{

    //So this class we want to use instead of the DefaultControllerFactory, so we inherit from the IControllerFactory and make all the
    //changes that we need.  The next step will be to ensure that it is used by MVC instead of the Default One

    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName.ToLower().StartsWith("proteintracker"))
            {
                //Create an instance of the ProteinTrackingService
                var service = new ProteinTrackingService();
                //Pass this new instance into the creation of the controller.  Now remember, that even though this is a concrete instance
                //the controller can accept anything derived from IProteinTrackingService
                //It doesn't care what the class is, as long as it's implementing this interface
                var controller = new ProteinTrackerController(service);
                return controller;
            }

            //For all other types of Controller, we're just going to let it do what the default is
            var defaultController = new DefaultControllerFactory();
            return defaultController.CreateController(requestContext, controllerName);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            //This method is not really interesting for us, so just return a default SessionStateBehavior
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            //Again, this method isn't really interesting for us, so just have it execute any IDisposable code if any exists on the Controller
            
            //If this class implements IDisposable, then lets go ahead and get that
            var dispose = controller as IDisposable;
            //and simply call it to make sure this controller is correctly disposed (the syntax means if not null)
            dispose?.Dispose();
        }
    }
}