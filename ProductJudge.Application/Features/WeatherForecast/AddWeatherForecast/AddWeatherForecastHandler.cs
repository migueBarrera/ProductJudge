using MediatR;
using ProductJudge.Infrastructure.Context;

namespace ProductJudge.Application.Features.WeatherForecast.AddWeatherForecast;

public class AddWeatherForecastHandler : IRequestHandler<AddWeatherForecastRequest, Unit>
{
    private readonly AppDbContext applicationDbContext;

    public AddWeatherForecastHandler(AppDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;

        applicationDbContext.Database.EnsureCreated();
    }

    public async Task<Unit> Handle(AddWeatherForecastRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.WeatherForecast forecast = new Domain.Entities.WeatherForecast() 
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = request.TemperatureC,
            Summary = request.Summary,
        };

        applicationDbContext.WeatherForecasts.Add(forecast);

        await applicationDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
