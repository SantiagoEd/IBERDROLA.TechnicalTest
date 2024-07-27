namespace IBERDROLA.TechnicalTest.ExternalServices.Configuration
{

    /// <summary>
    /// Optioms por define policy and retries with POlly library
    /// </summary>
    public class PollyOptions
    {

        public int PolicyTimeOutSeconds { get; set; }

        public int PolicyLongTimeOutSeconds { get; set; }

        /// <summary>
        /// By defult PolicyTimeOutSeconds= 3, PolicyLongTimeOutSeconds=25
        /// </summary>
        public PollyOptions()
        {
            PolicyTimeOutSeconds = 3;
            PolicyLongTimeOutSeconds = 25;
        }
    }
}