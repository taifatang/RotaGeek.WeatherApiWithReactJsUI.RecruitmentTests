using System.Collections.Generic;
using System.Threading.Tasks;
using RotaGeek.Providers;
using RotaGeek.Repository;
using RotaGeek.Services.Models;

namespace RotaGeek.Services
{
    public class FormService : IFormService
    {
        private readonly IFormValidationProvider _formValidationProvider;
        private readonly IDocumentDbRepository<ContactForm> _documentDbRepository;

        public FormService(IFormValidationProvider formValidationProvider, IDocumentDbRepository<ContactForm> documentDbRepository)
        {
            _formValidationProvider = formValidationProvider;
            _documentDbRepository = documentDbRepository;
        }

        public async Task<OperationResult> SubmitAsync(ContactForm form)
        {
            var validateResult = await _formValidationProvider.ValidateAsync(form);

            if (validateResult.Success)
            {
                await _documentDbRepository.CreateOrUpdateItemAsync(form);
            }

            return validateResult;
        }

        public async Task<IEnumerable<ContactForm>> RetrieveAllContactForms()
        {
            return await _documentDbRepository.GetAllAsync();
        }
    }
}
