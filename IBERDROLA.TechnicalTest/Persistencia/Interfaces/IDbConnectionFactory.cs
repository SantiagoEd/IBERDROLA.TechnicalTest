using System.Data.Common;

namespace IBERDROLA.TechnicalTest.Persistence.Interfaces
{
    /// <summary>
    /// Interfaz para el factory de conexiones a base de datos
    /// </summary>
    public interface IDbConnectionFactory
    {
        /// <summary>
        /// Propiedad DbConnection para setear una nueva conexion
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        DbConnection CreateConnection(string connectionString);
    }
}
