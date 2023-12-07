using WeatherForecast.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WeatherForecast.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Domain.Entities.Forecast> WeatherForecasts { get; set; }
        public DbSet<WeatherSummary> WeatherSummaries { get; set; }
    }
}
