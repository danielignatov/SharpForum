namespace SharpForum.App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default - Categories/All",
                url: "{controller}/{action}",
                defaults: new { controller = "Categories", action = "All" }
            );

            routes.MapRoute(
                name: "Display Specific Category",
                url: "Categories/Category/{id}",
                defaults: new { controller = "Categories", action = "Category" },
                constraints: new { id = @"\d+" }
            );

            // TODO - Subcat route
            // TODO - Topics/topic/{id} route
        }
    }
}