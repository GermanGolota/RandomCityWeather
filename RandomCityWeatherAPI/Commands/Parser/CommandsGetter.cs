using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomCityWeatherAPI.Commands
{
    public class CommandsGetter : ICommandsGetter
    {
        public async Task<List<ICommand>> GetCommands()
        {
            var commands =  new List<ICommand>();
            commands.Add(new TestCommand());
            return commands;
        }
    }
}