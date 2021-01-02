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
                string[] parameters = GetCommandParameters(message);
                await command.Execute(message, _client, parameters);
            }
            else
            {
                //log
            }
        }
        private string[] GetCommandParameters(Message message)
        {
            string commandMessage = message.Text;

            int endIndex = commandMessage.IndexOf(' ');

            if (endIndex != -1)
            {
                string parameters = commandMessage.Substring(endIndex + 1);
                return parameters.Split(' ');
            }
            else
            {
                return new string[0];
            }

        }
        private ICommand GetRequiredCommand(Message message)
        {
            string commandMessage = message.Text;
            if (commandMessage.Contains("/"))
            {
                var standardCommand = GetStandardCommand(commandMessage);
                return standardCommand;
            }
            else
            {
                var nonStandardCommand = GetNonStandardCommand(commandMessage);
                return nonStandardCommand;
            }
        }
        private ICommand GetStandardCommand(string commandMessage)
        {
            int endIndex = commandMessage.IndexOf(' ');


            string firstWord = GetFirstWordOfCommand(commandMessage);

            firstWord = firstWord.Replace("/", "");

            var standardCommands = _commands.Where(x => x is IStandardCommand);

            var command = GetCommandWithMatchingFirstWord(standardCommands, firstWord);

            return command;
        }
        
        private ICommand GetNonStandardCommand(string commandMessage)
        {
            var nonStandardCommand = _commands.Where(x => x is INonStandardCommand);

            string firstWord = GetFirstWordOfCommand(commandMessage);

            var command = GetCommandWithMatchingFirstWord(nonStandardCommand, firstWord);

            return command;
        }
        private ICommand GetCommandWithMatchingFirstWord(IEnumerable<ICommand> commands, string firstWord)
        {
            foreach (var command in commands)
            {
                if (command.Name.Equals(firstWord))
                {
                    return command;
                }
            }
            return null;
        }
        private string GetFirstWordOfCommand(string command)
        {
            int endIndex = command.IndexOf(' ');

            if (endIndex != -1)
            {
                command = command.Substring(0, endIndex);
            }

            return command;
        }
    }
}
