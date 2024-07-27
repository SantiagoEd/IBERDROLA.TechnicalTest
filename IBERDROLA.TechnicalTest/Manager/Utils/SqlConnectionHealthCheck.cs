using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data.Common;
using System.Data.SqlClient;

namespace IBERDROLA.TechnicalTest.Application.Utils
{
    /// <summary>
    /// Sql Connection Health Check
    /// </summary>
    public class SqlConnectionHealthCheck : IHealthCheck
    {
        private static readonly string DefaultTestQuery = "Select 1";

        /// <summary>
        /// Connection String Check
        /// </summary>
        public string ConnectionString { get; }

        /// <summary>
        /// Query Check
        /// </summary>
        public string TestQuery { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public SqlConnectionHealthCheck(string connectionString)
            : this(connectionString, testQuery: DefaultTestQuery)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="testQuery"></param>
        public SqlConnectionHealthCheck(string connectionString, string testQuery)
        {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            TestQuery = testQuery;
        }

        /// <summary>
        /// Check Health DataBase
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    await connection.OpenAsync(cancellationToken);

                    if (TestQuery != null)
                    {
                        var command = connection.CreateCommand();
                        command.CommandText = TestQuery;

                        await command.ExecuteNonQueryAsync(cancellationToken);
                    }
                }
                catch (DbException ex)
                {
                    return new HealthCheckResult(status: context.Registration.FailureStatus, exception: ex);
                }
            }

            return HealthCheckResult.Healthy();
        }
    }
}
