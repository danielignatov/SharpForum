using Microsoft.Extensions.Logging;
using SharpForum.Domain;
using SharpForum.Persistence;
using SharpForum.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace SharpForum.Repository
{
    public class SharpForumData : ISharpForumData, IDisposable
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;

        public SharpForumData(DataContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            Categories = new CategoryRepository(_context, _logger);
            Topics = new GenericRepository<Topic>(_context, _logger);
            Replies = new GenericRepository<Reply>(_context, _logger);
        }

        public ICategoryRepository Categories { get; private set; }

        public IGenericRepository<Topic> Topics { get; private set; }

        public IGenericRepository<Reply> Replies { get; private set; }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}