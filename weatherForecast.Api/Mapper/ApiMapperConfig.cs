using AutoMapper;
using WeatherForecast.Api.Models;
using WeatherForecast.Application.Clients.Commands.SetWeatherForecastCommand;

namespace WeatherForecast.Api.Mapper
{
    public class ApiMapperConfig : Profile
    {
        public ApiMapperConfig()
        {
            CreateMap<SetWeatherForecastModel, SetWeatherForecastCommand>();
            CreateMap<int, SetWeatherForecastCommand>()
                .ForMember(response => response.Temperature, opt => opt.MapFrom(src => src))
                .ForMember(response => response.Date, opt => opt.MapFrom(src => DateOnly.MaxValue));
        }
    }
}
