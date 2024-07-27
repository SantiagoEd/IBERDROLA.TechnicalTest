using Microsoft.Extensions.Options;
using System.Data.Common;
using IBERDROLA.TechnicalTest.Persistence.Interfaces;
using IBERDROLA.TechnicalTest.Persistence.Configuration;

namespace IBERDROLA.TechnicalTest.Persistence.Repositories.Products.Repositories
{
    /// <summary>
    /// Base Repository
    /// </summary>
    public abstract class BaseRepository
    {   
        private readonly IDbConnectionFactory _factory;

        /// <summary>
        /// Connection String
        /// </summary>
        protected readonly ConnectionStrings _connectionStrings;

        /// <summary>
        /// Constructor Base Repository
        /// </summary>
        /// <param name="connectionStrings"></param>
        /// <param name="factory"></param> 
        public BaseRepository(IOptions<ConnectionStrings> connectionStrings,
            IDbConnectionFactory factory)
        {
            _factory = factory;
            _connectionStrings = connectionStrings.Value;
        } 
        /// <summary>
        /// Create DBConnection
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public DbConnection CreateDbFactoryConnection(string connectionString)
        {
            return _factory.CreateConnection(connectionString);
        }
      

    }
}
