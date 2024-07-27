namespace IBERDROLA.TechnicalTest.ExternalServices.Configuration
{
    /// <summary>
    /// Abstraction defines Options Class for configure Http Client as external API's
    /// </summary>
    public interface IExternalOptions
    {

        /// <summary>
        /// Http Client
        /// </summary>
        public string TagHttpClient { get; set; }
        /// <summary>
        /// Url  
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
