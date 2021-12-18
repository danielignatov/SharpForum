using System.Collections.Generic;

namespace SharpForum.Domain
{
    /// <summary>
    /// Category
    /// </summary>
    public class Category : Entity
    {
        public Category()
        {
            Name = string.Empty;
            Description = string.Empty;
            Topics = new HashSet<Topic>();
        }

        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Category description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Display order
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Category act like placeholder, does not allow topic creation
        /// </summary>
        public bool IsPlaceholder {get;set;}

        /// <summary>
        /// Topics in category
        /// </summary>
        public ICollection<Topic> Topics { get; set; }
    }
}