namespace IBERDROLA.TechnicalTest.Persistence.Interfaces.Cache
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICacheString
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="duration"></param>
        void SetCache(string key, string value, TimeSpan duration);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetCache(string key);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        void DeleteCache(string key);
    }
}
