using Microsoft.AspNetCore.Components;
using NetcodeHub.Packages.Components.BackgroundTaskStopper;
using System.Net.Http.Json;

namespace BlazorApp
{
    public class General : NetcodeHubTaskManager
    {
        public WeatherForecast[]? forecasts;
        [Inject] public HttpClient HttpClient { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            forecasts = await HttpClient.GetFromJsonAsync<WeatherForecast[]>("https://localhost:9888/weather", ComponentMonitor());
        }
    }
}

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
