namespace WeatherForecast.Domain.Entities
{
    public class Forecast : BaseEntity
    {
        public DateOnly Date { get; set; }

        public int Temperature { get; set; }

        public string Summary { get; set; }
    }
}
