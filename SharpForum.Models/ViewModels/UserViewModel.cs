namespace SharpForum.Models.ViewModels
{
    using System;

    public class UserViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string AvatarUrl { get; set; }

        public string WebsiteUrl { get; set; }

        public string Signature { get; set; }

        public string LivingLocation { get; set; }
    }
}