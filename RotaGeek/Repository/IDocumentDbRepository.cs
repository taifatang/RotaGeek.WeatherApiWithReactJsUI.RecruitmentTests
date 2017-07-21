using System.Collections.Generic;
using System.Threading.Tasks;

namespace RotaGeek.Repository
{
    public interface IDocumentDbRepository<T> where T : class, new()
    {
        Task CreateItemAsync(T item);
        Task CreateOrUpdateItemAsync(T item);
        Task<IEnumerable<T>> GetAllAsync();
    }
}