using SharpForum.API.Models.Domain;
using System.Collections.Generic;

namespace SharpForum.API.Data.Repository.Interfaces
{
    public interface IReplyRepository : IGenericRepository<Reply>
    {
        public Task<IEnumerable<Reply>> GetByTopicAsync(Guid topicId);

        public Task<IEnumerable<Reply>> GetByAuthorAsync(Guid userId);
    }
}