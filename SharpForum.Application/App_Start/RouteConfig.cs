using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SharpForum.Application
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Using Attribute Routes
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default with Id",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Categories", action = "All", id = UrlParameter.Optional }
            );
        }
    }
}
