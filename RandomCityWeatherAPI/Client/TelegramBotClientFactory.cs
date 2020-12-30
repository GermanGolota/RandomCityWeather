using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace RandomCityWeatherAPI.Client
{
    public class TelegramBotClientFactory : ITelegramBotClientFactory
    {
        public async Task<ITelegramBotClient> CreateClient(string token, string webhookUrl)
        {
            var client = new TelegramBotClient(token);

            await client.SetWebhookAsync(webhookUrl);

            return client;
        }
    }
}
