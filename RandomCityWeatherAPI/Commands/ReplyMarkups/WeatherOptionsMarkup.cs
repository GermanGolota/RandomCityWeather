using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace RandomCityWeatherAPI.Commands.ReplyMarkups
{
    public class WeatherOptionsMarkup : ReplyKeyboardMarkup
    {
        public WeatherOptionsMarkup()
        {
            KeyboardButton buttonNow = new ("Weather NOW");
            KeyboardButton buttonDaily = new ("Weather Schedule Daily");
            KeyboardButton buttonWeekly = new("Weather Schedule Weekly");
            KeyboardButton buttonMonthly = new("Weather Schedule Monthly");

            List<KeyboardButton> firstRow = new(){ buttonNow, buttonDaily};
            List<KeyboardButton> secondRow = new() {buttonWeekly, buttonMonthly };
            List<List<KeyboardButton>> keyboard = new() { firstRow, secondRow };
            this.Keyboard = keyboard;
        }
    }
}
