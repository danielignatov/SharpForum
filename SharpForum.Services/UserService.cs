

namespace SharpForum.Services
{
    using System;
    using SharpForum.Models.ViewModels;
    using SharpForum.Models.EntityModels;
    using AutoMapper;
    using System.Linq;
    using SharpForum.Models.ViewModels.User;
    using System.Collections.Generic;
    using SharpForum.Models.Attributes;

    public class UserService : Service
    {
        public UserViewModel GetUserViewModel(int id)
        {
            User user = this.Context.Users.Where(uid => uid.UserId == id).FirstOrDefault();

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

        public ShowUsersViewModel GetAllUsersViewModel(int? pageId)
        {
            ShowUsersViewModel usvm = new ShowUsersViewModel();
            List<UserViewModel> userViewModelList = new List<UserViewModel>();
            List<User> allUsersList = this.Context.Users.OrderBy(uid => uid.UserId).ToList();
            List<User> sortedUsersList = new List<User>();

            if (pageId == null)
            {
                usvm.Pagination = new Pagination(allUsersList.Count(), 1);
                sortedUsersList = allUsersList.Take(10).ToList();
            }
            else
            {
                usvm.Pagination = new Pagination(allUsersList.Count(), (int)pageId);
                sortedUsersList = allUsersList.Skip((usvm.Pagination.CurrentPage - 1) * usvm.Pagination.PageSize).Take(usvm.Pagination.PageSize).ToList();
            }

            foreach (var user in sortedUsersList)
            {
                UserViewModel uvm = Mapper.Map<User, UserViewModel>(user);
                userViewModelList.Add(uvm);
            }

            usvm.Users = userViewModelList;

            return usvm;
        }

        public ShowUsersViewModel GetSearchedUsersViewModel(string searchTerm, int? pageId)
        {
            ShowUsersViewModel suvm = new ShowUsersViewModel();

            if (searchTerm == null)
            {
                return suvm;
            }
            else
            {
                List<UserViewModel> uvml = new List<UserViewModel>();
                List<User> allUsersList = this.Context.Users.OrderBy(uid => uid.UserId).ToList();

                foreach (var user in allUsersList.Where(n => n.UserName.ToLower().Contains(searchTerm.ToLower())))
                {
                    UserViewModel uvm = Mapper.Map<User, UserViewModel>(user);
                    uvml.Add(uvm);
                }

                suvm.Users = uvml;

                if (pageId == null)
                {
                    suvm.Pagination = new Pagination(uvml.Count(), 1);
                    suvm.Users = uvml.Take(10).ToList();
                }
                else
                {
                    suvm.Pagination = new Pagination(uvml.Count(), (int)pageId);
                    suvm.Users = uvml.Skip((suvm.Pagination.CurrentPage - 1) * suvm.Pagination.PageSize).Take(suvm.Pagination.PageSize).ToList();
                }

                return suvm;
            }
        }
    }
}