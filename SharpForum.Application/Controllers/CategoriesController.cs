namespace SharpForum.App.Controllers
{
    using SharpForum.Models.ViewModels;
    using SharpForum.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [HandleError(ExceptionType = typeof(Exception), View = "Error")]
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
        [Route("~/", Name = "default")]
        [Route("Categories/All")]
        public ActionResult All()
        {
            IEnumerable<CategoryViewModel> viewModel = this.categoriesService.GetAllCategories();

            return View(viewModel);
        }
        
        /// <summary>
        /// Display specific category with it's topics.
        /// </summary>
        [HttpGet]
        [Route("Category/{id:regex([0-9]+)}")]
        public ActionResult Category(int id)
        {
            if (!this.categoriesService.IsCategoryValid(id))
            {
                return HttpNotFound();
            }

            CategoryTopicsViewModel viewModel = this.categoriesService.GetCategory(id);

            return View(viewModel);
        }
        #endregion
    }
}