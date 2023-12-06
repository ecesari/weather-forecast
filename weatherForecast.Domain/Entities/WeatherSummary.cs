namespace weatherForecast.Domain.Entities
{
    public class WeatherSummary : BaseEntity
    {
        public int MinTemperatureValue { get; set; }
        public int MaxTemperatureValue { get; set; }
        public required string Description { get; set; }
    }
}
