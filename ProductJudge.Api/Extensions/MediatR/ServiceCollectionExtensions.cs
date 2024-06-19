using Microsoft.Extensions.DependencyInjection;
using ProductJudge.Application;

namespace ProductJudge.Api.Extensions.MediatR;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServicesConstants).Assembly));
        return services;
    }
}
