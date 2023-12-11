using WeatherForecast.Domain.SeedWork;

namespace WeatherForecast.Domain.Entities
{
    public class Summary : BaseEntity
    {
        public int MinTemperatureValue { get; set; }
        public int MaxTemperatureValue { get; set; }
        public string Description { get; set; }
    }
}
