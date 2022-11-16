namespace SharpForum.API.Services.Caching
{
    public interface ICacheManager
    {
        /// <param name="key">Key to retreve the cache record</param>
        /// <param name="duration">Duration in minutes</param>
        /// <param name="createItem">Function to create the record if not found in cache</param>
        Task<T> GetOrCreateAsync<T>(object key, int duration, Func<Task<T>> createItem);
    }
}