﻿using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}