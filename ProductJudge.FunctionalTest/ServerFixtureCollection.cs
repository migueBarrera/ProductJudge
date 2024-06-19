using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace ProductJudge.FunctionalTest;

[CollectionDefinition(nameof(ServerFixtureCollection))]
public class ServerFixtureCollection
      : ICollectionFixture<ServerFixture>
{ }

public class ServerFixture : TestServerFixture
{
    public Given Given { get; private set; }

    public ServerFixture()
        : base()
    {
        Given = new Given(this);
    }


    protected override void ConfigureStartUp(IWebHostBuilder builder)
    {
        builder.UseStartup<Startup>();

    }

    protected override void ConfigureHost(IHost host)
    {
        var checkpoint = ConfigureCheckPoint();
        checkpoint.Wait();

    }


}
