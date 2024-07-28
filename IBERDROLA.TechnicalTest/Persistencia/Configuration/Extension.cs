using IBERDROLA.TechnicalTest.Helpers.StartConfiguration;
using IBERDROLA.TechnicalTest.Persistence.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Data.Common;

namespace IBERDROLA.TechnicalTest.Persistence.Configuration
{
    /// <summary>
    /// Clase de extension para funcionalidad del factory de conexiones a base de datos
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Metodo que agrega el DbConnectionFactory
        /// </summary>
        /// <param name="services"></param>
        /// <param name="factory"></param>
        /// <param name="lifetime"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbConnectionFactoryServices(this IServiceCollection services,
             Func<IServiceProvider, DbConnection> factory,
             ServiceLifetime lifetime)
        {
            object factoryWrapper(IServiceProvider x) => new DefaultConnectionFactory(() => factory(x));
            services.TryAdd(new ServiceDescriptor(typeof(IDbConnectionFactory), factoryWrapper, lifetime));
            return services;
        }
    }
}
