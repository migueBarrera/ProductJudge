using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ProductJudge.FunctionalTest;

public abstract class TestServerFixture
{
    private static IConfiguration _configuration = null!;
    public TestServer Server { get; private set; } = null!;

    protected TestServerFixture()
    {
        InitializeTestServer();
    }

    private void InitializeTestServer()
    {
        var host = new HostBuilder()
        .ConfigureWebHost(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IServer>(serviceProvider => new TestServer(serviceProvider));
            });
            ConfigureStartUp(builder);
        })
        .ConfigureAppConfiguration((_, builder) =>
        {
            builder.AddJsonFile("appsettings.json", optional: false);
            _configuration = builder.Build();

        })
        .Build();

        host.StartAsync().Wait();

        ConfigureHost(host);

        Server = host.GetTestServer();
    }

    protected abstract void ConfigureStartUp(IWebHostBuilder builder);

    protected abstract void ConfigureHost(IHost host);
}
