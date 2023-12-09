using AutoMapper;
using WeatherForecast.Api.Mapper;
using WeatherForecast.Api.Models;
using WeatherForecast.Application.Clients.Commands.SetWeatherForecastCommand;

namespace WeatherForecast.Tests.Mappers
{
    public  class ApiMapperTests
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
        [InlineData(2023,12,20, 20)]
        public void Given_ForecastModel_ShouldReturn_ForecastCommand(int dateYear, int dateMonth, int dateDay, int temperature)
        {
            var model = new SetWeatherForecastModel { Date = new DateOnly(dateYear, dateMonth, dateDay), Temperature = temperature };
            var response = mapper.Map<SetWeatherForecastCommand>(model);

            Assert.NotNull(response);
            Assert.Equal(model.Date, response.Date);
            Assert.Equal(model.Temperature, response.Temperature);
        }

        [Theory]
        [InlineData( 20)]
        public void Given_Temperature_ShouldReturn_ForecastCommand(int temperature)
        {
            var model = new SetWeatherForecastModel { Temperature = temperature };
            var response = mapper.Map<SetWeatherForecastCommand>(model);

            Assert.NotNull(response);
            Assert.Equal(model.Date, response.Date);
            Assert.Equal(model.Temperature, response.Temperature);
        }
    }
}
