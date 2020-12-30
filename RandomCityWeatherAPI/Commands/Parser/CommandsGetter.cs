using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomCityWeatherAPI.Commands
{
    public class CommandsGetter : ICommandsGetter
    {
        private readonly WeatherCommand _weatherCommand;

        public CommandsGetter(WeatherCommand weatherCommand)
        {
            this._weatherCommand = weatherCommand;
        }
        public async Task<List<ICommand>> GetCommands()
        {
            var commands =  new List<ICommand>();
            commands.Add(_weatherCommand);
            return commands;
        }
    }
}