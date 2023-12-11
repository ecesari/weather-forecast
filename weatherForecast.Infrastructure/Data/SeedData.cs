using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Infrastructure.Data
{
    public class SeedData
    {
        private const int NoForecasts = 20;

        private readonly ApplicationDbContext _context;

        public SeedData(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.WeatherSummaries.Count() == 0)
            {
                var summaries = CreateSummaries();
                _context.WeatherSummaries.AddRange(summaries);

                var forecasts = CreateForecasts(summaries);
                _context.WeatherForecasts.AddRange(forecasts);

                _context.SaveChanges();
            }

        }

        private static List<Summary> CreateSummaries()
        {
            List<Summary> summaries =
            [
                new Summary { Description = "Freezing", MinTemperatureValue = -60, MaxTemperatureValue = -40 },
                new Summary { Description = "Bracing", MinTemperatureValue = -40, MaxTemperatureValue = -20 },
                new Summary { Description = "Cool", MinTemperatureValue = -20, MaxTemperatureValue = -10 },
                new Summary { Description = "Mild", MinTemperatureValue = -10, MaxTemperatureValue = 0 },
                new Summary { Description = "Warm", MinTemperatureValue = 0, MaxTemperatureValue = 10 },
                new Summary { Description = "Balmy", MinTemperatureValue = 10, MaxTemperatureValue = 20 },
                new Summary { Description = "Hot", MinTemperatureValue = 20, MaxTemperatureValue = 30 },
                new Summary { Description = "Sweltering", MinTemperatureValue = 30, MaxTemperatureValue = 40 },
                new Summary { Description = "Scorching", MinTemperatureValue = 40, MaxTemperatureValue = 50 },
                new Summary { Description = "Bracing", MinTemperatureValue = 50, MaxTemperatureValue = 60 },
            ];

            return summaries;
        }

        private static List<Forecast> CreateForecasts(List<Summary> summaries)
        {
            var todaysDate = DateOnly.FromDateTime(DateTime.Now);
            var forecasts = new List<Forecast>();
            var random = new Random();

            for (int i = -10; i < summaries.Count; i++)
            {
                forecasts.Add(new Forecast()
                {
                    Summary = $"Description {i + 11}",
                    Temperature = random.Next(-60, 60),
                    Date = todaysDate.AddDays(i),
                });
            }

            return forecasts;
        }
    }
}