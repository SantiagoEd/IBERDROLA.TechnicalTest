using IBERDROLA.TechnicalTest.Persistence.Interfaces.Cache;

namespace IBERDROLA.TechnicalTest.Persistence.Cache
{
    /// <summary>
    /// 
    /// </summary>
    public class CacheStringHelper : ICacheString
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void DeleteCache(string key)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetCache(string key)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="duration"></param>
        public void SetCache(string key, string value, TimeSpan duration)
        {
            throw new NotImplementedException();
        }
    }
}
