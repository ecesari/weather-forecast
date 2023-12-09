using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Infrastructure.Data
{
    public class SeedData
    {
        private readonly ApplicationDbContext _context;

        public SeedData(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.WeatherSummaries == null)
            {
                var summaries = CreateSummaries();
                _context.WeatherSummaries.AddRange(summaries);

                _context.SaveChanges();
            }

        }

        private static List<WeatherSummary> CreateSummaries()
        {
            List<WeatherSummary> summaries =
            [
                new WeatherSummary { Description = "Freezing", MinTemperatureValue = -60, MaxTemperatureValue = -40 },
                new WeatherSummary { Description = "Bracing", MinTemperatureValue = -40, MaxTemperatureValue = -20 },
                new WeatherSummary { Description = "Cool", MinTemperatureValue = -20, MaxTemperatureValue = -10 },
                new WeatherSummary { Description = "Mild", MinTemperatureValue = -10, MaxTemperatureValue = 0 },
                new WeatherSummary { Description = "Warm", MinTemperatureValue = 0, MaxTemperatureValue = 10 },
                new WeatherSummary { Description = "Balmy", MinTemperatureValue = 10, MaxTemperatureValue = 20 },
                new WeatherSummary { Description = "Hot", MinTemperatureValue = 20, MaxTemperatureValue = 30 },
                new WeatherSummary { Description = "Sweltering", MinTemperatureValue = 30, MaxTemperatureValue = 40 },
                new WeatherSummary { Description = "Scorching", MinTemperatureValue = 40, MaxTemperatureValue = 50 },
                new WeatherSummary { Description = "Bracing", MinTemperatureValue = 50, MaxTemperatureValue = 60 },
            ];

            return summaries;
        }
    }
}