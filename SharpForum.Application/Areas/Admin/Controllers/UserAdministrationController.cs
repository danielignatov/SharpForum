using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SharpForum.Data;
using SharpForum.Models.BindingModels;
using SharpForum.Models.ViewModels.User;
using SharpForum.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SharpForum.Application.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("UserAdministration")]
    public class UserAdministrationController : Controller
    {
        private UserService userService;
        private UserManager _userManager;

        public UserAdministrationController()
        {
            this.userService = new UserService();
        }

        public UserAdministrationController(UserManager userManager)
            : base()
        {
            UserManager = userManager;
        }

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

        // GET: Admin/UserAdministration/EditProfile/{userId}
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("EditProfile/{userId:regex([0-9]+)}")]
        public ActionResult EditProfile(int userId)
        {
            UserViewModel model = this.userService.GetUserViewModel(userId);

            return View(model);
        }

        // POST: Admin/UserAdministration/Edit
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("EditProfile")]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.userService.EditUserProfile(model);

                return Redirect("../../UserProfile/" + model.UserId);
            }

            return View(model);
        }

        // GET: Admin/UserAdministration/EditProfile/{userId}
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("SetRole/{userId:regex([0-9]+)}")]
        public ActionResult SetRole(int userId)
        {
            UserRolesViewModel model = this.userService.GetUserRolesViewModel();

            return View(model);
        }

        // POST: Admin/UserAdministration/Edit
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("SetRole")]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> SetRole([Bind(Include = "UserId, RoleName")] UserRoleBindingModel urbm)
        {
            if (ModelState.IsValid)
            {
                var id = this.userService.GetUserStringId(urbm.UserId);
                var role = this.userService.GetUserRoleName(urbm.UserId);
                await UserManager.RemoveFromRoleAsync(id, role);
                await UserManager.AddToRoleAsync(id, urbm.RoleName);
                this.userService.ChangeUserRoleTitle(urbm.UserId, urbm.RoleName);
                
                return Redirect("../../UserProfile/" + urbm.UserId);
            }

            return RedirectToAction($"Search", "User", new { area = "" });
        }

        // GET: Admin/UserAdministration/Delete/{userId}
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Delete/{userId:regex([0-9]+)}")]
        public ActionResult Delete(int? userId)
        {
            this.userService.DeleteUser(userId);

            return RedirectToAction($"Search", "User", new { area = "" });
        }
    }
}