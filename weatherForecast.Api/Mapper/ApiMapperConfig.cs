using AutoMapper;
using WeatherForecast.Api.Models;
using WeatherForecast.Application.Clients.Commands.SetWeatherForecastCommand;
using WeatherForecast.Application.WeatherForecast.Queries.GetWeatherForecasts;
using WeatherForecast.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace WeatherForecast.Api.Mapper
{
    public class ApiMapperConfig : Profile
    {
        public ApiMapperConfig()
        {
            CreateMap<SetWeatherForecastModel, SetWeatherForecastCommand>()
                .ForMember(response => response.Date, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.Date)));            
            CreateMap<int, SetWeatherForecastCommand>()
                .ForMember(response => response.Temperature, opt => opt.MapFrom(src => src))
                .ForMember(response => response.Date, opt => opt.MapFrom(src => DateOnly.MaxValue));
            //CreateMap<GetWeatherForecastModel, GetWeatherForecastsQuery>()
            //    .ForMember(response => response.StartDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.StartDate)))
            //    .ForMember(response => response.EndDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.EndDate)));
            CreateMap<WeatherForecastResponse, DailyWeatherForecastModel>()
                .ForMember(response => response.Date, opt => opt.MapFrom(src => src.Date.ToString("D")))
                .ForMember(response => response.Description, opt => opt.MapFrom(src => src.Summary));            
        }
    }
}
