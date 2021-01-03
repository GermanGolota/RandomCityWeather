﻿using DataAccessLibrary.Data.API;
using DataAccessLibrary.DB.Entities;
using DataAccessLibrary.DB.Entity;
using DataAccessLibrary.DB.Repositories;
using DataAccessLibrary.Models;
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
        private readonly ICityRepo _repo;
        private readonly IStatisticsRepo _stats;

        public WeatherCommand(IAPIManager manager, ICityRepo repo, IStatisticsRepo stats)
        {
            this._manager = manager;
            this._repo = repo;
            this._stats = stats;
        }
        public string Name { get; } = "Weather";

        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.ID;
            var messageId = message.MessageID;
            City city = await _repo.GetRandomCity();
            WeatherResponceModel APIReply = await _manager.GetWeatherModelByIdAsync(city.Id);

            await _stats.AddStatistics(city, chatId.ToString());

            string reply = CreateMessageFromWeather(APIReply);
            await client.SendTextMessageAsync(chatId,reply, replyToMessageId:messageId);
        }
        private string CreateMessageFromWeather(WeatherResponceModel weather)
        {
            double temp = weather.Main.Temp;
            double feelsLike = weather.Main.Feels_Like;
            string name = weather.Name;

            string output = $"City:{name}: Temparature = {temp}";
            string feelsLikeString =", feels like " + feelsLike.ToString();
            string addition = String.IsNullOrEmpty(feelsLikeString) ? "" : feelsLikeString;
            output += addition;
            return output;
        }

    }
}
