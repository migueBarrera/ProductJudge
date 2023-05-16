using ProductJudge.API.Services;

namespace ProductJudge.API.Extensions;

public static class ServicesCollectionExtensions
{
    public static WebApplicationBuilder ConfigureSerilog(this WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);

        return builder;
    }

    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<JwtSecurityTokenService>();
        builder.Services.AddTransient<UserControllerService>();

        return builder;
    }
}
