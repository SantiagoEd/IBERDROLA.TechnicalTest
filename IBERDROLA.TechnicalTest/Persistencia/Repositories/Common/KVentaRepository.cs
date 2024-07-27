using Dapper;
using IBERDROLA.TechnicalTest.Manager.Interfaces;
using IBERDROLA.TechnicalTest.Persistence.Configuration;
using IBERDROLA.TechnicalTest.Persistence.Interfaces;
using IBERDROLA.TechnicalTest.Persistence.Repositories.Products.Repositories;
using Microsoft.Extensions.Options;

namespace IBERDROLA.TechnicalTest.Persistence.Repositories.Common
{
    public class KVentaRepository : BaseRepository, IKVentaRepository
    {
        public KVentaRepository(IOptions<ConnectionStrings> connectionStrings, IDbConnectionFactory factory) : base(connectionStrings, factory)
        {
        }

        /// <inheritdoc/> 

        public async Task<string> SelectAgencyCouponId(int saleDetailId)
        {
            using var connection = CreateDbFactoryConnection(_connectionStrings.SqlSivex);
            var result = await connection.QueryFirstOrDefaultAsync<string>(KVentaDetalleQueries.SelectCouponQuery, new
            {
                SaleDetailId = saleDetailId
            });
            return result;
        }

        /// <inheritdoc/> 

        public async Task<string> SelectNotes(int saleId)
        {
            using var connection = CreateDbFactoryConnection(_connectionStrings.SqlSivex);
            var result = await connection.QueryFirstOrDefaultAsync<string>(KVentaQueries.SelectNotasQuery, new
            {               
                SaleId = saleId
            });
            return result;
        }


        /// <inheritdoc/> 
        public async Task<int> UpdateAgencyCouponId(int saleDetailId, string agencyCouponId)
        {
            using var connection = CreateDbFactoryConnection(_connectionStrings.SqlSivex);
            var result = await connection.ExecuteAsync(KVentaDetalleQueries.UpdateDsFolioCuponAgencia, new
            {
                AgencyCouponId= agencyCouponId ,
                SaleDetailId = saleDetailId
            });
            return result;
        }

        /// <inheritdoc/> 
        public async Task<int> UpdateNotes(int saleId, string notes)
        {
            using var connection = CreateDbFactoryConnection(_connectionStrings.SqlSivex);
            var result = await connection.ExecuteAsync(KVentaQueries.UpdateNotasQuery, new
            {
                Notes = notes,
                SaleId = saleId
            });
            return result;
        }
    }
}
