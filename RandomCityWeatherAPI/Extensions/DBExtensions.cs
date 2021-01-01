using DataAccessLibrary.DB;
using DataAccessLibrary.DB.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomCityWeatherAPI.Extensions
{
    public static class DBExtensions
    {
        public static IServiceCollection AddDBDataAccess(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<CityContext>(
               options =>
               {
                   options.UseSqlServer(Configuration.GetConnectionString("Cities"),
                       b =>
                       {
                           b.MigrationsAssembly(nameof(RandomCityWeatherAPI));
                       });
               });
            services.AddScoped<ICityRepo, CityRepo>();
            return services;
        }
    }
}
