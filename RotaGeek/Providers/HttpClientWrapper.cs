using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RotaGeek.Providers
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T> GetAsync<T>(Uri requestUri)
        {
            var response = await _httpClient.GetAsync(requestUri);
            var responseText = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseText);
        }
    }
}