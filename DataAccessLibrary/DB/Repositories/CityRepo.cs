using DataAccessLibrary.DB.Entities;
using DataAccessLibrary.DB.Entity;
using DataAccessLibrary.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DB.Repositories
{
    public class CityRepo : ICityRepo
    {
        private readonly CityContext _context;

        public CityRepo(CityContext context)
        {
            this._context = context;
        }
        public async Task<List<City>> GetRandomCities(int count)
        {
            List<City> cities = await _context.Cities.AsNoTracking().OrderByRandom().Take(count).ToListAsync();
            return cities;
        }

        public async Task<City> GetRandomCity()
        {
            City city = await _context.Cities.AsNoTracking().OrderByRandom().Take(1).FirstAsync();
            return city;
        }
        public async Task AddStatistics(string cityId, string chatId)
        {
            var statistics = new CityStatistics
            {
                ChatId = chatId,
                CityId = cityId,
                Id = new Guid().ToString()
            };

            var city = await _context.Cities.Include(x=>x.Statistics).FirstAsync(x => x.Id == cityId);

            city.Statistics = city.Statistics.Concat(new[] { statistics });

            await _context.Statistics.AddAsync(statistics);
        }

        public async Task<Dictionary<string, int>> GetStatisticsFromChatId(string chatId)
        {
            List<string> cities = await _context.Statistics.Where(x => x.ChatId == chatId).Select(x => x.CityId).ToListAsync();
            var output = new Dictionary<string, int>();
            foreach (string city in cities)
            {
                if (output.ContainsKey(city))
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
