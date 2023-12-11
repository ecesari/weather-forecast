using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.SeedWork;

namespace WeatherForecast.Domain.Repository
{
    public interface IForecastRepository : IBaseRepository<Forecast>
    {
        List<Forecast> GetBetweenDates(DateOnly startDate, DateOnly endDate);
        bool ForecastExistsForDate(DateOnly date);
    }
}
