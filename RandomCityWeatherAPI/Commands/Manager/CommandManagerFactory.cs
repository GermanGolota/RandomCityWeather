using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace RandomCityWeatherAPI.Commands
{
    public class CommandManagerFactory : ICommandManagerFactory
    {
        private readonly ICommandsGetter _parser;
        private readonly ITelegramBotClient _client;

        public CommandManagerFactory(ICommandsGetter parser, ITelegramBotClient client)
        {
            this._parser = parser;
            this._client = client;
        }
        public async Task<ICommandManager> CreateCommandManager()
        {
            List<ICommand> commands = await _parser.GetCommands();
            CommandManager manager = new(_client, commands);
            return manager;
        }
    }
}
