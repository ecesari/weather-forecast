using weatherForecast.Domain.Entities;

namespace weatherForecast.Domain.Repository
{
    public interface IWeatherForecastRepository : IBaseRepository<WeatherForecast>
    {
    }
}
