using Moq;
using WeatherForecast.Application.Clients.Commands.SetWeatherForecastCommand;
using WeatherForecast.Application.Common.Exceptions;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Repository;

namespace WeatherForecast.Tests.Handlers.Clients
{
    public class SetWeatherForecastCommandTests
    {
        private readonly Mock<IWeatherForecastRepository> repositoryMock;
        private readonly Mock<IWeatherSummaryRepository> weatherSummaryRepositoryMock;
        private readonly SetWeatherForecastCommandHandler handler;



        public SetWeatherForecastCommandTests()
        {
            repositoryMock = new Mock<IWeatherForecastRepository>();
            weatherSummaryRepositoryMock = new Mock<IWeatherSummaryRepository>();
            handler = new SetWeatherForecastCommandHandler(repositoryMock.Object, weatherSummaryRepositoryMock.Object);
        }

        [Fact]
        public void ConfigurationTest()
        {
            Assert.NotNull(handler);
        }

        [Theory]
        [InlineData(1)]
        public void Given_SummaryNotFound_Should_ThrowError(int temperature)
        {
            var command = new SetWeatherForecastCommand { Temperature = temperature };
            weatherSummaryRepositoryMock.Setup(x => x.GetByTemperature(temperature)).Returns<WeatherSummary?>(null);
            Assert.ThrowsAsync<EntityNotFoundException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}
