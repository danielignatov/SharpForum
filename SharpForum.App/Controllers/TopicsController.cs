namespace SharpForum.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class TopicsController : Controller
    {
        // GET: Topics
        [HttpGet]
        public ActionResult Topic(int id)
        {
            // TODO

            return View();
        }
    }
}