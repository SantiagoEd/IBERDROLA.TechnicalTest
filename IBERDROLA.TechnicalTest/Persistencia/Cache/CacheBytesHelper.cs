using IBERDROLA.TechnicalTest.Persistence.Interfaces.Cache;
using Microsoft.Extensions.Caching.Distributed;
using ProtoBuf;

namespace IBERDROLA.TechnicalTest.Persistence.Cache
{
    /// <summary>
    /// 
    /// </summary>
    public class CacheBytesHelper : ICacheBytes
    {
        private readonly IDistributedCache _cache;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cache"></param>
        public CacheBytesHelper(IDistributedCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void DeleteCache(string key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<TResult> GetCacheAsync<TResult>(string key, CancellationToken token = default)
        {
            try
            {
                var result = default(TResult);
                var response = await _cache.GetAsync(key,token);
                if (response != null)
                {
                    using var stream = new MemoryStream(response);
                    result = Serializer.Deserialize<TResult>(stream);
                }
                return result;
            }
            catch (Exception)
            {
                return default;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSave"></typeparam>
        /// <param name="key"></param>
        /// <param name="message"></param>
        ///  <param name="cacheEntryOptions"></param>
        public async Task SetCacheAsync<TSave>(string key, TSave message, DistributedCacheEntryOptions cacheEntryOptions)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    Serializer.Serialize(memoryStream, message);
                    await _cache.SetAsync(key, memoryStream.ToArray(), cacheEntryOptions);
                }
            }
            catch (Exception )
            {
                //throw new Exception($"Redis SET error:{ex.Message}");
            }

        }
    }
}
