using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Repository;
using WeatherForecast.Infrastructure.Data;
using WeatherForecast.Infrastructure.Repository.Base;

namespace WeatherForecast.Infrastructure.Repository
{
    public class SummaryRepository : BaseRepository<Summary>, ISummaryRepository
    {
        public SummaryRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
        }

        public Summary? GetByTemperature(int temperature)
        {
            var summary = applicationDb.WeatherSummaries.Where(x=> x.MaxTemperatureValue >= temperature &&  x.MinTemperatureValue <= temperature).FirstOrDefault();
            return summary;
        }
    }
}
