namespace SharpForum.Models.ViewModels
{
    using System.Collections.Generic;

    public class CategoryTopicsViewModel
    {
        public CategoryViewModel Category { get; set; }

        public IEnumerable<TopicViewModel> Topics { get; set; }
    }
}