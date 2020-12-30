using DataAccessLibrary.Data.API;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomCityWeatherAPI.Extensions
{
    public static class ExternalAPIExtensions
    {
        public static IServiceCollection AddWeatherAPI(this IServiceCollection services)
        {
            services.AddScoped<APIClient>();

            services.AddScoped<APIConnection>();

            services.AddScoped<IAPIManager>(x =>
            { 
                var config = x.GetService<IConfiguration>();
                return APIManager.Create(x.GetService<APIConnection>(), config.GetValue<string>("APIKey"));
            });
            return services;
        }
    }
}
