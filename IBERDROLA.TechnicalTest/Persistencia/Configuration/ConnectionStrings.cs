namespace IBERDROLA.TechnicalTest.Persistence.Configuration
{
    /// <summary>
    /// Connection Strings
    /// </summary>
    public class ConnectionStrings
    {

        /// <summary>
        /// Name key appSettings
        /// </summary>
        public string SqlSivex { get; set; }
        /// <summary>
        /// Escritura
        /// </summary>
        public string SqlSivexRW { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ConnectionStrings()
        {
            this.SqlSivex=string.Empty;
            this.SqlSivexRW=string.Empty;   
        }
    }
}
