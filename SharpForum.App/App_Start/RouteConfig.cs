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
                name: "Display Specific Category",
                url: "Category/{id}",
                defaults: new { controller = "Categories", action = "Category" },
                constraints: new { id = @"\d+" }
            );

            routes.MapRoute(
                name: "Default - Display All Categories",
                url: "{controller}/{action}",
                defaults: new { controller = "Categories", action = "All" }
            );

            // TODO - Topic/{id} route
            // TODO - Topics/Latest route
            // TODO - Topics/Search route ?maybe in separate controller
            // TODO - Topic/New
            // TODO - Users/All route
            // TODO - User/{id} route
            // TODO - User/Login route
            // TODO - User/Register route 
            // TODO - Users/Search route ?maybe in separate controller
            // TODO - Edit/Topic/{id} route
            // TODO - Edit/Category/{id} route
            // TODO - Edit/User/{id} route
            // TODO - Edit/Reply/{id} route

            // TODO - Add's, Delete's and bunch more...
        }
    }
}