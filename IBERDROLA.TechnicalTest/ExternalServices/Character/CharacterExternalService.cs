using IBERDROLA.TechnicalTest.ExternalServices.Character.Configuration;
using IBERDROLA.TechnicalTest.ExternalServices.Character.Response;
using IBERDROLA.TechnicalTest.Manager.Interfaces;
using Microsoft.Extensions.Options;

namespace IBERDROLA.TechnicalTest.ExternalServices.Character
{
    /// <summary>
    /// Character ExternalService
    /// </summary>
    public class CharacterExternalService : ClientService, ICharacterExternalService
    {
        private readonly CharacterOptions _characterOptions;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="options"></param>
        /// <param name="clientFactory"></param>
        public CharacterExternalService(IOptions<CharacterOptions> options,
          IClientFactory clientFactory) :
          base(clientFactory) => _characterOptions = options.Value;

        ///<inheritdoc/>
        public async Task<CharacterResponse> GetCharacterAsync()
        {
            return await GetAsync<CharacterResponse>(_characterOptions.TagHttpClient,
                                          $"{_characterOptions.Url}/character",
                                          null,
                                          SerializeFormat.Json);
        }
    }
}
