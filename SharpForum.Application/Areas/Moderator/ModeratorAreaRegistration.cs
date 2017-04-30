namespace SharpForum.Application.Areas.Moderator
{
    using System.Web.Mvc;

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