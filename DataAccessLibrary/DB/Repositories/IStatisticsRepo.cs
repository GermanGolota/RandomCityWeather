using DataAccessLibrary.DB.Entities;
using DataAccessLibrary.DB.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DB.Repositories
{
    public interface IStatisticsRepo
    {
        Task AddStatistics(City city, string chatId);
        Task<Dictionary<string, int>> GetStatisticsFromChatId(string chatId);
    }
}
