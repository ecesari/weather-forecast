using AutoMapper;
using WeatherForecast.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Application.Common.Mapper
{
    public class ApplicationMapperConfig : Profile
    {
        public ApplicationMapperConfig()
        {
            CreateMap<Forecast, WeatherForecastResponse>();
        }
    }
}
