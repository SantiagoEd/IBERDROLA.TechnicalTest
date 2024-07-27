using IBERDROLA.TechnicalTest.ExternalServices.Character.Response;

namespace IBERDROLA.TechnicalTest.ExternalServices.Character
{
    /// <summary>
    /// Abstraction about connect
    /// </summary>
    public interface ICharacterExternalService
    {
        /// <summary>
        /// Connect to service /Character
        /// </summary>
        /// <returns></returns>
        Task<CharacterResponse> GetCharacterAsync();
    }
}
