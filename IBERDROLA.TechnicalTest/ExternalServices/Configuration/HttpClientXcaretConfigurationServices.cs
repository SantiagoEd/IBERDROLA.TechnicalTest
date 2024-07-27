using CorrelationId.HttpClient;
using Polly;
using System.Net;
using System.Security.Authentication;


namespace IBERDROLA.TechnicalTest.ExternalServices.Configuration
{

    /// <summary>
    ///  Configuration Net's Inyector Dependency for HttpClient and comunicate others Api's through HTTP Protocol
    /// </summary>
    internal static class HttpClientConfigurationServices
    {

        internal static IServiceCollection AddHttpClientServices(this IServiceCollection services,
           IConfiguration configuration)
        {
            var timeout = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(Convert.ToInt32(configuration["PollyOptions:PolicyTimeOutSeconds"] ?? "3")));
            var longTimeout = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(Convert.ToInt32(configuration["PollyOptions:PolicyLongTimeOutSeconds"] ?? "25")));


            services.AddHttpClient("Character", c =>
            {
                c.BaseAddress = new Uri(configuration["CharacterOptions:Url"]);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            }).AddCorrelationIdForwarding().
               AddPolicyHandler(request =>
                            request.Method == HttpMethod.Get ? timeout : longTimeout)
                   .SetHandlerLifetime(TimeSpan.FromMinutes(10))
                   .ConfigureHttpMessageHandlerBuilder((c) =>
                            new HttpClientHandler()
                            {
                                SslProtocols = SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13,
                                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                            });

            return services;
        }

    }
}
