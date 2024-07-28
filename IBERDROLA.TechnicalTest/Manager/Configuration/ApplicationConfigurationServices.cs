using IBERDROLA.TechnicalTest.Manager.Interfaces;
using IBERDROLA.TechnicalTest.ExternalServices;
using IBERDROLA.TechnicalTest.Manager.Services.Character;
using IBERDROLA.TechnicalTest.Manager.Configuration;
namespace IBERDROLA.TechnicalTest.Manager.Configuration
{

    /// <summary>
    /// Configuration Net's Inyector Dependency for layer application
    /// </summary>
    internal static class ApplicationConfigurationServices
    {
        internal static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
            => services.AddSingleton<IClientFactory, ClientFactory>()
                        .AddScoped<ICharacterServicesServices, CharacterServices>();

           
    }
}