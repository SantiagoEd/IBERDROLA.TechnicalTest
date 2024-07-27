using IBERDROLA.TechnicalTest.Persistence.Cache;
using IBERDROLA.TechnicalTest.Persistence.Interfaces.Cache;

namespace IBERDROLA.TechnicalTest.Persistence.Configuration
{

    /// <summary>
    /// Configuration Net's Inyector Dependency for layer persistence and cache providers like AWS
    /// </summary>
    public static class CacheConfigurationServices
    {
        internal static IServiceCollection AddMemCacheAwsServices(this IServiceCollection services, IConfiguration configuration)
           =>
                services.AddSingleton<ICacheBytes, CacheBytesHelper>()
                    .AddMemoryCache()
                            .Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"))                
                    .AddEasyCaching(option =>
                           {
                               option.UseMemcached(config =>
                               {
                                   config.DBConfig.AddServer(configuration["XCache:MemCache:Connection"], int.Parse(configuration["XCache:MemCache:Port"]));
                               });
                           });
        
    }

}
