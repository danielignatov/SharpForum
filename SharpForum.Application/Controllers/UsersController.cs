namespace SharpForum.App.Controllers
{
    using SharpForum.Models.ViewModels;
    using SharpForum.Services;
    using System;
    using System.Web.Mvc;

    // TODO: More accurate error handling
    public class UsersController : Controller
    {
        #region Fields
        private UsersService usersService;
        #endregion

        #region Constructors
        public UsersController()
        {
            this.usersService = new UsersService();
        }
        #endregion

        #region Methods
        [HttpGet]
        // GET: Users/All
        public ActionResult All()
        {
            // TODO

            return View();
        }

        [HttpGet]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        [Route("Userprofile/{uid:regex([0-9]+)}")]
        public ActionResult UserProfile(int uid)
        {
            if (!this.usersService.DoesUserExist(uid))
            {
                return HttpNotFound();
            }

            UserViewModel viewModel = this.usersService.GetUserViewModel(uid);

            return View(viewModel);
        }
        #endregion
    }
}