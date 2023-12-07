using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Domain.Repository
{
    public interface IWeatherSummaryRepository : IBaseRepository<WeatherSummary>
    {
        WeatherSummary? GetByTemperature(int temperature);
    }
}
