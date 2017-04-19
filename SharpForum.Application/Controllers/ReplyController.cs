namespace SharpForum.Application.Controllers
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using SharpForum.Models.ViewModels.Reply;
    using SharpForum.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ReplyController : Controller
    {
        #region Fields
        private UserManager _userManager;
        private ReplyService replyService;
        #endregion

        #region Constructors
        public ReplyController()
        {
            this.replyService = new ReplyService();
        }

        public ReplyController(UserManager userManager)
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

        /// <summary>
        /// Show form for new reply to topic
        /// </summary>
        [HttpGet]
        [Authorize]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        //[ValidateAntiForgeryToken]
        [Route("Reply/New/{topicId:regex([0-9]+)}")]
        public ActionResult New(int topicId)
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        [Route("Reply/New")]
        public ActionResult New(ReplyViewModel model, int topicId)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();

                this.replyService.AddNewReply(model, model.TopicId, userId);
                
                return RedirectToAction($"{model.TopicId}", "Topic", new { area = "" });
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}