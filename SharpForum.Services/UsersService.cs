

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
        
        /// <summary>
        /// Get user string id and return his int userId
        /// </summary>
        public int GetMyUserProfileId(string id)
        {
            return this.Context.Users.Where(i => i.Id == id).Select(uid => uid.UserId).Single();
        }
    }
}