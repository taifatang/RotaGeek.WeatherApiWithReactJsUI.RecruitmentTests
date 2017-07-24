using System;
using System.Threading.Tasks;
using RotaGeek.Configuration;
using RotaGeek.Providers;
using RotaGeek.Services.Models;

namespace RotaGeek.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientWrapper _httpClient;

        public WeatherService(IHttpClientWrapper httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Weather> GetWeatherAsync(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentNullException(nameof(location), "Location is null");
            }
            var builder = new UriBuilder(RotaGeekConstant.WeatherApiEndpoint);
            builder.Query = $"key={RotaGeekConstant.WeatherApiPrimaryKey}&q=${location}";
            return await _httpClient.GetAsync<Weather>(builder.Uri);
        }
    }
}
