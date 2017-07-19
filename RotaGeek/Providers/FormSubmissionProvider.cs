using System.Threading.Tasks;
using RotaGeek.Services;

namespace RotaGeek.Providers
{
    public class FormSubmissionProvider : IFormSubmissionProvider
    {
        public Task<Services.Models.OperationResult> SubmitAsync(ContactForm form)
        {
            throw new System.NotImplementedException();
        }
    }
}