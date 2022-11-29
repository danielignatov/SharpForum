using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;
using System.Threading;

namespace SharpForum.API.Services.Caching
{
    public class CacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;
        private ConcurrentDictionary<object, SemaphoreSlim> _locks = new ConcurrentDictionary<object, SemaphoreSlim>();

        public CacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<T> GetOrCreateAsync<T>(object key, int duration, Func<Task<T>> createItem)
        {
            T cacheEntry;

            if (!_memoryCache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                SemaphoreSlim mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));

                await mylock.WaitAsync();
                try
                {
                    if (!_memoryCache.TryGetValue(key, out cacheEntry))
                    {
                        // Key not in cache, so get data.
                        cacheEntry = await createItem();
                        _memoryCache.Set(key, cacheEntry, DateTime.Now + TimeSpan.FromMinutes(duration));
                    }
                }
                finally
                {
                    mylock.Release();
                }
            }

            return cacheEntry;
        }

        public void Remove(object key) 
        {
            _memoryCache.Remove(key);
        }
    }
}