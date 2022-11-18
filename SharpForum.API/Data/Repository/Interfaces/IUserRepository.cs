using SharpForum.API.Models.Domain;
using System.Collections.Generic;

namespace SharpForum.API.Data.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<IEnumerable<User>> GetByRoleAsync(Guid roleId);

        public Task<User> GetByEmailAsync(string email);
    }
}