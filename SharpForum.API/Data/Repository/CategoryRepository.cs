using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace SharpForum.API.Data.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(
            IDbContextFactory<DataContext> dbContextFactory,
            ILogger logger) : base(dbContextFactory, logger)
        {
        }

        public override async Task<IEnumerable<Category>> GetAllAsync()
        {
            try
            {
                await using DataContext dbContext =
                    _dbContextFactory.CreateDbContext();

                return await dbContext.Categories.Include(x => x.Topics).ToListAsync();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "GetAllAsync method error", typeof(CategoryRepository));
                return Enumerable.Empty<Category>();
            }
        }

        public override async Task<Category> GetByIdAsync(Guid id)
        {
            try
            {
                await using DataContext dbContext =
                       _dbContextFactory.CreateDbContext();

                return await dbContext.Categories.Include(x => x.Topics).FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "GetByIdAsync method error", typeof(CategoryRepository));
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
                _logger.LogError(exception, "GetTopicCountAsync method error", typeof(CategoryRepository));
                return 0;
            }
        }
    }
}