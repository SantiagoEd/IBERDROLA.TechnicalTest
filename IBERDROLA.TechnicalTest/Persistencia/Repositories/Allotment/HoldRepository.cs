using Dapper;
using IBERDROLA.TechnicalTest.ExternalServices.AvailabilityB2B.Common.Models;
using IBERDROLA.TechnicalTest.Manager.Interfaces;
using IBERDROLA.TechnicalTest.Persistence.Configuration;
using IBERDROLA.TechnicalTest.Persistence.Interfaces;
using IBERDROLA.TechnicalTest.Persistence.Repositories.Allotment.Models;
using IBERDROLA.TechnicalTest.Persistence.Repositories.Allotment.Queries;
using IBERDROLA.TechnicalTest.Persistence.Repositories.Products.Repositories;
using Microsoft.Extensions.Options;
using System.Threading.Channels;

namespace IBERDROLA.TechnicalTest.Persistence.Repositories.Allotment
{
    public class HoldRepository : BaseRepository, IHoldRepository
    {
        public HoldRepository(IOptions<ConnectionStrings> connectionStrings, IDbConnectionFactory factory) : base(connectionStrings, factory)
        {
        }

        public async Task<IEnumerable<AllotmentValidate>> ValidateAllotment(IEnumerable<RateKey> rateKes)
        {
            using var connection = CreateDbFactoryConnection(_connectionStrings.SqlSivex);
            var result =  await connection.QueryAsync<AllotmentValidate>(AllotmentQueries.AllotmentValidate, new
            {
                Allotments = rateKes.Select(r => r.AllotmentReservationId)
            });

             return result;
        }

        public async Task<CClientUser> ValidateAgent(Guid? IdCode, int idAgent)
        {
            using var connection = CreateDbFactoryConnection(_connectionStrings.SqlSivex);
            var result = await connection.QueryFirstOrDefaultAsync<CClientUser>(CClientUserQueries.CclientUser, new
            {
                Code = IdCode,
                IdAgent = idAgent
            });

            return result;
        }

        public async Task<CClientContact> GetClientContact(Guid? IdCode)
        {
            using var connection = CreateDbFactoryConnection(_connectionStrings.SqlSivex);
            var result = await connection.QueryFirstOrDefaultAsync<CClientContact>(CClientUserQueries.CclientContact, new
            {
                Code = IdCode
            });

            return result;
        }


        public async Task<bool> ValidateBoxOffice(int idClient, int Channel,int boxOffice)
        {
            using var connection = CreateDbFactoryConnection(_connectionStrings.SqlSivex);
            var result = await connection.QueryFirstOrDefaultAsync<bool>(CClientUserQueries.cCaja, new
            {
                IdClient = idClient,
                IdChannel = Channel,
                BoxOffice = boxOffice
            });

            return result;
        }

        public async Task<bool> ValidatePickup(int _IdPickUp, int _IdProduct)
        {
            using var connection = CreateDbFactoryConnection(_connectionStrings.SqlSivex);
            var result = await connection.QueryFirstOrDefaultAsync<bool>(CClientUserQueries.cHotelPickup, new
            {
                IdPickUp = _IdPickUp,
                IdProduct = _IdProduct
            });

            return result;
        }

    }
}
