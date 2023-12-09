using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Forecast> WeatherForecasts { get; set; }
        public DbSet<WeatherSummary> WeatherSummaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Forecast>().HasKey(forecast => forecast.Id);
            modelBuilder.Entity<WeatherSummary>().HasKey(s => s.Id);
        }
    }
}
