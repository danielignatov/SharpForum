using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using SharpForum.API.Services.Caching;
using System.Collections.Generic;
using System.Linq;

namespace SharpForum.API.Data.Repository
{
    public class TopicRepository : GenericRepository<Topic>, ITopicRepository
    {
        public TopicRepository(
            IDbContextFactory<DataContext> dbContextFactory,
            ICacheManager cacheManager,
            ILogger logger) : base(dbContextFactory, cacheManager, logger)
        {
        }
        
        public async Task<IEnumerable<Topic>> GetByCategoryAsync(Guid categoryId)
        {
            try
            {
                var allTopics = await this.GetAllCachedAsync();

                return allTopics.Where(x => x.CategoryId == categoryId);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "GetByCategoryAsync method error", typeof(TopicRepository));

                return Enumerable.Empty<Topic>();
            }
        }

        public async Task<IEnumerable<Topic>> GetByAuthorAsync(Guid userId)
        {
            try
            {
                var allTopics = await this.GetAllCachedAsync();

                return allTopics.Where(x => x.AuthorId == userId);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "GetByAuthorAsync method error", typeof(TopicRepository));

                return Enumerable.Empty<Topic>();
            }
        }

        public async Task<int> GetReplyCountAsync(Guid topicId)
        {
            try
            {
                var topic = await GetByIdAsync(topicId);
                return topic.Replies.Count;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "GetReplyCountAsync method error", typeof(TopicRepository));
                return 0;
            }
        }
    }
}