using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharpForum.Application.Areas.Moderator.Controllers
{
    public class TopicModerationController : Controller
    {
        // GET: Moderator/TopicModeration
        public ActionResult Index()
        {
            return View();
        }
    }
}