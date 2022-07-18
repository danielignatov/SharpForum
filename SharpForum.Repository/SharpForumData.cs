using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpForum.Domain;
using SharpForum.Persistence;
using SharpForum.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace SharpForum.Repository
{
    public class SharpForumData : ISharpForumData
    {
        private readonly IDbContextFactory<DataContext> _dbContextFactory;
        private readonly ILogger _logger;

        public SharpForumData(
            IDbContextFactory<DataContext> dbContextFactory,
            ILoggerFactory loggerFactory)
        {
            _dbContextFactory = dbContextFactory;
            _logger = loggerFactory.CreateLogger("logs");
            Categories = new CategoryRepository(_dbContextFactory, _logger);
            Topics = new GenericRepository<Topic>(_dbContextFactory, _logger);
            Replies = new GenericRepository<Reply>(_dbContextFactory, _logger);
        }

        public ICategoryRepository Categories { get; private set; }

        public IGenericRepository<Topic> Topics { get; private set; }

        public IGenericRepository<Reply> Replies { get; private set; }

        public async Task<bool> SaveAsync()
        {
            return true;
        }
    }
}