using MediatR;

namespace weatherForecast.Application.Clients.Commands.CreateAppointment
{
    public class SetWeatherForecastCommand : IRequest<Guid>
    {
        public DateOnly Date { get; set; }
        public int Degree { get; set; }
    }

    public class SetWeatherForecastCommandHandler : IRequestHandler<SetWeatherForecastCommand, Guid>
    {
        public async Task<Guid> Handle(SetWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
 