namespace SharpForum.Models.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;
    using System;

    public class UserViewModel
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string RoleTitle { get; set; }

        public DateTime DateOfRegistration { get; set; }

        [Display(Name = "Avatar Url")]
        public string AvatarUrl { get; set; }

        [Display(Name = "Website Url")]
        public string WebsiteUrl { get; set; }

        [Display(Name = "Forum Signature")]
        public string ForumSignature { get; set; }

        [Display(Name = "About Me")]
        public string AboutMe { get; set; }

        [Display(Name = "Living Location")]
        public string LivingLocation { get; set; }

        public int TotalMessagesCount { get; set; }
    }
}