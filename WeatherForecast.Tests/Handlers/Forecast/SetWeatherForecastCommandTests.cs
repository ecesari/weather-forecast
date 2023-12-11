using Moq;
using WeatherForecast.Application.Clients.Commands.SetWeatherForecastCommand;
using WeatherForecast.Application.Common.Exceptions;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Repository;

namespace WeatherForecast.Tests.Handlers.Clients
{
    public class SetWeatherForecastCommandTests
    {
        private readonly Mock<IForecastRepository> repositoryMock;
        private readonly Mock<ISummaryRepository> weatherSummaryRepositoryMock;
        private readonly SetWeatherForecastCommandHandler handler;



        public SetWeatherForecastCommandTests()
        {
            repositoryMock = new Mock<IForecastRepository>();
            weatherSummaryRepositoryMock = new Mock<ISummaryRepository>();
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
            weatherSummaryRepositoryMock.Setup(x => x.GetByTemperature(temperature)).Returns<Summary?>(null);
            Assert.ThrowsAsync<EntityNotFoundException>(() => handler.Handle(command, CancellationToken.None));
        }

        [Theory]
        [InlineData(1, 2023, 1, 31)]
        public void Given_ForecastFound_Should_ThrowError(int temperature, int dateYear, int dateMonth, int dateDay)
        {
            var date = new DateOnly(dateYear, dateMonth, dateDay);
            var command = new SetWeatherForecastCommand { Temperature = temperature, Date = date };
            weatherSummaryRepositoryMock.Setup(x => x.GetByTemperature(It.IsAny<int>())).Returns(new Summary());
            repositoryMock.Setup(x => x.ForecastExistsForDate(date)).Returns<Summary?>(null);
            Assert.ThrowsAsync<EntityAlreadyExistsException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}
