using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductJudge.Infrastructure.Context;

namespace ProductJudge.Application.Features.WeatherForecast.GetWeatherForecast;

public class WeatherForecastHandler : IRequestHandler<WeatherForecastRequest, IEnumerable<WeatherForecastResponse>>
{
    private readonly AppDbContext applicationDbContext;

    public WeatherForecastHandler(AppDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<WeatherForecastResponse>> Handle(WeatherForecastRequest request, CancellationToken cancellationToken)
    {
        var weatherForecast = await applicationDbContext
            .WeatherForecasts
            .ToListAsync(cancellationToken);

        return weatherForecast.Select(item => new WeatherForecastResponse()
        {
            Date = item.Date,
            Summary = item.Summary,
            TemperatureC = item.TemperatureC,
        });
    }
}
