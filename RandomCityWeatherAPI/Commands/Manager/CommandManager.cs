using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot;

namespace RandomCityWeatherAPI.Commands
{
    public class CommandManager : ICommandManager
    {
        private readonly ITelegramBotClient _client;
        private List<ICommand> _commands;
        public CommandManager(ITelegramBotClient client, List<ICommand> commands)
        {
            this._client = client;
            this._commands = commands;
        }

        async public Task ProcessMessage(Message message)
        {
            ICommand command = GetRequiredCommand(message);

            if (command is not null)
            {
                await command.Execute(message, _client);
            }
            else
            {
                //log
            }
        }

        private ICommand GetRequiredCommand(Message message)
        {
            string messageCommand = message.Text;

            int endIndex = messageCommand.IndexOf(' ');

            if (endIndex != -1)
            {
                messageCommand = messageCommand.Substring(0, endIndex);
            }

            messageCommand = messageCommand.Replace("/", "");

            foreach (var command in _commands)
            {
                if (command.Name.ToLower().Equals(messageCommand))
                {
                    return command;
                }
            }
            return null;
        }
    }
}
