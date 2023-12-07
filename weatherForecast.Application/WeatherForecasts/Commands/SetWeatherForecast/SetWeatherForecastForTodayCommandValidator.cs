using FluentValidation;
using WeatherForecast.Application.Clients.Commands.SetWeatherForecastCommand;

namespace WeatherForecast.Application.WeatherForecasts.Commands.SetWeatherForecast
{
    public class SetWeatherForecastCommandValidator : AbstractValidator<SetWeatherForecastCommand>
    {
        public SetWeatherForecastCommandValidator()
        {
            RuleFor(v => v.Temperature).GreaterThanOrEqualTo(-60).WithMessage("Temperature cannot be lower than -60 degrees C");
            RuleFor(v => v.Temperature).LessThanOrEqualTo(60).WithMessage("Temperature cannot be higher than 60 degrees C");
            RuleFor(v => v.Date).GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now)).When(v => v.Date.HasValue).WithMessage("Date cannot be in the past");
        }
    }
}
