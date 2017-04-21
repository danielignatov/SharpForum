namespace SharpForum.Application.Areas.Moderator.Controllers
{
    using SharpForum.Models.ViewModels.Topic;
    using SharpForum.Services;
    using System.Web.Mvc;

    [RouteArea("Moderator")]
    [RoutePrefix("TopicModeration")]
    public class TopicModerationController : Controller
    {
        private TopicService topicService;

        public TopicModerationController()
        {
            this.topicService = new TopicService();
        }

        // GET: Moderator/TopicModeration/Edit/{replyId}
        [HttpGet]
        [Authorize(Roles = "Moderator, Admin")]
        [Route("Edit/{topicId:regex([0-9]+)}")]
        public ActionResult Edit(int? topicId)
        {
            TopicViewModel model = this.topicService.GetTopicViewModel(topicId);

            return View(model);
        }

        // POST: Moderator/TopicModeration/Edit
        [HttpPost]
        [Authorize(Roles = "Moderator, Admin")]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TopicViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.topicService.EditTopic(model);

                return RedirectToAction($"{model.Id}", "Topic", new { area = "" });
            }

            return View(model);
        }

        // GET: Moderator/TopicModeration/Delete/{replyId}
        [HttpGet]
        [Authorize(Roles = "Moderator, Admin")]
        [Route("Delete/{categoryId:regex([0-9]+)}/{topicId:regex([0-9]+)}")]
        public ActionResult Delete(int? categoryId, int? topicId)
        {
            this.topicService.DeleteTopic(topicId);

            return RedirectToAction($"{categoryId}", "Category", new { area = "" });
        }

        // GET: Moderator/TopicModeration/Lock/{replyId}
        [HttpGet]
        [Authorize(Roles = "Moderator, Admin")]
        [Route("Lock/{topicId:regex([0-9]+)}")]
        public ActionResult Lock(int? topicId)
        {
            this.topicService.LockTopic(topicId);

            return RedirectToAction($"{topicId}", "Topic", new { area = "" });
        }

        // GET: Moderator/TopicModeration/Unlock/{replyId}
        [HttpGet]
        [Authorize(Roles = "Moderator, Admin")]
        [Route("Unlock/{topicId:regex([0-9]+)}")]
        public ActionResult Unlock(int? topicId)
        {
            this.topicService.UnlockTopic(topicId);

            return RedirectToAction($"{topicId}", "Topic", new { area = "" });
        }

        // GET: Moderator/TopicModeration/Stick/{replyId}
        [HttpGet]
        [Authorize(Roles = "Moderator, Admin")]
        [Route("Stick/{topicId:regex([0-9]+)}")]
        public ActionResult Stick(int? topicId)
        {
            this.topicService.StickTopic(topicId);

            return RedirectToAction($"{topicId}", "Topic", new { area = "" });
        }

        // GET: Moderator/TopicModeration/Unstick/{replyId}
        [HttpGet]
        [Authorize(Roles = "Moderator, Admin")]
        [Route("Unstick/{topicId:regex([0-9]+)}")]
        public ActionResult Unstick(int? topicId)
        {
            this.topicService.UnstickTopic(topicId);

            return RedirectToAction($"{topicId}", "Topic", new { area = "" });
        }
    }
}