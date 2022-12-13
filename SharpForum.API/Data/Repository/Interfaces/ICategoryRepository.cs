using SharpForum.API.Models.Domain;

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

        /// <summary>
        /// Get total amount of topic replies in category
        /// </summary>
        /// <param name="id">Globally unique identifier</param>
        public Task<int> GetReplyCountAsync(Guid id);
    }
}