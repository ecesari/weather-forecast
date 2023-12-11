using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.SeedWork;

namespace WeatherForecast.Domain.Repository
{
    public interface ISummaryRepository : IBaseRepository<Summary>
    {
        Summary? GetByTemperature(int temperature);
    }
}
