using SharpForum.API.Models.Domain;
using System.Collections.Generic;

namespace SharpForum.API.Data.Repository.Interfaces
{
    public interface ITopicRepository : IGenericRepository<Topic>
    {
        public Task<IEnumerable<Topic>> GetByCategoryAsync(Guid categoryId);

        public Task<IEnumerable<Topic>> GetByAuthorAsync(Guid userId);

        /// <summary>
        /// Get total amount of topic replies
        /// </summary>
        /// <param name="topicId">Globally unique identifier</param>
        public Task<int> GetReplyCountAsync(Guid topicId);
    }
}