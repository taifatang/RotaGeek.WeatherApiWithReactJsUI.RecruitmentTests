using Microsoft.AspNetCore.Mvc;

namespace RotaGeek.Services.Models
{
    public class WeatherRequest
    {
        [FromQuery(Name = "q")]
        public string Location { get; set; }
    }
}