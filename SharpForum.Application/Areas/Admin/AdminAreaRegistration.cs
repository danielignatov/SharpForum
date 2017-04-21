using System.Web.Mvc;

namespace SharpForum.Application.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new { controller = "CategoryAdministration" },
                new[] { "SharpForum.Application.Areas.Admin.Controllers" }
            );
        }
    }
}