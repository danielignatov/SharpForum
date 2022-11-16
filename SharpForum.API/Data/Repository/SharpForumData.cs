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
            Topics = new GenericRepository<Topic>(_dbContextFactory, _cacheManager, _logger);
            Replies = new GenericRepository<Reply>(_dbContextFactory, _cacheManager, _logger);
        }

        public ICategoryRepository Categories { get; private set; }

        public IGenericRepository<Topic> Topics { get; private set; }

        public IGenericRepository<Reply> Replies { get; private set; }
    }
}