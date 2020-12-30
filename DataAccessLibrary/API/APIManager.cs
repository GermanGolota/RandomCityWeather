using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.API
{
    public class APIManager : IAPIManager
    {
        private readonly APIConnection _api;
        private string apiKey;

        public static APIManager Create(APIConnection connection, string ApiKey)
        {
            return new APIManager(connection, ApiKey);
        }

        private APIManager(APIConnection apimanager, string ApiKey)
        {
            this._api = apimanager;
            this.apiKey = ApiKey;
        }
        public async Task<WeatherModel> GetWeatherModelByIdAsync(string cityId)
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?id={cityId}&appid={apiKey}&units=metric";

            WeatherModel weather = await _api.GenericAPICall<WeatherModel>(url);

            return weather;
        }
    }
}
