using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Forecast> WeatherForecasts { get; set; }
        public DbSet<WeatherSummary> WeatherSummaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TimeSlot>().HasKey(timeslot => timeslot.Id);
            //modelBuilder.Entity<Appointment>().HasKey(appointment => appointment.Id);
            //modelBuilder.Entity<Psychologist>().HasKey(psychologist => psychologist.Id);
            //modelBuilder.Entity<Client>().HasKey(client => client.Id);

            //modelBuilder.Entity<Psychologist>().HasMany(p => p.Clients).WithMany(b => b.Psychologists);
            //modelBuilder.Entity<Psychologist>().HasMany(p => p.Appointments).WithOne(b => b.Psychologist);
            //modelBuilder.Entity<Psychologist>().HasMany(p => p.Availability);

            //modelBuilder.Entity<Client>().HasMany(p => p.Psychologists).WithMany(b => b.Clients);
            //modelBuilder.Entity<Client>().HasMany(p => p.Appointments).WithOne(b => b.Client);
        }
    }
}
