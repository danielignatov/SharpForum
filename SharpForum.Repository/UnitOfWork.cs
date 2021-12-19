using Microsoft.Extensions.Logging;
using SharpForum.Persistence;
using SharpForum.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace SharpForum.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(DataContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            Categories = new CategoryRepository(_context, _logger);
        }

        public ICategoryRepository Categories { get; private set; }

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}