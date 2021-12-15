namespace SharpForum.Services
{
    using AutoMapper;
    using SharpForum.Models.Attributes;
    using SharpForum.Models.EntityModels;
    using SharpForum.Models.ViewModels;
    using SharpForum.Models.ViewModels.Topic;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryService : Service
    {
        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            IEnumerable<Category> categories = this.Context.Categories.OrderBy(p => p.Priority);
        
            IEnumerable<CategoryViewModel> viewModel = Mapper.Instance.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
        
            return viewModel;
        }
        
        public CategoryTopicsViewModel GetCategory(int id, int? pageId)
        {
            Category category = this.Context.Categories.Find(id);
            List<Topic> allTopicsOrdered = category.Topics.OrderByDescending(st => st.IsSticky == true).ThenByDescending(pd => pd.PublishDate).ToList();
            
            if ((category == null) || (category.IsCategoryPlaceholder))
            {
                // In controller check if it's null and throw error
                return null;
            }
        
            CategoryTopicsViewModel viewModel = new CategoryTopicsViewModel()
            {
                Category = Mapper.Instance.Map<Category, CategoryViewModel>(category)
            };

            if (pageId == null)
            {
                viewModel.Pagination = new Pagination(allTopicsOrdered.Count(), 1);
                
                viewModel.Topics = Mapper.Instance.Map<IEnumerable<Topic>, IEnumerable<TopicViewModel>>(allTopicsOrdered.Take(10));
            }
            else
            {
                viewModel.Pagination = new Pagination(allTopicsOrdered.Count(), (int)pageId);

                viewModel.Topics = Mapper.Instance.Map<IEnumerable<Topic>, IEnumerable<TopicViewModel>>(
                    allTopicsOrdered.Skip((viewModel.Pagination.CurrentPage - 1) * 
                    viewModel.Pagination.PageSize).Take(viewModel.Pagination.PageSize)
                    );
            }

            return viewModel;
        }

        public void AddCategory(CategoryViewModel model)
        {
            Category category = Mapper.Map<CategoryViewModel, Category>(model);

            this.Context.Categories.Add(category);
            this.Context.SaveChanges();
        }

        public CategoryViewModel GetCategoryViewModel(int? categoryId)
        {
            Category category = this.Context.Categories.Find(categoryId);
            CategoryViewModel model = Mapper.Map<Category, CategoryViewModel>(category);

            return model;
        }

        public bool IsCategoryValid(int id)
        {
            if (this.Context.Categories.Any(cid => cid.Id == id))
            {
                return true;
            }

            return false;
        }

        public void DeleteCategory(int? categoryId)
        {
            this.Context.Categories.Remove(this.Context.Categories.Find(categoryId));
            this.Context.SaveChanges();
        }

        public void EditCategory(CategoryViewModel model)
        {
            Category category = this.Context.Categories.Find(model.Id);
            category.Name = model.Name;
            category.Priority = model.Priority;
            category.IsCategoryPlaceholder = model.IsCategoryPlaceholder;
            category.Description = model.Description;

            this.Context.SaveChanges();
        }
    }
}