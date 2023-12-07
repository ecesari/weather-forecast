using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeatherForecast.Application.Clients.Commands.SetWeatherForecastCommand;

namespace weatherForecast.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator mediator;

        public WeatherForecastController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Create a forecast for today
        /// </summary>
        /// <param name="command">set today's temperature in Celcius</param>
        /// <returns>Ok if forecast was saved</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> CreateForecast([FromBody] SetWeatherForecastCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
