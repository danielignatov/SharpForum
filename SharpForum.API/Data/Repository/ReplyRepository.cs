using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using SharpForum.API.Services.Caching;
using System.Collections.Generic;
using System.Linq;

namespace SharpForum.API.Data.Repository
{
    public class ReplyRepository : GenericRepository<Reply>, IReplyRepository
    {
        public ReplyRepository(
            IDbContextFactory<DataContext> dbContextFactory,
            ICacheManager cacheManager,
            ILogger logger) : base(dbContextFactory, cacheManager, logger)
        {
        }

        public async Task<IEnumerable<Reply>> GetByTopicAsync(Guid topicId)
        {
            try
            {
                var allReplies = await this.GetAllCachedAsync();

                return allReplies.Where(x => x.TopicId == topicId);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "GetByTopicAsync method error");

                return Enumerable.Empty<Reply>();
            }
        }

        public async Task<IEnumerable<Reply>> GetByAuthorAsync(Guid userId)
        {
            try
            {
                var allReplies = await this.GetAllCachedAsync();

                return allReplies.Where(x => x.AuthorId == userId);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "GetByAuthorAsync method error");

                return Enumerable.Empty<Reply>();
            }
        }
    }
}
