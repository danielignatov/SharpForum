using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpForum.Repository.Interfaces
{
    /// <summary>
    /// Defines generic methods for common types of data operation
    /// </summary>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Get all
        /// </summary>
        public Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id">Globally unique identifier</param>
        public Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity">Entity</param>
        public Task<bool> AddAsync(T entity);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">Globally unique identifier</param>
        public Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity">Entity</param>
        public bool Update(T entity);
    }
}