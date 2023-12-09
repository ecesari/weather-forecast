namespace WeatherForecast.Api.Models
{
    public class GetWeatherForecastModel
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
