using AutoMapper;
using WeatherForecast.Domain.Repository;
using MediatR;
using WeatherForecast.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace WeatherForecast.Application.WeatherForecast.Queries.GetWeatherForecasts
{
    public class GetWeatherForecastsQuery : IRequest<List<WeatherForecastResponse>>
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }

    public class GetWeatherForecastsQueryHandler : IRequestHandler<GetWeatherForecastsQuery, List<WeatherForecastResponse>>
    {
        private readonly IForecastRepository repository;
        private readonly IMapper mapper;
        public GetWeatherForecastsQueryHandler(IForecastRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<WeatherForecastResponse>> Handle(GetWeatherForecastsQuery request, CancellationToken cancellationToken)
        {
            var forecasts = repository.GetBetweenDates(request.StartDate, request.EndDate);
            var list = mapper.Map<List<WeatherForecastResponse>>(forecasts);
            return list;
        }
    }
}
