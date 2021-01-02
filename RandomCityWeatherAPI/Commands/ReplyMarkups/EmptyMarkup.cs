using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace RandomCityWeatherAPI.Commands.ReplyMarkups
{
    public class EmptyMarkup : ReplyKeyboardMarkup
    {
        public EmptyMarkup()
        {
            this.Keyboard = new List<List<KeyboardButton>>();
        }
    }
}
