using DataAccessLibrary.DB.Entity;
using DataAccessLibrary.Extensions;
using Microsoft.EntityFrameworkCore;
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
            List<City> cities = _context.Cities.AsNoTracking().OrderByRandom().Take(count).ToList();
            return cities;
        }

        public City GetRandomCity()
        {
            City city = _context.Cities.AsNoTracking().OrderByRandom().Take(1).First();
            return city;
        }
    }
}
