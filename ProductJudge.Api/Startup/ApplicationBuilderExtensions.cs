using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ProductJudge.Api.Extensions.Swagger;

namespace ProductJudge.Api.Startup;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseHostApplicationBuilderMiddlewares(
        this IApplicationBuilder app,
        IWebHostEnvironment environment,
        IConfiguration configuration)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseCustomSwagger();


        return app;
    }
}
