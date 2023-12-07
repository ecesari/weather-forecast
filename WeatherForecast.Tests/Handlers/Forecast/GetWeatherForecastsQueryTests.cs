using AutoMapper;
using Moq;
using WeatherForecast.Application.WeatherForecast.Queries.GetWeatherForecasts;
using WeatherForecast.Domain.Repository;

namespace WeatherForecast.Tests.Handlers.Clients
{
    public class GetWeatherForecastsQueryTests
    {
        private readonly Mock<IWeatherForecastRepository> repositoryMock;
        private readonly Mock<IMapper> mapperMock;
        private readonly GetWeatherForecastsQueryHandler handler;



        public GetWeatherForecastsQueryTests()
        {
            repositoryMock = new Mock<IWeatherForecastRepository>();
            mapperMock = new Mock<IMapper>();
            handler = new GetWeatherForecastsQueryHandler(repositoryMock.Object, mapperMock.Object);
        }

        [Fact]
        public void ConfigurationTest()
        {
            Assert.NotNull(handler);
        }
    }
}
