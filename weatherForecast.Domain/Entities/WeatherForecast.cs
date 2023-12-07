namespace WeatherForecast.Domain.Entities
{
    public class Forecast : BaseEntity
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public required string Summary { get; set; }
    }
}
