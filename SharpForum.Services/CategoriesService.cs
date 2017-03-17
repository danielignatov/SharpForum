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
        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            IEnumerable<Category> categories = this.Context.Categories.OrderBy(p => p.Priority);

            IEnumerable<CategoryViewModel> viewModel = Mapper.Instance.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

            return viewModel;
        }

        public CategoryTopicsViewModel GetCategory(int id)
        {
            // TODO
            // TOINSPECT - Where does error in case of bad id goes?
            Category category = this.Context.Categories.Find(id);
            CategoryTopicsViewModel viewModel = new CategoryTopicsViewModel()
            {
                Category = Mapper.Instance.Map<Category, CategoryViewModel>(category),
                Topics = Mapper.Instance.Map<IEnumerable<Topic>, IEnumerable<TopicViewModel>>(category.Topics)
            };

            return viewModel;
        }
    }
}