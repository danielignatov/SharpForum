using SharpForum.Models.ViewModels.Reply;
using SharpForum.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharpForum.Application.Areas.Moderator.Controllers
{
    [RouteArea("Moderator")]
    [RoutePrefix("ReplyModeration")]
    public class ReplyModerationController : Controller
    {
        private ReplyService replyService;

        public ReplyModerationController()
        {
            this.replyService = new ReplyService();
        }

        // GET: Moderator/ReplyModeration/Edit/{replyId}
        [HttpGet]
        [Authorize(Roles = "Moderator, Admin")]
        [Route("Edit/{replyId:regex([0-9]+)}")]
        public ActionResult Edit(int? replyId)
        {
            ReplyViewModel model = this.replyService.GetReplyViewModel(replyId);

            return View(model);
        }

        // POST: Moderator/ReplyModeration/Edit
        [HttpPost]
        [Authorize(Roles = "Moderator, Admin")]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReplyViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.replyService.EditReply(model);

                return RedirectToAction($"{model.TopicId}", "Topic", new { area = "" });
            }

            return View(model);
        }
    }
}