using System.Threading.Tasks;
using RotaGeek.Providers;
using RotaGeek.Services.Models;

namespace RotaGeek.Services
{
    public class FormService : IFormService
    {
        private readonly IFormValidationProvider _formValidationProvider;
        private readonly IFormSubmissionProvider _formSubmissionProvider;

        public FormService(IFormValidationProvider formValidationProvider, IFormSubmissionProvider formSubmissionProvider)
        {
            _formValidationProvider = formValidationProvider;
            _formSubmissionProvider = formSubmissionProvider;
        }

        public async Task<OperationResult> SubmitAsync(ContactForm form)
        {
            var validateResult = await _formValidationProvider.ValidateAsync(form);

            if (validateResult.Success)
            {
                await _formSubmissionProvider.SubmitAsync(form);
            }

            return validateResult;
        }
    }
}
