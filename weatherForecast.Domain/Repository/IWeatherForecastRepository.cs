using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Domain.Repository
{
    public interface IWeatherForecastRepository : IBaseRepository<Forecast>
    {
        List<Forecast> GetBetweenDates(DateOnly startDate, DateOnly endDate);
    }
}
