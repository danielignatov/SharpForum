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
        /// Display all categories with info about their topics.
        /// </summary>
        [HttpGet]
        public ActionResult All()
        {
            IEnumerable<CategoryTopicsViewModel> viewModel = this.categoriesService.GetAllCategories();

            return View(viewModel);
        }

        /// <summary>
        /// Display specific category with it's topics.
        /// </summary>
        [HttpGet]
        public ActionResult Category(int id)
        {
            // TOINSPECT - Error handling?
            CategoryTopicsViewModel viewModel = this.categoriesService.GetCategory(id);

            return View(viewModel);
        }
        #endregion
    }
}