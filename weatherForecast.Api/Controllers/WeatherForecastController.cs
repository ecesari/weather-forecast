using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeatherForecast.Api.Models;
using WeatherForecast.Application.Clients.Commands.SetWeatherForecastCommand;
using WeatherForecast.Application.WeatherForecast.Queries.GetWeatherForecasts;

namespace WeatherForecast.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public WeatherForecastController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Create a forecast for a certain day
        /// </summary>
        /// <param name="command">set temperature for a certain day in Celcius</param>
        /// <returns>Ok if forecast was saved</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> CreateForecast([FromBody] SetWeatherForecastModel model)
        {
            var command = mapper.Map<SetWeatherForecastCommand>(model);
            var response = await mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Create a forecast for today
        /// </summary>
        /// <param name="command">set today's temperature in Celcius</param>
        /// <returns>Ok if forecast was saved</returns>
        [HttpPost("today")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> CreateForecastForToday([FromBody] int temperature)
        {
            var command = mapper.Map<SetWeatherForecastCommand>(temperature);
            var response = await mediator.Send(command);
            return Ok(response);
        }


        /// <summary>
        /// Get forecast between dates
        /// </summary>
        /// <param name="model">dates to get temperature</param>
        /// <returns>List of forecasts if they exist</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<DailyWeatherForecastModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetForecast([FromBody] GetWeatherForecastModel model)
        {
            var query = mapper.Map<GetWeatherForecastsQuery>(model);
            var response = await mediator.Send(query);
            var responseModel = mapper.Map<List<DailyWeatherForecastModel>>(response);
            return Ok(responseModel);
        }
    }
}
