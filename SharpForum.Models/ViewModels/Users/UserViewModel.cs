namespace SharpForum.Models.ViewModels
{
    using System;

    public class UserViewModel
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string RoleTitle { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public string AvatarUrl { get; set; }

        public string WebsiteUrl { get; set; }

        public string ForumSignature { get; set; }

        public string AboutMe { get; set; }

        public string LivingLocation { get; set; }

        public int TotalMessagesCount { get; set; }
    }
}