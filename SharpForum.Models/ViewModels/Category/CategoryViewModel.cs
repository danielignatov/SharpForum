namespace SharpForum.Models.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be betweeen {2} and {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public int Priority { get; set; }

        [Required]
        [Display(Name = "Supercategory")]
        public bool IsSuperCategory { get; set; }

        // Custom view properties
        
        public int TopicsCount { get; set; }

        public int RepliesCount { get; set; }
    }
}