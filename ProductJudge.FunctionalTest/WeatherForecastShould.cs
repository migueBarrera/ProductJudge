using ProductJudge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http.Json;

namespace ProductJudge.FunctionalTest;

public class WeatherForecastShould
{
    private readonly HttpClient _client;

    public WeatherForecastShould()
    {
        var app = new CustomTestServer();
        _client = app.CreateClient();  


        var myvalue = new WeatherForecast();   
    }

    [Fact]
    public async void GetWeatherForecast_ShouldReturnForecast()
    {
        var response = await _client.GetAsync("api/weatherforecast");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadFromJsonAsync<List<WeatherForecast>>();

        //Comentario que resuelve un fix
    }

    public void Test()
    {

    }
}
