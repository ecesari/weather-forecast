using MediatR;
using WeatherForecast.Application.Common.Exceptions;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Repository;

namespace WeatherForecast.Application.Clients.Commands.SetWeatherForecastCommand
{
    public class SetWeatherForecastCommand : IRequest<Guid>
    {
        public int Temperature { get; set; }
        public DateOnly? Date { get; set; }
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

        public async Task<Guid> Handle(SetWeatherForecastCommand command, CancellationToken cancellationToken)
        {
            var weatherSummary = weatherSummaryRepository.GetByTemperature(command.Temperature) ?? throw new EntityNotFoundException(nameof(WeatherSummary), command.Temperature);
            var date = command.Date ?? DateOnly.FromDateTime(DateTime.Now);
            var entity = new Forecast { Date = date, Temperature = command.Temperature, Summary = weatherSummary.Description };
            await repository.AddAsync(entity);
            return entity.Id;
        }
    }

}
