using SharpForum.API.Models.Domain;
using System;
using System.Threading.Tasks;

namespace SharpForum.API.Data.Repository.Interfaces
{
    /// <summary>
    /// Category repository
    /// </summary>
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        /// <summary>
        /// Get total amount of topics in category
        /// </summary>
        /// <param name="id">Globally unique identifier</param>
        public Task<int> GetTopicCountAsync(Guid id);
    }
}