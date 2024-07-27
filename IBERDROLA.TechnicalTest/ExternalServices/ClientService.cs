using IBERDROLA.TechnicalTest.Manager.Interfaces;

namespace IBERDROLA.TechnicalTest.ExternalServices
{

    /// <summary>
    /// Class for call integrate external services through protocol http
    /// </summary>
    public abstract class ClientService
    {

        private readonly IClientFactory _clientFactory;

        /// <summary>
        /// Constructor Base Repository
        /// </summary>
        /// <param name="clientFactory"></param>
        public ClientService(IClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }



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
        protected async Task<TResult> PostAsync<TRequest, TResult>(string tagHttpClient,
            string url,
            TRequest request,
            Dictionary<string, string> headers,
            SerializeFormat serializeFormat)
        {
            return await _clientFactory.PostAsync<TRequest, TResult>(tagHttpClient, url, request, headers, serializeFormat);
        }
        /// <summary>
        /// GetAsync
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="tagHttpClient"></param>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="serializeFormat"></param>
        /// <returns></returns>
        protected async Task<TResult> GetAsync<TResult>(string tagHttpClient, string url, Dictionary<string, string> headers, SerializeFormat serializeFormat)
        {
            return await _clientFactory.GetAsync<TResult>(tagHttpClient, url, headers, serializeFormat);
        }

        /// <summary>
        /// Put Async
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="tagHttpClient"></param>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <param name="headers"></param>
        /// <param name="serializeFormat"></param>
        /// <returns></returns>
        protected async Task<TResult> PutAsync<TRequest, TResult>(string tagHttpClient, string url, TRequest request, Dictionary<string, string> headers, SerializeFormat serializeFormat)
        {
            return await _clientFactory.PutAsync<TRequest, TResult>(tagHttpClient, url, request, headers, serializeFormat);
        }

        /// <summary>
        /// Remove Async
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="tagHttpClient"></param>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="serializeFormat"></param>
        /// <returns></returns>
        protected async Task<TResult> RemoveAsync<TResult>(string tagHttpClient, string url, Dictionary<string, string> headers, SerializeFormat serializeFormat)
        {
            return await _clientFactory.RemoveAsync<TResult>(tagHttpClient, url, headers, serializeFormat);
        }


    }
}
