using MediatR;

namespace ProductJudge.Application.Features.WeatherForecast.GetWeatherForecast;

public class WeatherForecastRequest : IRequest<IEnumerable<WeatherForecastResponse>>
{
}
