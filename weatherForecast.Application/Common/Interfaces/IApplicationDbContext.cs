using weatherForecast.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace weatherForecast.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Domain.Entities.WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<WeatherSummary> WeatherSummaries { get; set; }
    }
}
