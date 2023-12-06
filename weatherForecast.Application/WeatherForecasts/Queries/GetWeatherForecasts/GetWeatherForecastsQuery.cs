using AutoMapper;
using weatherForecast.Application.Clients.Queries.GetClients;
using weatherForecast.Domain.Repository;
using MediatR;

namespace weatherForecast.Application.WeatherForecast.Queries.GetWeatherForecasts
{
    public class GetWeatherForecastsQuery : IRequest<List<WeatherForecastResponse>>
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }

    public class GetWeatherForecastsQueryHandler : IRequestHandler<GetWeatherForecastsQuery, List<WeatherForecastResponse>>
    {
        private readonly IWeatherForecastRepository repository;
        private readonly IMapper mapper;
        public GetWeatherForecastsQueryHandler(IWeatherForecastRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<WeatherForecastResponse>> Handle(GetWeatherForecastsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

            var forecasts = await repository.GetAllAsync();
            var returnModel = mapper.Map<List<WeatherForecastResponse>>(forecasts);
            return returnModel;
        }
    }
}
