using System.Threading.Tasks;
using RotaGeek.Services;
using RotaGeek.Services.Models;

namespace RotaGeek.Providers
{
    public interface IDocumentDbRepository
    {
        Task<OperationResult> SubmitAsync(ContactForm form);
    }
}