using Microsoft.Extensions.DependencyInjection;
using Otc.Networking.Http.Client.Abstractions;
using Refit;
using Sporting.Statistics.Domain.Adapters;
using Sporting.Statistics.FooteballApiAdapter;
using Sporting.Statistics.FooteballApiAdapter.Clients;
using System;


namespace Microsoft.Extensions.DependecyInjection
{
    public static class SportingStatisticsFootballApiAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddSportingStatisticsFooteballApiAdapter(
            this IServiceCollection services,
            SportingStatisticsFooteballApiAdapterConfiguration
            sportingStatisticsFooteballApiAdapterConfiguration)
        { 
            if(services is null) 
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (sportingStatisticsFooteballApiAdapterConfiguration is null)
            {
                throw new ArgumentNullException(
                    nameof(sportingStatisticsFooteballApiAdapterConfiguration));
            }

            // Registra a instancia do objeto de configurações desta chamada.
            services.AddSingleton(sportingStatisticsFooteballApiAdapterConfiguration);

            // Configura os parametros para chamada no Footeball Api
            services.AddScoped(serviceProvider => 
            {

                var httpClientFactory = serviceProvider
                    .GetService<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateHttpClient();
                httpClient.DefaultRequestHeaders.Add("x-rapidapi-key",
                    sportingStatisticsFooteballApiAdapterConfiguration.RapidApiKey);
                httpClient.DefaultRequestHeaders.Add("x-rapidapi-host",
                    sportingStatisticsFooteballApiAdapterConfiguration.HostRapidApi);

                httpClient.BaseAddress =
                    new Uri(sportingStatisticsFooteballApiAdapterConfiguration.FooteballApiUrlBase);

                return RestService.For<IFooteballApi>(httpClient);
            });

            services.AddScoped<ISportingStatisticsFooteballApiAdapter, SportingStatisticsFooteballApiAdapter>();
            return services;
        }
    }
}
