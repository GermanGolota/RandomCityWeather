using DataAccessLibrary.DB.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.DB.Repositories
{
    public interface ICityRepo
    {
        City GetRandomCity();
        List<City> GetRandomCities(int count);
    }
}
