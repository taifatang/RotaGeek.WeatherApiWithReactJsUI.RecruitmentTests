using System.Threading.Tasks;
using RotaGeek.Services;
using RotaGeek.Services.Models;

namespace RotaGeek.Providers
{
    public interface IFormValidationProvider
    {
        Task<OperationResult> ValidateAsync(ContactForm form);
    }
}