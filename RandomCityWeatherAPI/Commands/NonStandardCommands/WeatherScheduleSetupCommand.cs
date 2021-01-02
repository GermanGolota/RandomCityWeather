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

namespace RandomCityWeatherAPI.Commands.NonStandardCommands
{
    public class WeatherScheduleSetupCommand : INonStandardCommand
    {

        private readonly IAPIManager _manager;
        private readonly ICityRepo _repo;
        public WeatherScheduleSetupCommand(IAPIManager manager, ICityRepo repo)
        {
            _manager = manager;
            _repo = repo;
        }
        public string Name { get; } = "Weather";
        public async Task Execute(Message message, ITelegramBotClient client, string[] parameters)
        {
            var chatId = message.Chat.ID;
            var messageId = message.MessageID;

            EmptyMarkup markup = new EmptyMarkup();

            if (parameters.Length==0)
            {
                await client.SendTextMessageAsync(chatId, "Please provide some paramethers");
            }
            else
            {
                string scheduleType = parameters[0];
                switch (scheduleType)
                {
                    case "NOW":
                        City city = _repo.GetRandomCity();
                        WeatherResponceModel APIReply = await _manager.GetWeatherModelByIdAsync(city.Id);
                        string reply = CreateMessageFromWeather(APIReply);
                        await client.SendTextMessageAsync(chatId, reply, replyToMessageId: messageId, replyMarkup: markup);
                        break;
                    case "Schedule":
                        //create reocurring job
                        break;
                }
            }
        }
        private string CreateMessageFromWeather(WeatherResponceModel weather)
        {
            double temp = weather.Main.Temp;
            double feelsLike = weather.Main.Feels_Like;
            string name = weather.Name;

            string output = $"City:{name}: Temparature = {temp}";
            string feelsLikeString = ", feels like " + feelsLike.ToString();
            string addition = String.IsNullOrEmpty(feelsLikeString) ? "" : feelsLikeString;
            output += addition;
            return output;
        }
    }
}
