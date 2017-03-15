namespace SharpForum.App.Controllers
{
    using SharpForum.Models.ViewModels;
    using SharpForum.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class CategoriesController : Controller
    {
        #region Fields
        private CategoriesService categoriesService;
        #endregion

        #region Constructors
        public CategoriesController()
        {
            this.categoriesService = new CategoriesService();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Display all categories with their sub-categories.
        /// </summary>
        [HttpGet]
        public ActionResult All()
        {
            IEnumerable<CategorySubCategoriesViewModel> viewModel = this.categoriesService.GetAllCategories();

            return View(viewModel);
        }

        /// <summary>
        /// Display specific category with it's sub-categories.
        /// </summary>
        [HttpGet]
        public ActionResult Category(int id)
        {
            // TOINSPECT - Error handling?
            CategorySubCategoriesViewModel viewModel = this.categoriesService.GetCategory(id);

            return View(viewModel);
        }

        /// <summary>
        /// Display subcategory topics.
        /// </summary>
        [HttpGet]
        public ActionResult SubCategory(int id)
        {
            // TOINSPECT - Error handling?
            // TODO
            SubCategoryTopicsViewModel viewModel = this.categoriesService.GetSubCategory(id);

            return View(viewModel);
        }
        #endregion
    }
}