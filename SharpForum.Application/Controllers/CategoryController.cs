namespace SharpForum.Application.Controllers
{
    using SharpForum.Models.ViewModels;
    using SharpForum.Services;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    
    [HandleError(ExceptionType = typeof(Exception), View = "Error")]
    public class CategoryController : Controller
    {
        #region Fields
        private CategoryService categoryService;
        #endregion

        #region Constructors
        public CategoryController()
        {
            this.categoryService = new CategoryService();
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
            IEnumerable<CategoryViewModel> viewModel = this.categoryService.GetAllCategories();

            return View(viewModel);
        }
        
        /// <summary>
        /// Display specific category with it's topics.
        /// </summary>
        [HttpGet]
        [Route("Category/{id:regex([0-9]+)}/{pageId:regex([0-9]+)?}")]
        public ActionResult Category(int id, int? pageId)
        {
            if (!this.categoryService.IsCategoryValid(id))
            {
                return HttpNotFound();
            }

            CategoryTopicsViewModel viewModel = this.categoryService.GetCategory(id, pageId);

            return View(viewModel);
        }
        #endregion
    }
}