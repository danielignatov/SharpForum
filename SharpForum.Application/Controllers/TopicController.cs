namespace SharpForum.App.Controllers
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using SharpForum.Application;
    using SharpForum.Models.ViewModels;
    using SharpForum.Models.ViewModels.Topic;
    using SharpForum.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class TopicController : Controller
    {
        #region Fields
        private UserManager _userManager;
        private TopicService topicService;
        #endregion

        #region Constructors
        public TopicController()
        {
            this.topicService = new TopicService();
            
        }

        public TopicController(UserManager userManager)
            : base()
        {
            UserManager = userManager;
        }
        #endregion

        #region Properties
        public UserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Display the topic with Id and all it's replies
        /// </summary>
        [HttpGet]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        [Route("Topic/{topicId:regex([0-9]+)}")]
        public ActionResult Topic(int topicId)
        {
            if (!this.topicService.DoesTopicExist(topicId))
            {
                return HttpNotFound();
            }

            TopicAuthorRepliesAuthorsViewModel viewModel = this.topicService.GetTopic(topicId);

            return View(viewModel);
        }

        /// <summary>
        /// Create new topic in the supplied category
        /// </summary>
        [HttpGet]
        [Authorize]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        [Route("Topic/New/{categoryId:regex([0-9]+)}")]
        public ActionResult New(int categoryId)
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        [ValidateAntiForgeryToken]
        [Route("Topic/New")]
        public ActionResult New(TopicViewModel model, int categoryId)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();

                this.topicService.AddNewTopic(model, categoryId, userId);
                int newTopicId = this.topicService.GetTopicId(model.Title, model.Content);

                return RedirectToAction("Topic", new { topicId = newTopicId });
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        /// <summary>
        /// Search topics
        /// </summary>
        [HttpGet]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        [Route("Topic/Search/{searchTerm:regex([A-z]+[0-9]?)?}/{includeContent:bool?}/{includeReplies:bool?}/{pageId:regex([0-9]+)?}")]
        public ActionResult Search(string searchTerm, bool? includeContent, bool? includeReplies, int? pageId)
        {
            ShowTopicsAuthorsRepliesAuthorsViewModel model = this.topicService.GetSearchedTopicsViewModel(searchTerm, includeContent, includeReplies, pageId);

            return this.View(model);
        }

        /// <summary>
        /// Show latest topics
        /// </summary>
        [HttpGet]
        [Route("Topics/Latest")]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public ActionResult Latest(int? pageId)
        {
            ShowTopicsAuthorsRepliesAuthorsViewModel model = this.topicService.GetLatestTopicsViewModel(pageId);

            return this.View(model);
        }

        /// <summary>
        /// Show topics started by user
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("Topics/MyTopics")]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public ActionResult MyTopics(int? pageId)
        {
            string userId = User.Identity.GetUserId();
            ShowTopicsAuthorsRepliesAuthorsViewModel model = this.topicService.GetLatestTopicsByUserViewModel(userId, pageId);

            return this.View(model);
        }

        /// <summary>
        /// Show topics that have replies by user
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("Topics/MyReplies")]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public ActionResult MyReplies(int? pageId)
        {
            string userId = User.Identity.GetUserId();
            ShowTopicsAuthorsRepliesAuthorsViewModel model = this.topicService.GetLatestTopicsInWhichUserHasRepliesViewModel(userId, pageId);

            return this.View(model);
        }
        #endregion
    }
}