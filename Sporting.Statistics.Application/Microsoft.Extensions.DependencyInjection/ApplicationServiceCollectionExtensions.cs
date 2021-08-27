using Microsoft.Extensions.DependencyInjection;
using Sporting.Statistics.Domain.Service;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Sporting.Statistics.Application.Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddScoped<ISportingStatisticsServices, SportingStatisticsServices>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ILeagueService, LeagueService>();

            return services;
        }
    }
}
