using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using SharpForum.API.Services.Caching;
using System.Collections.Generic;
using System.Linq;

namespace SharpForum.API.Data.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private const int AllCategoriesCacheTime = 1440;

        public CategoryRepository(
            IDbContextFactory<DataContext> dbContextFactory, 
            ICacheManager cacheManager,
            ILogger logger) : base(dbContextFactory, cacheManager, logger)
        {
        }

        public override async Task<IEnumerable<Category>> GetAllAsync()
        {
            try
            {
                await using DataContext dbContext =
                    _dbContextFactory.CreateDbContext();

                return await dbContext.Categories.ToListAsync();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "GetAllAsync method error");

                return Enumerable.Empty<Category>();
            }
        }

        public override async Task<IEnumerable<Category>> GetAllCachedAsync()
        {
            try
            {
                return await _cacheManager.GetOrCreateAsync<IEnumerable<Category>>(typeof(Category).FullName, AllCategoriesCacheTime, async () => await this.GetAllAsync());
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "GetAllCachedAsync method error");

                return Enumerable.Empty<Category>();
            }
        }

        public override async Task<Category> GetByIdAsync(Guid id)
        {
            try
            {
                await using DataContext dbContext =
                       _dbContextFactory.CreateDbContext();

                return await dbContext.Categories.Include(x => x.Topics).ThenInclude(x => x.Replies).FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "GetByIdAsync method error");

                return null;
            }
        }

        public async Task<int> GetTopicCountAsync(Guid id)
        {
            try
            {
                var category = await GetByIdAsync(id);
                return category.Topics.Count;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "GetTopicCountAsync method error");
                return 0;
            }
        }

        public async Task<int> GetReplyCountAsync(Guid id)
        {
            try
            {
                var category = await GetByIdAsync(id);
                return category.Topics.Sum(x => x.Replies.Count);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, message: "GetReplyCountAsync method error");
                return 0;
            }
        }
    }
}