using IBERDROLA.TechnicalTest.Manager.Interfaces;
using IBERDROLA.TechnicalTest.ExternalServices;
using IBERDROLA.TechnicalTest.Manager.Services.Character;
using IBERDROLA.TechnicalTest.Persistence.Repositories.Allotment;
using IBERDROLA.TechnicalTest.Manager.Configuration;
using IBERDROLA.TechnicalTest.Persistence.Repositories.Common;

namespace IBERDROLA.TechnicalTest.Manager.Configuration
{

    /// <summary>
    /// Configuration Net's Inyector Dependency for layer application
    /// </summary>
    internal static class ApplicationConfigurationServices
    {
        internal static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
            => services.AddSingleton<IClientFactory, ClientFactory>()
                        .AddScoped<IValidateCarShopServices, CharacterServices>()
                        .AddScoped<IHoldRepository, HoldRepository>()
                        .AddScoped<IKVentaRepository, KVentaRepository>()
                        .Configure<AppOptions>(configuration.GetSection("AppOptions"));

           
    }
}