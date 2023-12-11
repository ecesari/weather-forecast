using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Domain.SeedWork
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}