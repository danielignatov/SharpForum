namespace SharpForum.Models.ViewModels
{
    using System.Collections.Generic;

    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public bool IsSuperCategory { get; set; }

        // TODO count topics replies
    }
}