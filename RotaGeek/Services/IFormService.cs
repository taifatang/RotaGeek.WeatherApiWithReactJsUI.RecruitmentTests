using System.Threading.Tasks;
using RotaGeek.Services.Models;
using System.Collections.Generic;

namespace RotaGeek.Services
{
    public interface IFormService
    {
        Task<OperationResult> SubmitAsync(ContactForm form);
        Task<IEnumerable<ContactForm>> RetrieveAllContactForms();
    }
}