using System.Threading.Tasks;

namespace RandomCityWeatherAPI.Commands
{
    public interface ICommandManagerFactory
    {
        Task<ICommandManager> CreateCommandManager();
    }
}