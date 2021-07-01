using Sporting.Statistics.DbAdapter;
using Sporting.Statistics.Domain.Adapters;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DbAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddDbAdapter(
            this IServiceCollection services,
            DbAdapterConfiguration dbAdapterConfiguration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (dbAdapterConfiguration == null)
            {
                throw new ArgumentNullException(nameof(dbAdapterConfiguration));
            }

            services.AddScoped<IDbConnection>(d =>
            {
                return new SqlConnection(dbAdapterConfiguration.SqlConnectionString);
            });

            services.AddScoped<IDbReadAdapter, DbReadAdapter>();
            services.AddScoped<IDbWriteAdapter, DbWriteAdapter>();

            return services;
        }
    }
}
