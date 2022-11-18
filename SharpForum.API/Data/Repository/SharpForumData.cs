using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using SharpForum.API.Services.Caching;

namespace SharpForum.API.Data.Repository
{
    public class SharpForumData : ISharpForumData
    {
        private readonly IDbContextFactory<DataContext> _dbContextFactory;
        private readonly ICacheManager _cacheManager;
        private readonly ILogger _logger;

        public SharpForumData(
            IDbContextFactory<DataContext> dbContextFactory,
            ICacheManager cacheManager,
            ILoggerFactory loggerFactory)
        {
            _cacheManager = cacheManager;
            _dbContextFactory = dbContextFactory;
            _logger = loggerFactory.CreateLogger("logs");
            Categories = new CategoryRepository(_dbContextFactory, _cacheManager, _logger);
            Topics = new TopicRepository(_dbContextFactory, _cacheManager, _logger);
            Replies = new ReplyRepository(_dbContextFactory, _cacheManager, _logger);
            Users = new UserRepository(_dbContextFactory, _cacheManager, _logger);
            Roles = new GenericRepository<Role>(_dbContextFactory, _cacheManager, _logger);
        }

        public ICategoryRepository Categories { get; private set; }

        public ITopicRepository Topics { get; private set; }

        public IReplyRepository Replies { get; private set; }

        public IUserRepository Users { get; private set; }

        public IGenericRepository<Role> Roles { get; private set; }
    }
}