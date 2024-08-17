
namespace Location.Interfaces.CacheService
{
    public interface ICacheService
    {
        Task<T> GetFromCacheAsync<T>(string key, Func<Task<T>> factory, TimeSpan expiration) where T : class;
    }
}