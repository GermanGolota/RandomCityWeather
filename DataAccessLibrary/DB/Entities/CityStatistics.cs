using DataAccessLibrary.DB.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.DB.Entities
{
    public class CityStatistics:EntityBase
    {
        public string CityId { get; set; }
        public string ChatId { get; set; }
    }
}
