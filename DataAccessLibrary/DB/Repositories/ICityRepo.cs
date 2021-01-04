using DataAccessLibrary.DB.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DB.Repositories
{
    public interface ICityRepo
    {
        Task<City> GetRandomCity();
        Task<List<City>> GetRandomCities(int count);
        Task AddStatistics(string cityId, string chatId);
        Task<Dictionary<string, int>> GetStatisticsFromChatId(string chatId);
    }
}
