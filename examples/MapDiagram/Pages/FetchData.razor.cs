using MapDiagram.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MapDiagram.Pages
{
    public class FetchDataBase : ComponentBase
    {
        protected WeatherForecast[] forecasts;

        [Inject]
        private HttpClient Http { get; set; }

        protected override async Task OnInitializedAsync()
        {
            forecasts = await Http.GetJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        }
    }
}
