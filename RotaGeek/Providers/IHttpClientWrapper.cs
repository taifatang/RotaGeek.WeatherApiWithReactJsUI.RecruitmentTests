using System;
using System.Threading.Tasks;

namespace RotaGeek.Providers
{
    public interface IHttpClientWrapper
    {
        Task<T> GetAsync<T>(Uri requestUri);
    }
}