using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using SharpForum.API.Services.Caching;
using System.Collections.Generic;
using System.Linq;

namespace SharpForum.API.Data.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(
            IDbContextFactory<DataContext> dbContextFactory, 
            ICacheManager cacheManager, 
            ILogger logger) : base(dbContextFactory, cacheManager, logger)
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            try
            {
                var allUsers = await this.GetAllAsync();

                return allUsers.Where(x => x.Email == email).FirstOrDefault();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "GetByEmailAsync method error");

                return null;
            }
        }

        public async Task<User> GetByDisplayNameAsync(string displayName)
        {
            try
            {
                var allUsers = await this.GetAllAsync();

                return allUsers.Where(x => x.DisplayName == displayName).FirstOrDefault();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "GetByDisplayNameAsync method error");

                return null;
            }
        }

        public async Task<IEnumerable<User>> GetByRoleAsync(Guid roleId)
        {
            try
            {
                var allUsers = await this.GetAllCachedAsync();

                return allUsers.Where(x => x.RoleId == roleId);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "GetByRoleAsync method error");

                return Enumerable.Empty<User>();
            }
        }

        public async Task<int> GetPostCountAsync(Guid userId)
        {
            try
            {
                await using DataContext dbContext =
                    _dbContextFactory.CreateDbContext();

                var replyCount =
                    dbContext.Replies.Where(x => x.AuthorId == userId).Count();

                var topicCount =
                    dbContext.Replies.Where(x => x.AuthorId == userId).Count();

                return replyCount + topicCount;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "GetPostCountAsync method error");
                return 0;
            }
        }
    }
}