using Microsoft.OpenApi.Models;
using WeatherForecast.Api.ServiceCollections;
using WeatherForecast.Application.WeatherForecast.Queries.GetWeatherForecasts;
using WeatherForecast.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = " Weather Forecast APIs"
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
builder.Services.AddRepositories();
builder.Services.AddAutoMapper();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetWeatherForecastsQuery).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather Forecast v1"); });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
