
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Otc.AspNetCore.ApiBoot;
using Otc.Extensions.Configuration;
using Sporting.Statistics.Application.Microsoft.Extensions.DependencyInjection;
using Sporting.Statistics.FooteballApiAdapter;
using Microsoft.Extensions.DependecyInjection;
using Sporting.Statistics.DbAdapter;

namespace Sporting.Statistics.WebApi
{
    /// <summary>
    /// Este eh o Startup da API. 
    /// <para>
    /// A base <see cref="ApiBootStartup"/> implementa uma serie de requisitos
    /// que consideramos necessarios para qualquer API, como Log, Swagger,
    /// Authorizacao, Versionamento e muito mais.
    /// Veja https://github.com/OleConsignado/otc-aspnetcore-apiboot para maiores
    /// detalhes.
    /// </para>
    /// </summary>
    public class Startup : ApiBootStartup
    {
        protected override ApiMetadata ApiMetadata => new ApiMetadata()
        {
            Name = "SportingStatistics",
            Description = "Incluir observação.",
            DefaultApiVersion = "1.0"
        };
        public Startup(IConfiguration configuration)
            : base(configuration)
        {

        }

        /// <summary>
        /// Registra os servicos especificos da API.
        /// </summary>
        /// <param name="services"></param>
        protected override void ConfigureApiServices(
            IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(WebApiMapperProfile),
                typeof(SportingStatisticsFooteballApiMapperProfile));

            services.AddApplication();

            services.AddDbAdapter(Configuration.SafeGet<DbAdapterConfiguration>());

            services.AddSportingStatisticsFooteballApiAdapter(
                Configuration
                .SafeGet<SportingStatisticsFooteballApiAdapterConfiguration>());

        }
    }
}
