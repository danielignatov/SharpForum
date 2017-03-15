namespace SharpForum.App.Controllers
{
    using SharpForum.Models.BindingModels;
    using System.Web.Mvc;

    public class UsersController : Controller
    {
        [HttpGet]
        // GET: Users/All
        public ActionResult All()
        {
            // TODO

            return View();
        }

        [HttpGet]
        // GET: Users/Login
        public ActionResult Login()
        {
            // TODO

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Users/Login
        public ActionResult Login([Bind(Include = "")] LoginUserBindingModel loginUserBindingModel)
        {
            // TODO

            return View();
        }

        [HttpGet]
        // GET: Users/Register
        public ActionResult Register()
        {
            // TODO

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Users/Register
        public ActionResult Register([Bind(Include = "")] RegisterUserBindingModel registerUserBindingModel)
        {
            // TODO

            return View();
        }
    }
}