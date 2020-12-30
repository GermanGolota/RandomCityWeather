using DataAccessLibrary.DB.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.DB
{
    public class CityContext:DbContext
    {
        public CityContext(DbContextOptions<CityContext> options):base(options)
        {

        }
        public DbSet<City> Cities { get; set; }
    }
}
