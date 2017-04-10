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

        // TODO: More accurate error handling
        #region Methods
        /// <summary>
        /// Display the topic with Id and all it's replies
        /// </summary>
        [HttpGet]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public ActionResult Topic(int id)
        {
            if (!this.topicsService.DoesTopicExist(id))
            {
                return HttpNotFound();
            }

            TopicAuthorRepliesAuthorsViewModel viewModel = this.topicsService.GetTopic(id);

            return View(viewModel);
        }

        /// <summary>
        /// Create new topic in the supplied category
        /// </summary>
        [HttpGet]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public ActionResult New(int categoryId)
        {
            // TODO

            return this.View();
        }

        /// <summary>
        /// Search topics
        /// </summary>
        [HttpGet]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public ActionResult Search()
        {
            // TODO

            return this.View();
        }

        /// <summary>
        /// Show latest topics
        /// </summary>
        [HttpGet]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public ActionResult Latest()
        {
            // TODO

            return this.View();
        }
        #endregion
    }
}