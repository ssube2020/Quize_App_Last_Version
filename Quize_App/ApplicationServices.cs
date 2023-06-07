using System;
using System.Reflection;
using Quize_App.Contracts;
using Quize_App.Services;

namespace Quize_App
{
    public static class ApplicationServices
    {
        /// <summary>
        /// configures Application layer services.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            //profiles
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<QuoteService>();
            services.AddScoped<AchieveService>();

            return services;
        }
    }

}

