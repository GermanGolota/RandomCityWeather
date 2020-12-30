using System.Threading.Tasks;
using TelegramBot;

namespace RandomCityWeatherAPI.Commands
{
    public interface ICommandManager
    {
        Task ProcessMessage(Message message);
    }
}