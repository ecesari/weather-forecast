﻿using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Repository;
using WeatherForecast.Infrastructure.Data;
using WeatherForecast.Infrastructure.Repository.Base;

namespace WeatherForecast.Infrastructure.Repository
{
    public class ForecastRepository : BaseRepository<Forecast>, IForecastRepository
    {
        public ForecastRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public List<Forecast> GetBetweenDates(DateOnly startDate, DateOnly endDate)
        {
            var forecasts = applicationDb.WeatherForecasts.Where(x => x.Date >= startDate && x.Date <= endDate).ToList();
            return forecasts;
        }

        public bool ForecastExistsForDate(DateOnly date)
        {
            var forecastExists = applicationDb.WeatherForecasts.Where(x => x.Date == date).Any();
            return forecastExists;
        }
    }
}
