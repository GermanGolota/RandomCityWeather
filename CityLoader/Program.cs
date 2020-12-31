using DataAccessLibrary.DB;
using DataAccessLibrary.DB.Entity;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CityLoader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ServiceCollection services = new();

            services.AddDbContext<CityContext>(options => 
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TelegramBotDB;Integrated Security=True")
            );

            CityContext context = services.BuildServiceProvider().GetService<CityContext>();

            string CitiesFile = @"C:\Users\korov\Desktop\city.list.json";

            List<CityModel> cities = new List<CityModel>();

            using (FileStream file = new FileStream(CitiesFile, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string json = sr.ReadToEnd();

                    cities = JsonConvert.DeserializeObject<List<CityModel>>(json);
                }
            }

            int before = cities.Count;
            cities = cities.Where(x => !String.IsNullOrEmpty(x.Name) && !String.IsNullOrEmpty(x.Country)).ToList();
            int after = cities.Count;
            Console.WriteLine(before-after);

            List<City> dbcities = new List<City>();

            foreach (var cityModel in cities)
            {
                City city = new City
                {
                    Country = cityModel.Country,
                    Name = cityModel.Name,
                    Id = cityModel.Id.ToString(),
                    Latitude = cityModel.Coord.lat,
                    Longitude = cityModel.Coord.lon
                };
                dbcities.Add(city);
            }

            await context.AddRangeAsync(dbcities);

            context.SaveChanges();
        }
    }
}
