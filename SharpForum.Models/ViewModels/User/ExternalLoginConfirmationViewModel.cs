namespace SharpForum.Models.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "The {0} must be betweeen {2} and {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Username")]
        public string UserName { get; set; }
    }
}