using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace prjMVC_HW_Money
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home_Default",
                url: "{controller}/{action}/{Page}",
                defaults: new { controller = "Home", action = "Index", Page = UrlParameter.Optional }
            );
        }
    }
}
