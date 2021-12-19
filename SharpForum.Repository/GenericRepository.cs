using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpForum.Persistence;
using SharpForum.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpForum.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DataContext _context;
        protected ILogger _logger;
        protected DbSet<T> _dbSet;

        public GenericRepository(
            DataContext context,
            ILogger logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual bool Update(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }
    }
}