namespace ProductJudge.Domain.Entities;

public class WeatherForecast
{
    public int ID { get; set; }

    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
