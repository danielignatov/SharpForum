namespace SharpForum.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        #region Constructors
        public Category()
        {
            this.SubCategories = new HashSet<SubCategory>();
        }
        #endregion

        #region Properties
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
        #endregion
    }
}