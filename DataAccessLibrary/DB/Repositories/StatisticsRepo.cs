using DataAccessLibrary.DB.Entities;
using DataAccessLibrary.DB.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DB.Repositories
{
    public class StatisticsRepo : IStatisticsRepo
    {
        private readonly CityContext _context;

        public StatisticsRepo(CityContext context)
        {
            this._context = context;
        }

        public async Task AddStatistics(City city, string chatId)
        {
            var statistics = new CityStatistics
            {
                ChatId = chatId,
                City = city,
                CityId = city.Id,
                Id = new Guid().ToString()
            };

            await _context.Statistics.AddAsync(statistics);
        }

        public async Task<Dictionary<string, int>> GetStatisticsFromChatId(string chatId)
        {
            List<string> cities = await _context.Statistics.Where(x => x.ChatId == chatId).Select(x => x.CityId).ToListAsync();
            var output = new Dictionary<string, int>();
            foreach (string city in cities)
            {
                if(output.ContainsKey(city))
                {
                    output[city]++;
                }
                else
                {
                    output.Add(city, 1);
                }
            }
            return output;
        }
    }
}
