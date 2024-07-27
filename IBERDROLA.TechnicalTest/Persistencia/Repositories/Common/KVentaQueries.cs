using StackExchange.Redis;

namespace IBERDROLA.TechnicalTest.Persistence.Repositories.Common
{

    /// <summary>
    /// KVenta queries 
    /// </summary>
    public class KVentaQueries
    {
        /// <summary>
        ///  SELECT  dsNotas FROM KVenta WITH(NOLOCK) WHERE idVenta = @SaleId
        /// </summary>
        internal const string SelectNotasQuery = @"
            
			SELECT 
				dsNotas 
			FROM 
				KVenta WITH(NOLOCK)
			WHERE 
				idVenta = @SaleId
			
        ";

        /// <summary>
        /// Update KVenta set DsNotas=@Notes WHERE idVenta = @SaleId
        /// </summary>
        internal const string UpdateNotasQuery = @"
            
			Update KVenta 
			set DsNotas=@Notes
			WHERE 
				idVenta = @SaleId
			
        ";

    }
}
