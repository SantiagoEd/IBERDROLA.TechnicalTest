using IBERDROLA.TechnicalTest.Manager.Interfaces;
using System.Text;

namespace IBERDROLA.TechnicalTest.ExternalServices
{
    /// <summary>
    /// Cliente para acceso a servicios
    /// </summary>
    public class ClientFactory : IClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;
        /// <summary>
        /// Client Factory Contructor
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public ClientFactory(IHttpClientFactory httpClientFactory)
            => _httpClientFactory = httpClientFactory;
        /// <summary>
        /// Get Async
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="tagHttpClient"></param>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="serializeFormat"></param>
        /// <returns></returns>
        public async Task<TResult> GetAsync<TResult>(string tagHttpClient,
            string url,
            Dictionary<string, string> headers,
            SerializeFormat serializeFormat)
        {
            var httpClient = _httpClientFactory.CreateClient(tagHttpClient);
            //Creating get request
            var requestGet = new HttpRequestMessage(HttpMethod.Get, url);

            SetHeaders(requestGet, headers);
            var result = await httpClient.SendAsync(requestGet);
            if (!result.IsSuccessStatusCode)
            {
                var headersLog = string.Empty;
                if (headers != null
                    && headers.Any())
                {
                    headersLog = string.Join(",", headers.Select(k => $"{k.Key}, {k.Value}"));
                }
                throw new HttpRequestException($"Url: {url} | Headers: [{headersLog}] | {await result.Content.ReadAsStringAsync()}");
            }
            return (await result.Content.ReadAsStreamAsync()).ToEntity<TResult>(serializeFormat);
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
        public async Task<TResult> PostAsync<TRequest, TResult>(string tagHttpClient,
            string url,
            TRequest request,
            Dictionary<string, string> headers,
            SerializeFormat serializeFormat)
        {
            var httpClient = _httpClientFactory.CreateClient(tagHttpClient);

            var requestPost = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Post
            };

            var requestStr = RequestToStringContent(request, serializeFormat);

            requestPost.Content = new StringContent(requestStr,
                Encoding.UTF8, SetContenType(serializeFormat));

            SetHeaders(requestPost, headers);
            var result = await httpClient.SendAsync(requestPost);

            if (!result.IsSuccessStatusCode)
            {
                var headersLog = string.Empty;
                if (headers != null
                    && headers.Any())
                {
                    headersLog = string.Join(",", headers.Select(k => $"{k.Key}, {k.Value}"));
                }
                throw new HttpRequestException($"Request: {requestStr} | Headers: [{headersLog}] | {await result.Content.ReadAsStringAsync()}");
            }
            return (await result.Content.ReadAsStreamAsync()).ToEntity<TResult>(serializeFormat);
        }

        private static string SetContenType(SerializeFormat serializeFormat)
            => serializeFormat == SerializeFormat.Xml ? "text/xml" : "application/json";

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
        public async Task<TResult> PutAsync<TRequest, TResult>(string tagHttpClient,
            string url,
            TRequest request,
            Dictionary<string, string> headers,
            SerializeFormat serializeFormat)
        {
            var httpClient = _httpClientFactory.CreateClient(tagHttpClient);
            SetHeaders(httpClient, headers);

            var requestStr = RequestToStringContent(request, serializeFormat);

            var result = await httpClient.PutAsync(url, new StringContent(
                requestStr, Encoding.UTF8, SetContenType(serializeFormat)));

            if (!result.IsSuccessStatusCode)
            {
                var headersLog = string.Empty;
                if (headers != null
                    && headers.Any())
                {
                    headersLog = string.Join(",", headers.Select(k => $"{k.Key}, {k.Value}"));
                }
                throw new HttpRequestException($"Request: {requestStr} | Headers: [{headersLog}] | {await result.Content.ReadAsStringAsync()}");
            }
            return (await result.Content.ReadAsStreamAsync()).ToEntity<TResult>(serializeFormat);
        }
        /// <summary>
        /// Remove
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="tagHttpClient"></param>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="serializeFormat"></param>
        /// <returns></returns>
        public async Task<TResult> RemoveAsync<TResult>(string tagHttpClient,
            string url,
            Dictionary<string, string> headers,
            SerializeFormat serializeFormat)
        {
            var httpClient = _httpClientFactory.CreateClient(tagHttpClient);
            SetHeaders(httpClient, headers);
            //Creating get request
            var result = await httpClient.DeleteAsync(url);

            if (!result.IsSuccessStatusCode)
            {
                var headersLog = string.Empty;
                if (headers != null
                    && headers.Any())
                {
                    headersLog = string.Join(",", headers.Select(k => $"{k.Key}, {k.Value}"));
                }
                throw new HttpRequestException($"Url: {url} | Headers: [{headersLog}] | {await result.Content.ReadAsStringAsync()}");
            }
            return (await result.Content.ReadAsStreamAsync()).ToEntity<TResult>(serializeFormat);
        }

        private static string RequestToStringContent<TRequest>(TRequest request, SerializeFormat serializeFormat)
        {
            var json= serializeFormat == SerializeFormat.Json ?
                                request.SerializeToJsonString() :
                                request.SerializeToXmlString();
            return json;
        }

        private void SetHeaders(HttpRequestMessage requestGet,
            Dictionary<string, string> headers)
        {
            if (headers != null && headers.Any())
            {
                foreach (var header in headers)
                {
                    requestGet.Headers.Add(header.Key, header.Value);
                }
            }
        }
        private void SetHeaders(HttpClient requestGet,
            Dictionary<string, string> headers)
        {
            if (headers != null && headers.Any())
            {
                foreach (var header in headers)
                {
                    requestGet.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
        }
    }
}
