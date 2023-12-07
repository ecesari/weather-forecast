namespace WeatherForecast.Api.Models
{
    public class SetWeatherForecastModel
    {
        public int Temperature { get; set; }
        public DateOnly Date { get; set; }
    }
}
