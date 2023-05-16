namespace ProductJudge.API.Repository;

public static class DataBaseExtensions
{
    public static IServiceCollection AddDataBaseConfiguration(this IServiceCollection services)
    {
        var name = "testdatabase";

        services.AddDbContext<DatabaseContext>(options => 
            options
            .UseInMemoryDatabase(name)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors());

        return services;
    }
}
