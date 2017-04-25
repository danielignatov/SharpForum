namespace SharpForum.Models.ViewModels.User
{
    using System.Collections.Generic;

    public class UserRolesViewModel
    {
        public ICollection<string> UserRoleNames { get; set; }
    }
}