using IBERDROLA.TechnicalTest.Persistence.Interfaces;
using System;
using System.Data.Common;

namespace IBERDROLA.TechnicalTest.Helpers.StartConfiguration
{
    /// <summary>
    /// Clase que crea un factory de conexiones a base de datos para inyectarlo como dependencia
    /// </summary>
    public class DefaultConnectionFactory : IDbConnectionFactory
    {
        private readonly Func<DbConnection> _factory;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="factory"></param>
        public DefaultConnectionFactory(Func<DbConnection> factory) => _factory = factory;
        /// <summary>
        /// Metodo: Crea la conexion asignando el connectionString que recibe de parametro
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public DbConnection CreateConnection(string connectionString)
        {
            var connection = _factory();
            connection.ConnectionString = connectionString;
            return connection;
        }
    }
}
