namespace SharpForum.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        #region Constructors
        public Category()
        {
            this.Topics = new HashSet<Topic>();
        }
        #endregion

        #region Properties
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public bool IsCategoryPlaceholder { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
        #endregion
    }
}