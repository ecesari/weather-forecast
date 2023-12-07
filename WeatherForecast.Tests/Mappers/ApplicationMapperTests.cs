using AutoMapper;
using WeatherForecast.Application.Common.Mapper;
using WeatherForecast.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Tests.Mappers
{
    public class ApplicationMapperTests
    {
        private readonly IMapper mapper;
        private readonly MapperConfiguration config;


        public ApplicationMapperTests()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationMapperConfig());
            }); mapper = config.CreateMapper();
        }

        [Fact]
        public void ConfigurationTest()
        {
            config.AssertConfigurationIsValid();

            Assert.NotNull(mapper);
        }

        [Theory]
        [InlineData(2023, 12, 20, 20, "summary")]
        public void Given_Forecast_ShouldReturn_ForecastResponse(int dateYear, int dateMonth, int dateDay, int temperature, string summary)
        {
            var id = Guid.NewGuid();
            var entity = new Forecast { Date = new DateOnly(dateYear, dateMonth, dateDay), Temperature = temperature, Id = id, Summary = summary };
            var response = mapper.Map<WeatherForecastResponse>(entity);

            Assert.NotNull(response);
            Assert.Equal(entity.Date, response.Date);
            Assert.Equal(entity.Temperature, response.Temperature);
            Assert.Equal(entity.Summary, response.Summary);
            Assert.Equal(entity.Id, response.Id);
        }

        [Theory]
        [InlineData(2023, 12, 20, 20, "summary")]
        public void Given_ForecastList_ShouldReturn_ForecastResponseList(int dateYear, int dateMonth, int dateDay, int temperature, string summary)
        {
            var id = Guid.NewGuid();
            var firstEntity = new Forecast { Date = new DateOnly(dateYear, dateMonth, dateDay), Temperature = temperature, Id = id, Summary = summary };
            var secondEntity = new Forecast { Date = new DateOnly(dateYear, dateMonth, dateDay), Temperature = temperature, Id = id, Summary = summary };
            var list = new List<Forecast> { firstEntity,secondEntity};            
            var responseList = mapper.Map<List<WeatherForecastResponse>>(list);

            Assert.NotNull(responseList);
            Assert.Equal(2, responseList.Count);
            Assert.Equal(firstEntity.Date, responseList[0].Date);
            Assert.Equal(secondEntity.Date, responseList[1].Date);
        }
    }
}
