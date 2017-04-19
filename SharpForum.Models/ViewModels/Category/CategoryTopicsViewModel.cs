namespace SharpForum.Models.ViewModels
{
    using SharpForum.Models.Attributes;
    using SharpForum.Models.ViewModels.Topic;
    using System.Collections.Generic;

    public class CategoryTopicsViewModel
    {
        public CategoryViewModel Category { get; set; }

        public IEnumerable<TopicViewModel> Topics { get; set; }

        public Pagination Pagination { get; set; }
    }
}