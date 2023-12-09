using AutoMapper;
using WeatherForecast.Api.Mapper;
using WeatherForecast.Api.Models;
using WeatherForecast.Application.Clients.Commands.SetWeatherForecastCommand;
using WeatherForecast.Application.WeatherForecast.Queries.GetWeatherForecasts;
using WeatherForecast.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace WeatherForecast.Tests.Mappers
{
    public class ApiMapperTests
    {
        private readonly IMapper mapper;
        private readonly MapperConfiguration config;


        public ApiMapperTests()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApiMapperConfig());
            }); mapper = config.CreateMapper();
        }

        [Fact]
        public void ConfigurationTest()
        {
            config.AssertConfigurationIsValid();

            Assert.NotNull(mapper);
        }

        [Theory]
        [InlineData(2023, 1, 31, 20)]
        public void Given_ForecastModel_ShouldReturn_ForecastCommand(int dateYear, int dateMonth, int dateDay, int temperature)
        {
            var dateTime = new DateTime(dateYear, dateMonth, dateDay);
            var model = new SetWeatherForecastModel { Date = dateTime, Temperature = temperature };
            var command = mapper.Map<SetWeatherForecastCommand>(model);

            Assert.NotNull(command);
            Assert.Equal(DateOnly.FromDateTime(dateTime), command.Date);
            Assert.Equal(model.Temperature, command.Temperature);
        }


        [Theory]
        [InlineData(2023, 1, 31, "Tuesday, January 31, 2023", 20, "foo")]
        public void Given_ForecastResponse_ShouldReturn_DailyForecastModel(int dateYear, int dateMonth, int dateDay, string expectedDate, int temperature, string summary)
        {
            var response = new WeatherForecastResponse { Date = new DateOnly(dateYear, dateMonth, dateDay), Temperature = temperature, Summary = summary };
            var model = mapper.Map<DailyWeatherForecastModel>(response);

            Assert.NotNull(response);
            Assert.Equal(response.Temperature, model.Temperature);
            Assert.Equal(response.Summary, model.Description);
            Assert.Equal(expectedDate, model.Date);
        }


        [Theory]
        [InlineData(2023, 1, 31, 20, "foo")]
        public void Given_ForecastResponseList_ShouldReturn_DailyForecastModelList(int dateYear, int dateMonth, int dateDay, int temperature, string summary)
        {
            var response1 = new WeatherForecastResponse { Date = new DateOnly(dateYear, dateMonth, dateDay), Temperature = temperature, Summary = summary };
            var response2 = new WeatherForecastResponse { Date = new DateOnly(dateYear, dateMonth, dateDay), Temperature = temperature, Summary = summary };
            var list = new List<WeatherForecastResponse> { response1, response2 };
            var model = mapper.Map<List<DailyWeatherForecastModel>>(list);

            Assert.NotNull(model);
            Assert.Equal(2, model.Count);
        }
    }
}
