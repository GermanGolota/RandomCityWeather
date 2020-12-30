using Microsoft.Extensions.DependencyInjection;
using RandomCityWeatherAPI.Client;
using RandomCityWeatherAPI.Commands;
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

            services.AddSingleton<ITelegramBotClientFactory, TelegramBotClientFactory>();
            services.AddSingleton<ITelegramBotClient>((x) =>
            {
                var factory = x.GetService<ITelegramBotClientFactory>();
                //BAD
                return factory.CreateClient(token, webhookurl).GetAwaiter().GetResult();
            });

            services.AddSingleton<ICommandsGetter, CommandsGetter>();

            services.AddSingleton<ICommandManagerFactory, CommandManagerFactory>();
            //BAD
            services.AddSingleton<ICommandManager>(x => x.GetService<ICommandManagerFactory>().CreateCommandManager().GetAwaiter().GetResult());

            return services;
        }
    }
}
