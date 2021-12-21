using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpForum.Domain;
using SharpForum.Persistence;
using SharpForum.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpForum.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(
            DataContext context,
            ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Category>> GetAllAsync()
        {
            try
            {
                return await _dbSet.Include(x => x.Topics).ToListAsync();
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
                return await _dbSet.Include(x => x.Topics).FirstOrDefaultAsync(x => x.Id == id);
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