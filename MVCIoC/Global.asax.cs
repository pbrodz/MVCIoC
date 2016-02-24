using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MVCIoC.Infrastructure;

namespace MVCIoC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //These lines wire up your custom controller factory to use it, instead of the default one!
            //Pretty cool, eh?
            var factory = new CustomControllerFactory();
            ControllerBuilder.Current.SetControllerFactory(factory);
        }
    }
}
