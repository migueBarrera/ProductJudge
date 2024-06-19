using ProductJudge.Api.Extensions.DatabaseContext;
using ProductJudge.Api.Extensions.MediatR;
using ProductJudge.Api.Extensions.Swagger;
using ProductJudge.Api.Startup;

namespace ProductJudge.Host;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _environment;

    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        _configuration = configuration;
        _environment = environment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCustomSwagger();
        services.AddControllers();
        services.AddCustomMediatR();
        services.AddAppDbContext(_configuration);
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseHostApplicationBuilderMiddlewares(_environment, _configuration);
    }
    }
