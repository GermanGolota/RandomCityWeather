using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RandomCityWeatherAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using DataAccessLibrary.DB;

namespace RandomCityWeatherAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            string token = Configuration.GetValue<string>("Token");
            string webhookurl = Configuration.GetValue<string>("Webhook");

            services.AddTelegramBot(token, webhookurl);

            services.AddTelegramCommands();

            services.AddDbContext<CityContext>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("Cities"),
                        b =>
                        {
                            b.MigrationsAssembly(nameof(RandomCityWeatherAPI));
                        });
                });


            services.AddWeatherAPI();

            services.AddControllers();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
