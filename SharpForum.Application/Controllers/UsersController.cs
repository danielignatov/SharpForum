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
        private ForumUsersService usersService;
        #endregion

        #region Constructors
        public UsersController()
        {
            this.usersService = new ForumUsersService();
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
        public ActionResult UserProfile(int id)
        {
            UserViewModel viewModel = null;

            return View(viewModel);
        }

        //[HttpGet]
        //// GET: Users/Login
        //public ActionResult Login()
        //{
        //    // TODO
        //
        //    return View();
        //}
        //
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //// POST: Users/Login
        //public ActionResult Login([Bind(Include = "")] LoginUserBindingModel loginUserBindingModel)
        //{
        //    // TODO
        //
        //    return View();
        //}
        //
        //[HttpGet]
        //// GET: Users/Register
        //public ActionResult Register()
        //{
        //    // TODO
        //
        //    return View();
        //}
        //
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //// POST: Users/Register
        //public ActionResult Register([Bind(Include = "")] RegisterUserBindingModel registerUserBindingModel)
        //{
        //    // TODO
        //
        //    return View();
        //}
        #endregion
    }
}