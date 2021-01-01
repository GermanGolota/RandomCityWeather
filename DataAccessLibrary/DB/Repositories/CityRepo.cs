using DataAccessLibrary.DB.Entity;
using DataAccessLibrary.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLibrary.DB.Repositories
{
    public class CityRepo : ICityRepo
    {
        private readonly CityContext _context;

        public CityRepo(CityContext context)
        {
            this._context = context;
        }
        public List<City> GetRandomCities(int count)
        {
            List<City> cities = _context.Cities.OrderByRandom().Take(count).ToList();
            return cities;
        }

        public City GetRandomCity()
        {
            City city = _context.Cities.OrderByRandom().Take(1).First();
            return city;
        }
    }
}
