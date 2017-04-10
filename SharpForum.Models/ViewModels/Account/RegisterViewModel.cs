namespace SharpForum.Models.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using System;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "The {0} must be betweeen {2} and {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Avatar Url")]
        public string AvatarUrl { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Website Url")]
        public string WebsiteUrl { get; set; }

        [StringLength(128, ErrorMessage = "The signature cannot exceed {1} characters.")]
        [Display(Name = "Forum Signature")]
        public string ForumSignature { get; set; }

        [StringLength(2048, ErrorMessage = "The about me cannot exceed {1} characters.")]
        [Display(Name = "About Me")]
        public string AboutMe { get; set; }

        [StringLength(24, ErrorMessage = "The living location cannot exceed {1} characters.")]
        [Display(Name = "Living Location")]
        public string LivingLocation { get; set; }
    }
}