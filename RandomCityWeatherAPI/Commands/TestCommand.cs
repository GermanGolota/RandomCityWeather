using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot;

namespace RandomCityWeatherAPI.Commands
{
    public class TestCommand : ICommand
    {
        public string Name { get; set; } = "Test";

        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.ID;
            var messageId = message.MessageID;
            await client.SendTextMessageAsync(chatId,"test", replyToMessageId: messageId);
        }
    }
}
