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
            List<City> cities = _context.Cities.AsNoTracking().OrderByRandom().Take(count).ToList();
            return cities;
        }

        public async Task<City> GetRandomCity()
        {
            City city = await _context.Cities.AsNoTracking().OrderByRandom().Take(1).FirstAsync();
            return city;
        }
    }
}
