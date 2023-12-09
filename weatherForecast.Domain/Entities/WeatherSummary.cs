namespace WeatherForecast.Domain.Entities
{
    public class WeatherSummary : BaseEntity
    {
        public int MinTemperatureValue { get; set; }
        public int MaxTemperatureValue { get; set; }
        public string Description { get; set; }
    }
}
