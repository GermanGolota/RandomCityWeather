using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomCityWeatherAPI.Commands
{
    public interface ICommandsGetter
    {
        Task<List<ICommand>> GetCommands();
    }
}