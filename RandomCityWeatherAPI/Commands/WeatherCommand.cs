using DataAccessLibrary.Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot;

namespace RandomCityWeatherAPI.Commands
{
    public class WeatherCommand : ICommand
    {
        private readonly IAPIManager _manager;

        public WeatherCommand(IAPIManager manager)
        {
            this._manager = manager;
        }
        public string Name { get; } = "Weather";

        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.ID;
            var messageId = message.MessageID;
            string messageText = message.Text;
            var reply = await _manager.GetWeatherModelByIdAsync("4166787");
            await client.SendTextMessageAsync(chatId,reply.Name, replyToMessageId:messageId);
        }
    }
}
