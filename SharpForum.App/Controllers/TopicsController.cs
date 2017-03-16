namespace SharpForum.App.Controllers
{
    using SharpForum.Models.ViewModels;
    using SharpForum.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class TopicsController : Controller
    {
        #region Fields
        private TopicsService topicsService;
        #endregion

        #region Constructors
        public TopicsController()
        {
            this.topicsService = new TopicsService();
        }
        #endregion

        #region Methods
        // GET: Topics
        [HttpGet]
        public ActionResult Topic(int id)
        {
            // TODO - Error handling?

            TopicRepliesViewModel viewModel = this.topicsService.GetTopic(id);

            return View(viewModel);
        }
        #endregion
    }
}