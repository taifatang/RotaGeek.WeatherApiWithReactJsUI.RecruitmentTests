using System.Threading.Tasks;
using RotaGeek.Services;
using RotaGeek.Services.Models;

namespace RotaGeek.Providers
{
    public interface IFormSubmissionProvider
    {
        Task<OperationResult> SubmitAsync(ContactForm form);
    }
}