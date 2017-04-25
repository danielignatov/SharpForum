

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
    using SharpForum.Models.BindingModels;

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

        public UserRolesViewModel GetUserRolesViewModel()
        {
            UserRolesViewModel model = new UserRolesViewModel();
            List<string> roles = new List<string>();

            foreach (var role in this.Context.Roles)
            {
                roles.Add(role.Name);
            }

            model.UserRoleNames = roles;

            return model;
        }

        public void DeleteUser(int? userId)
        {
            this.Context.Users.Remove(this.Context.Users.Where(uid => uid.UserId == userId).FirstOrDefault());
            this.Context.SaveChanges();
        }

        public string GetUserName(string id)
        {
            return this.Context.Users.Where(i => i.Id == id).Select(un => un.UserName).FirstOrDefault();
        }

        public string GetUserRoleName(int userId)
        {
            var role = this.Context.Users.Where(uid => uid.UserId == userId).Select(r => r.Roles.FirstOrDefault()).FirstOrDefault();
            var roleName = this.Context.Roles.Where(rid => rid.Id == role.RoleId).Select(n => n.Name).FirstOrDefault();

            return roleName;
        }

        public void ChangeUserRoleTitle(int userId, string roleTitle)
        {
            User user = this.Context.Users.Where(uid => uid.UserId == userId).FirstOrDefault();

            user.RoleTitle = roleTitle;

            this.Context.SaveChanges();
        }

        public string GetUserStringId(int userId)
        {
            return this.Context.Users.Where(uid => uid.UserId == userId).Select(id => id.Id).FirstOrDefault();
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

        public void EditUserProfile(UserViewModel model)
        {
            User user = this.Context.Users.Where(uid => uid.UserId == model.UserId).FirstOrDefault();

            user.AboutMe = model.AboutMe;
            user.AvatarUrl = model.AvatarUrl;
            user.ForumSignature = model.ForumSignature;
            user.LivingLocation = model.LivingLocation;

            this.Context.SaveChanges();
        }
    }
}