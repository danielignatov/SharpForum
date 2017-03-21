using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SharpForum.Models.ViewModels;
using SharpForum.Models.EntityModels;

namespace SharpForum.Services
{
    public class UsersService : Service
    {
        public UserViewModel GetUser(int id)
        {
            User user = this.Context.Users.Find(id);
            UserViewModel viewModel = Mapper.Instance.Map<User, UserViewModel>(user);

            return viewModel;
        }
    }
}
