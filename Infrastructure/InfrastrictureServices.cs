using System;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Core.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure
{

    public static class InfrastrictureServices
    {
        /// <summary>
        /// configures Application layer services.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IQuoteRepository, QuoteRepository>();
            services.AddScoped<IAchieveRepository, AchieveRepository>();

            return services;
        }
    }
}

