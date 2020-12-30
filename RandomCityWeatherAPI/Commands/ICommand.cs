using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot;

namespace RandomCityWeatherAPI.Commands
{
    public interface ICommand
    {
        public string Name { get; }
        public Task Execute(Message message, ITelegramBotClient client);
    }
}
