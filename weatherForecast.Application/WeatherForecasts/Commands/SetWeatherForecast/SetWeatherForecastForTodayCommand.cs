using FluentValidation;
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
        private readonly IForecastRepository repository;
        private readonly ISummaryRepository weatherSummaryRepository;
        private readonly IValidator<SetWeatherForecastCommand> validator;

        public SetWeatherForecastCommandHandler(IForecastRepository repository, ISummaryRepository weatherSummaryRepository, IValidator<SetWeatherForecastCommand> validator)
        {
            this.repository = repository;
            this.weatherSummaryRepository = weatherSummaryRepository;
            this.validator = validator;
        }

        public async Task<Guid> Handle(SetWeatherForecastCommand command, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(command);
            var weatherSummary = weatherSummaryRepository.GetByTemperature(command.Temperature) ?? throw new EntityNotFoundException(nameof(Summary), command.Temperature);
            var forecastAlreadyExists = command.Date.HasValue && repository.ForecastExistsForDate(command.Date.Value);
            if (forecastAlreadyExists) { throw new EntityAlreadyExistsException($"Forecast for date {command.Date} already exists."); }
            var date = command.Date ?? DateOnly.FromDateTime(DateTime.Now);
            var entity = new Forecast { Date = date, Temperature = command.Temperature, Summary = weatherSummary.Description };
            await repository.AddAsync(entity);
            return entity.Id;
        }
    }

}
