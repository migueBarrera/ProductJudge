using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductJudge.Host;
using ProductJudge.Infrastructure.Context;

namespace ProductJudge.FunctionalTest;

public class CustomTestServer : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("DatabaseTest");
            });
        });
        return base.CreateHost(builder);
    }
}
