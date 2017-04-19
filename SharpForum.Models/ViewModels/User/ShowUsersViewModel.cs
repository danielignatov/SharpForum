namespace SharpForum.Models.ViewModels.User
{
    using SharpForum.Models.Attributes;
    using System.Collections.Generic;

    public class ShowUsersViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }

        public Pagination Pagination { get; set; }
    }
}