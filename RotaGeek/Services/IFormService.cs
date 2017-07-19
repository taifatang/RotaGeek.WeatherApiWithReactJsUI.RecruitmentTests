using System.Threading.Tasks;
using RotaGeek.Services.Models;

namespace RotaGeek.Services
{
    public interface IFormService
    {
        Task<OperationResult> SubmitAsync(ContactForm form);
    }
}