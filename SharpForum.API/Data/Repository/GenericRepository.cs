using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Services.Caching;
using System.Collections.Generic;

namespace SharpForum.API.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected const int DefaultCacheTime = 5;
        protected readonly IDbContextFactory<DataContext> _dbContextFactory;
        protected ICacheManager _cacheManager;
        protected ILogger _logger;

        public GenericRepository(
            IDbContextFactory<DataContext> dbContextFactory, 
            ICacheManager cacheManager,
            ILogger logger)
        {
            _dbContextFactory = dbContextFactory;
            _cacheManager = cacheManager;
            _logger = logger;
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            await using DataContext dbContext =
                    _dbContextFactory.CreateDbContext();

            var dbSet = dbContext.Set<T>();

            await dbSet.AddAsync(entity);

            await dbContext.SaveChangesAsync();

            _cacheManager.Remove(typeof(T).FullName);

            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            await using DataContext dbContext =
                    _dbContextFactory.CreateDbContext();

            return await dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllCachedAsync()
        {
            return await _cacheManager.GetOrCreateAsync<IEnumerable<T>>(typeof(T).FullName, DefaultCacheTime, async () => await this.GetAllAsync());
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            await using DataContext dbContext =
                    _dbContextFactory.CreateDbContext();

            var dbSet = dbContext.Set<T>();

            var entity = await GetByIdAsync(id);

            dbSet.Remove(entity);

            await dbContext.SaveChangesAsync();

            _cacheManager.Remove(typeof(T).FullName);

            return true;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            await using DataContext dbContext =
                    _dbContextFactory.CreateDbContext();

            var dbSet = dbContext.Set<T>();

            return await dbSet.FindAsync(id);
        }

        public virtual bool Update(T entity)
        {
            using DataContext dbContext =
                    _dbContextFactory.CreateDbContext();

            var dbSet = dbContext.Set<T>();

            dbSet.Update(entity);

            dbContext.SaveChanges();

            _cacheManager.Remove(typeof(T).FullName);

            return true;
        }
    }
}