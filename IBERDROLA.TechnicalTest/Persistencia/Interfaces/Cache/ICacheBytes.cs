

using Microsoft.Extensions.Caching.Distributed;

namespace IBERDROLA.TechnicalTest.Persistence.Interfaces.Cache
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICacheBytes
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSave"></typeparam>
        /// <param name="key"></param>
        /// <param name="body"></param>
        /// <param name="cacheEntryOptions"></param>
        /// <returns></returns>
        Task SetCacheAsync<TSave>(string key, TSave body, DistributedCacheEntryOptions cacheEntryOptions);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<TResult> GetCacheAsync<TResult>(string key, CancellationToken token = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        void DeleteCache(string key);
    }
}
