using AutoMapper;
using WeatherForecast.Api.Mapper;
using WeatherForecast.Application.Common.Mapper;
using WeatherForecast.Domain.Repository;
using WeatherForecast.Domain.SeedWork;
using WeatherForecast.Infrastructure.Repository;
using WeatherForecast.Infrastructure.Repository.Base;

namespace WeatherForecast.Api.ServiceCollections
{

    public static class ExtensionsServiceCollection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IForecastRepository, ForecastRepository>();
            services.AddScoped<ISummaryRepository, SummaryRepository>();

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApiMapperConfig());
                mc.AddProfile(new ApplicationMapperConfig());

            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }


    }

}
