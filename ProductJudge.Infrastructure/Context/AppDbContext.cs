using Microsoft.EntityFrameworkCore;
using ProductJudge.Domain.Entities;

namespace ProductJudge.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) 
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
}
