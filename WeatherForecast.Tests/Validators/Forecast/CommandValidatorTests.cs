using FluentValidation.TestHelper;
using WeatherForecast.Application.Clients.Commands.SetWeatherForecastCommand;
using WeatherForecast.Application.WeatherForecasts.Commands.SetWeatherForecast;

namespace WeatherForecast.Tests.Validators.Forecast
{
    public class CommandValidatorTests
    {
        private readonly SetWeatherForecastCommandValidator setWeatherForecastCommandValidator;

        public CommandValidatorTests()
        {
            setWeatherForecastCommandValidator = new SetWeatherForecastCommandValidator();
        }

        [Theory]
        [InlineData(-100)]
        public async Task Given_SetForecast_When_Temperature_IsBelowThreshold_Then_Command_FailsAsync(int temperature)
        {
            // Arrange
            var forecast = new SetWeatherForecastCommand()
            {
                Temperature = temperature,
            };

            // Act
            var response = await setWeatherForecastCommandValidator.TestValidateAsync(forecast);

            // Assert
            response.ShouldHaveValidationErrorFor(x => x.Temperature).Only();
        }


        [Theory]
        [InlineData(100)]
        public async Task Given_SetForecast_When_Temperature_IsAboveThreshold_Then_Command_FailsAsync(int temperature)
        {
            // Arrange
            var forecast = new SetWeatherForecastCommand()
            {
                Temperature = temperature,
            };

            // Act
            var response = await setWeatherForecastCommandValidator.TestValidateAsync(forecast);

            // Assert
            response.ShouldHaveValidationErrorFor(x => x.Temperature).Only();
        }

        [Theory]
        [InlineData(20)]
        public async Task Given_SetForecast_When_Temperature_IsAgreeable_Then_Command_SuccessesAsync(int temperature)
        {
            // Arrange
            var forecast = new SetWeatherForecastCommand()
            {
                Temperature = temperature,
            };

            // Act
            var response = await setWeatherForecastCommandValidator.TestValidateAsync(forecast);

            // Assert
            response.ShouldNotHaveValidationErrorFor(x => x.Temperature);
        }
    }
}
