namespace SharpForum.Models.ViewModels
{
    using System.Collections.Generic;

    public class CategorySubCategoriesViewModel
    {
        public CategoryViewModel Category { get; set; }

        public IEnumerable<SubCategoryViewModel> SubCategories { get; set; }
    }
}