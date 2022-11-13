using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpForum.API.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpForum.API.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IDbContextFactory<DataContext> _dbContextFactory;
        protected ILogger _logger;

        public GenericRepository(
            IDbContextFactory<DataContext> dbContextFactory,
            ILogger logger)
        {
            _dbContextFactory = dbContextFactory;
            _logger = logger;
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            await using DataContext dbContext =
                    _dbContextFactory.CreateDbContext();

            var dbSet = dbContext.Set<T>();

            await dbSet.AddAsync(entity);

            await dbContext.SaveChangesAsync();

            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            await using DataContext dbContext =
                    _dbContextFactory.CreateDbContext();

            return await dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            await using DataContext dbContext =
                    _dbContextFactory.CreateDbContext();

            var dbSet = dbContext.Set<T>();

            var entity = await GetByIdAsync(id);

            dbSet.Remove(entity);

            await dbContext.SaveChangesAsync();

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

            return true;
        }
    }
}