

namespace SharpForum.Services
{
    using System;
    using SharpForum.Models.ViewModels;
    using SharpForum.Models.EntityModels;
    using AutoMapper;
    using System.Linq;

    public class UsersService : Service
    {
        public UserViewModel GetUserViewModel(int id)
        {
            User user = this.Context.Users.Where(uid => uid.UserId == id).SingleOrDefault();

            return Mapper.Instance.Map<User, UserViewModel>(user);
        }

        public bool DoesUserExist(int userId)
        {
            return this.Context.Users.Any(uid => uid.UserId == userId);
        }

        public int GenerateNewUserId()
        {
            return this.Context.Users.Count() + 1;
        }
    }
}