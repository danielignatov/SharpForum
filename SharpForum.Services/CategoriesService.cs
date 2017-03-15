namespace SharpForum.Services
{
    using AutoMapper;
    using SharpForum.Models.EntityModels;
    using SharpForum.Models.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CategoriesService : Service
    {
        public IEnumerable<CategorySubCategoriesViewModel> GetAllCategories()
        {
            // TOINSPECT - Is this the best way?
            IEnumerable<Category> categories = this.Context.Categories.OrderBy(p => p.Priority);

            List<CategorySubCategoriesViewModel> viewModelsList = new List<CategorySubCategoriesViewModel>();

            foreach (var category in categories)
            {
                CategorySubCategoriesViewModel viewModel = new CategorySubCategoriesViewModel()
                {
                    Category = Mapper.Instance.Map<Category, CategoryViewModel>(category),
                    SubCategories = Mapper.Instance.Map<IEnumerable<SubCategory>, IEnumerable<SubCategoryViewModel>>(category.SubCategories)
                };

                viewModelsList.Add(viewModel);
            }

            IEnumerable<CategorySubCategoriesViewModel> viewModels = viewModelsList;

            return viewModels;
        }

        public CategorySubCategoriesViewModel GetCategory(int id)
        {
            // TOINSPECT - Where does error in case of bad id goes?
            Category category = this.Context.Categories.Find(id);
            CategorySubCategoriesViewModel viewModel = new CategorySubCategoriesViewModel()
            {
                Category = Mapper.Instance.Map<Category, CategoryViewModel>(category),
                SubCategories = Mapper.Instance.Map<IEnumerable<SubCategory>, IEnumerable<SubCategoryViewModel>>(category.SubCategories)
            };

            return viewModel;
        }
    }
}