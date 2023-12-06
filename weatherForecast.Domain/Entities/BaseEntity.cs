using System.ComponentModel.DataAnnotations;

namespace weatherForecast.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}