using System.Threading.Tasks;
using RotaGeek.Services.Models;

namespace RotaGeek.Services
{
    public interface IWeatherService
    {
        Task<Weather> GetWeatherAsync(string location);
    }
}