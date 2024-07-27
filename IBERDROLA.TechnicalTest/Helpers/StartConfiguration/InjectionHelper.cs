using System.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using IBERDROLA.TechnicalTest.Persistence.Configuration;
using IBERDROLA.TechnicalTest.Manager.Utils;
using IBERDROLA.TechnicalTest.Manager.Configuration;
using IBERDROLA.TechnicalTest.ExternalServices.Configuration;

namespace IBERDROLA.TechnicalTest.Helpers.StartConfiguration
{
    internal static class InjectionHelper
    {
        internal static IServiceCollection AddInjectionServices(this IServiceCollection services, IConfiguration configuration)
          => services.AddApplicationServices(configuration)
                     .AddDbConnectionFactoryServices((sp) => new SqlConnection(), ServiceLifetime.Scoped)
                     .AddMemCacheAwsServices(configuration)
                     .AddExternalServices(configuration)
                     .AddHttpClientServices(configuration);
                     //.AddCompressionServices()
                     //.AddStackRedisCacheServices(configuration)
                     //.AddSwaggerServices()
                     //.AddLogServices(configuration);

       
        internal static IApplicationBuilder UseHealthChecks(this IApplicationBuilder app) 
            => app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapHealthChecks("/___readiness", new HealthCheckOptions()
                    {
                        ResultStatusCodes =
                        {
                            [HealthStatus.Healthy] = StatusCodes.Status200OK,
                            [HealthStatus.Degraded] = StatusCodes.Status200OK,
                            [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                        }
                    });
                    endpoints.MapHealthChecks("/___liveness", new HealthCheckOptions()
                    {
                        ResultStatusCodes =
                        {
                            [HealthStatus.Healthy] = StatusCodes.Status200OK,
                            [HealthStatus.Degraded] = StatusCodes.Status200OK,
                            [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                        }
                    });
                });

      
        
       
    }
}
