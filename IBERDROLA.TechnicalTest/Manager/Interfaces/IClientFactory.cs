using IBERDROLA.TechnicalTest.ExternalServices;

namespace IBERDROLA.TechnicalTest.Manager.Interfaces
{
    /// <summary>
    /// Client Factory
    /// </summary>
    public interface IClientFactory
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="tagHttpClient"></param>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="serializeFormat"></param>
        /// <returns></returns>
        Task<TResult> GetAsync<TResult>(string tagHttpClient, string url, Dictionary<string, string> headers, SerializeFormat serializeFormat);
        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="tagHttpClient"></param>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <param name="headers"></param>
        /// <param name="serializeFormat"></param>
        /// <returns></returns>
        Task<TResult> PostAsync<TRequest, TResult>(string tagHttpClient, string url, TRequest request, Dictionary<string, string> headers, SerializeFormat serializeFormat);
        /// <summary>
        /// Put
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="tagHttpClient"></param>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <param name="headers"></param>
        /// <param name="serializeFormat"></param>
        /// <returns></returns>
        Task<TResult> PutAsync<TRequest, TResult>(string tagHttpClient, string url, TRequest request, Dictionary<string, string> headers, SerializeFormat serializeFormat);
        /// <summary>
        /// Remove
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="tagHttpClient"></param>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="serializeFormat"></param>
        /// <returns></returns>
        Task<TResult> RemoveAsync<TResult>(string tagHttpClient, string url, Dictionary<string, string> headers, SerializeFormat serializeFormat);
    }
}