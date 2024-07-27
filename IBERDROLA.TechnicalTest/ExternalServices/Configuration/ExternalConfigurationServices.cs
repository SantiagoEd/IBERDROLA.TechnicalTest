using IBERDROLA.TechnicalTest.ExternalServices.Configuration;
using IBERDROLA.TechnicalTest.ExternalServices.Character;
using IBERDROLA.TechnicalTest.ExternalServices.Character.Configuration;

namespace IBERDROLA.TechnicalTest.ExternalServices.Configuration
{
    /// <summary>
    /// Configuration Net's Inyector Dependency for layer application and external services API.
    /// </summary>
    public static class ExternalConfigurationServices
    {
        internal static IServiceCollection AddExternalServices(this IServiceCollection services,
           IConfiguration configuration)
           => services.Configure<CharacterOptions>(configuration.GetSection("CharacterOptions"))
                       .AddScoped<ICharacterExternalService, CharacterExternalService>()
                       .Configure<PollyOptions>(configuration.GetSection("PollyOptions"));

    }
}
