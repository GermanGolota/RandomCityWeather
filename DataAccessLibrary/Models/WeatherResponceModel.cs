namespace DataAccessLibrary.Models
{
    public class WeatherResponceModel
    {
        public string Name { get; set; }
        public CoordinatesModel Coord { get; set; }
        public WeatherModel Main { get; set; }

    }
}