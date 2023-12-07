using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Repository;
using WeatherForecast.Infrastructure.Data;
using WeatherForecast.Infrastructure.Repository.Base;

namespace WeatherForecast.Infrastructure.Repository
{
    public class ForecastRepository : BaseRepository<Forecast>, IWeatherForecastRepository
    {
        public ForecastRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
