using weatherForecast.Domain.Entities;
using weatherForecast.Domain.Repository;
using weatherForecast.Infrastructure.Data;
using weatherForecast.Infrastructure.Repository.Base;

namespace weatherForecast.Infrastructure.Repository
{
    public class WeatherForecastRepository : BaseRepository<WeatherForecast>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
