using AutoMapper;
using WeatherForecast.Api.Models;
using WeatherForecast.Application.Clients.Commands.SetWeatherForecastCommand;

namespace WeatherForecast.Infrastructure.Mapper
{
    public class InfrastructureMapperConfig : Profile
    {
        public InfrastructureMapperConfig()
        {
            CreateMap<SetWeatherForecastModel, SetWeatherForecastCommand>();
            CreateMap<int, SetWeatherForecastCommand>()
                .ForMember(response => response.Temperature, opt => opt.MapFrom(src => src));
        }
    }
}
