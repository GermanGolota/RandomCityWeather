using Microsoft.Extensions.DependencyInjection;
using RandomCityWeatherAPI.Commands.NonStandardCommands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomCityWeatherAPI.Commands
{
    public class CommandsGetter : ICommandsGetter
    {
        private readonly WeatherCommand _weatherCommand;
        private readonly WeatherScheduleSetupCommand _schedule;

        public CommandsGetter(WeatherCommand weatherCommand, WeatherScheduleSetupCommand schedule)
        {
            this._weatherCommand = weatherCommand;
            this._schedule = schedule;
        }
        public async Task<List<ICommand>> GetCommands()
        {
            var commands =  new List<ICommand>();
            commands.Add(_weatherCommand);
            commands.Add(_schedule);
            return commands;
        }
    }
}