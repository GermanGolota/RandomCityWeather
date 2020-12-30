using DataAccessLibrary.Data.API;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomCityWeatherAPI.Controllers
{
    [ApiController]
    [Route("api/weather/")]
    public class WeatherController:ControllerBase
    {
        private readonly IAPIManager _manager;

        public WeatherController(IAPIManager manager)
        {
            this._manager = manager;
        }
        [HttpGet("{cityId}")]
        public async Task<ActionResult<WeatherModel>> GetWeatherByCityId(string cityId)
        {
            var model = await _manager.GetWeatherModelByIdAsync(cityId);
            return Ok(model);
        }
    }
}
