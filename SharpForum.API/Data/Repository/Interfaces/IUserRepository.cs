using SharpForum.API.Models.Domain;
using System.Collections.Generic;

namespace SharpForum.API.Data.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<IEnumerable<User>> GetByRoleAsync(Guid roleId);

        public Task<User> GetByEmailAsync(string email);

        public Task<User> GetByDisplayNameAsync(string displayName);

        /// <summary>
        /// Get total count of user created topics and replies
        /// </summary>
        /// <param name="userId">Globally unique identifier</param>
        public Task<int> GetPostCountAsync(Guid userId);
    }
}