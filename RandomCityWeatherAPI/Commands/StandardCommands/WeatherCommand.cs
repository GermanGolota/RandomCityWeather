using DataAccessLibrary.Data.API;
using DataAccessLibrary.DB.Entity;
using DataAccessLibrary.DB.Repositories;
using DataAccessLibrary.Models;
using RandomCityWeatherAPI.Commands.ReplyMarkups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot;

namespace RandomCityWeatherAPI.Commands
{
    public class WeatherCommand : IStandardCommand
    {
        public string Name { get; } = "Weather";

        public async Task Execute(Message message, ITelegramBotClient client, string[] parameters)
        {
            var chatId = message.Chat.ID;
            var messageId = message.MessageID;
            string reply = "Select corresponding schedule";
            WeatherOptionsMarkup markup = new WeatherOptionsMarkup();
            await client.SendTextMessageAsync(chatId,reply, replyToMessageId:messageId, replyMarkup: markup);
        }

    }
}
