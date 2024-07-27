using IBERDROLA.TechnicalTest.ExternalServices.Configuration;

namespace IBERDROLA.TechnicalTest.ExternalServices.Character.Configuration
{
    /// <summary>
    /// agencies Options Class for configure Http Client
    /// </summary>
    public class CharacterOptions : IExternalOptions
    {

        /// <summary>
        /// Constructor default 
        /// </summary>
        public CharacterOptions()
        {
            this.TagHttpClient = string.Empty;
            this.Url = string.Empty;
        }

        /// <summary>
        /// Http Client
        /// </summary>
        public string TagHttpClient { get; set; }
        /// <summary>
        /// Url Synxis
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Miliseconds
        /// </summary>
        public int TimeOutCurrencies { get; set; }
        /// <summary>
        /// Miliseconds
        /// </summary>
        public int TimeOutExchanges { get; set; }
        /// <summary>
        /// Minutes
        /// </summary>
        public int MemoryTimeCache { get; set; }
    }
}
