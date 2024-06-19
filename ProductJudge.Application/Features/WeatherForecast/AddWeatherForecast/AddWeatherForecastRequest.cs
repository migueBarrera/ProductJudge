using MediatR;

namespace ProductJudge.Application.Features.WeatherForecast.AddWeatherForecast;

public class AddWeatherForecastRequest : IRequest<Unit>
{
    public int TemperatureC { get; set; }

    public string? Summary { get; set; }
}
