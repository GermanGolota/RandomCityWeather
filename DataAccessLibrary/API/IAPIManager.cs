using DataAccessLibrary.Models;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.API
{
    public interface IAPIManager
    {
        Task<WeatherModel> GetWeatherModelByIdAsync(string cityId);
    }
}