using System.Web.Mvc;

namespace SharpForum.Application.Areas.Moderator
{
    public class ModeratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Moderator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Moderator_default",
                "Moderator/{controller}/{action}/{id}",
                new { action = "Edit", id = UrlParameter.Optional },
                new { controller = "ReplyModeration|TopicModeration" },
                new[] { "SharpForum.Application.Areas.Moderator.Controllers" }
            );
        }
    }
}