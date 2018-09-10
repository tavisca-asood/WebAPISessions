using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProductsUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //RouteTable.Routes.Add(new Route
            //{
            //    Url = "[controller]/[action]/[id]",
            //    Defaults = new { action = "Index", id = (string)null },
            //    RouteHandler= typeof(MvcRouteHandler)
            //});
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
