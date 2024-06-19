using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductJudge.Application;
using ProductJudge.Application.Features.WeatherForecast.AddWeatherForecast;
using ProductJudge.Application.Features.WeatherForecast.GetWeatherForecast;

namespace ProductJudge.Api.Controllers;

[Route($"{ApiConstants.Endpoints.ApiBase}/{ApiConstants.Endpoints.WeatherForecast}")]
[ControllerName(ApiConstants.Controllers.WeatherForecast)]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<ActionResult<IEnumerable<WeatherForecastResponse>>> Get(CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(new WeatherForecastRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost(Name = "AddWeatherForecast")]
    public async Task<IActionResult> Add(AddWeatherForecastRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
