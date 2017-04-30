namespace SharpForum.Application
{
    using System.Web.Mvc;
    using System.Web.Routing;

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
                defaults: new { controller = "Categories", action = "All", id = UrlParameter.Optional },
                namespaces: new string[] { "SharpForum.Application.Controllers" }
            );
        }
    }
}