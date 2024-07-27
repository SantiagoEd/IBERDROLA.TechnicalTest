namespace IBERDROLA.TechnicalTest.Persistence.Repositories.Common
{

    /// <summary>
    /// KVenta detalle queries
    /// </summary>
    public class KVentaDetalleQueries
    {

        /// <summary>
        ///  SELECT  dsFolioCuponAgencia FROM KVentaDetalle WITH(NOLOCK) WHERE idVentaDetalle = @saleDetailId
        /// </summary>
        internal const string SelectCouponQuery = @"
            
			SELECT 
				dsFolioCuponAgencia 
			FROM 
				KVentaDetalle WITH(NOLOCK)
			WHERE 
				idVentaDetalle = @saleDetailId
			
        ";

        /// <summary>
        /// Update KVenta set DsNotas=@Notes WHERE idVenta = @SaleId
        /// </summary>
        internal const string UpdateDsFolioCuponAgencia = @"
            
			Update KVentaDetalle
			set dsFolioCuponAgencia=@AgencyCouponId
			WHERE 
				idVentaDetalle = @saleDetailId
			
        ";

    }
}
