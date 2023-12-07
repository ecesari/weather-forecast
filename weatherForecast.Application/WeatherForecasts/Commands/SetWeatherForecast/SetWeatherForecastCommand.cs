using MediatR;
using WeatherForecast.Application.Common.Exceptions;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Repository;

namespace WeatherForecast.Application.Clients.Commands.SetWeatherForecastCommand
{
    public class SetWeatherForecastCommand : IRequest<Guid>
    {
        public int Temperature { get; set; }
    }

    public class SetWeatherForecastCommandHandler : IRequestHandler<SetWeatherForecastCommand, Guid>
    {
        private readonly IWeatherForecastRepository repository;
        private readonly IWeatherSummaryRepository weatherSummaryRepository;

        public SetWeatherForecastCommandHandler(IWeatherForecastRepository repository, IWeatherSummaryRepository weatherSummaryRepository)
        {
            this.repository = repository;
            this.weatherSummaryRepository = weatherSummaryRepository;
        }

        public async Task<Guid> Handle(SetWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            var weatherSummary = weatherSummaryRepository.GetByTemperature(request.Temperature) ?? throw new EntityNotFoundException(nameof(WeatherSummary), request.Temperature);
            var entity = new Forecast { Date = DateOnly.FromDateTime(DateTime.Now), TemperatureC = request.Temperature, Summary = weatherSummary.Description };
            await repository.AddAsync(entity);
            return entity.Id;
        }
    }

}
 