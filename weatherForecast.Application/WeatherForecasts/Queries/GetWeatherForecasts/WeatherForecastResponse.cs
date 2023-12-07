namespace WeatherForecast.Application.WeatherForecasts.Queries.GetWeatherForecasts
{
    public class WeatherForecastResponse
    {
        public Guid Id { get; set; }
        public int Temperature { get; set; }
        public DateOnly Date { get; set; }
        public string Summary { get; set; }
    }
}
