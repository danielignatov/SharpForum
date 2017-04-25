using SharpForum.Models.ViewModels;
using SharpForum.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharpForum.Application.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("CategoryAdministration")]
    public class CategoryAdministrationController : Controller
    {
        private CategoryService categoryService;

        public CategoryAdministrationController()
        {
            this.categoryService = new CategoryService();
        }

        // GET: Admin/CategoryAdministration/Index
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Index")]
        public ActionResult Index()
        {
            IEnumerable<CategoryViewModel> model = this.categoryService.GetAllCategories();

            return View(model);
        }

        // GET: Admin/CategoryAdministration/New
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("New")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [Route("New")]
        public ActionResult New(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.categoryService.AddCategory(model);

                return RedirectToAction($"Index", "CategoryAdministration", new { area = "Admin" });
            }

            return View(model);
        }

        // GET: Admin/CategoryAdministration/Edit/{categoryId}
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Edit/{categoryId:regex([0-9]+)}")]
        public ActionResult Edit(int? categoryId)
        {
            CategoryViewModel model = this.categoryService.GetCategoryViewModel(categoryId);

            return View(model);
        }

        // POST: Admin/CategoryAdministration/Edit
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.categoryService.EditCategory(model);

                return RedirectToAction($"Index", "CategoryAdministration", new { area = "Admin" });
            }

            return View(model);
        }

        // GET: Admin/CategoryAdministration/Delete/{categoryId}
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Delete/{categoryId:regex([0-9]+)}")]
        public ActionResult Delete(int? categoryId)
        {
            this.categoryService.DeleteCategory(categoryId);

            return RedirectToAction($"Index", "CategoryAdministration", new { area = "Admin" });
        }
    }
}