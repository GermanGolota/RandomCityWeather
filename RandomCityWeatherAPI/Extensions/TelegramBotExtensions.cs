using Microsoft.Extensions.DependencyInjection;
using RandomCityWeatherAPI.Client;
using RandomCityWeatherAPI.Commands;
using RandomCityWeatherAPI.Commands.NonStandardCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace RandomCityWeatherAPI.Extensions
{
    public static class TelegramBotExtensions
    {
        public static IServiceCollection AddTelegramBot(this IServiceCollection services, string token, string webhookurl)
        {

            services.AddScoped<ITelegramBotClientFactory, TelegramBotClientFactory>();
            services.AddScoped<ITelegramBotClient>((x) =>
            {
                var factory = x.GetService<ITelegramBotClientFactory>();
                //BAD
                return factory.CreateClient(token, webhookurl).GetAwaiter().GetResult();
            });

            services.AddScoped<ICommandsGetter, CommandsGetter>();

            services.AddScoped<ICommandManagerFactory, CommandManagerFactory>();
            //BAD
            services.AddScoped<ICommandManager>(x => x.GetService<ICommandManagerFactory>().CreateCommandManager().GetAwaiter().GetResult());

            return services;
        }
        public static IServiceCollection AddTelegramCommands(this IServiceCollection services)
        {
            services.AddScoped<WeatherCommand>();
            services.AddScoped<WeatherScheduleSetupCommand>();
            return services;
        }
    }
}
