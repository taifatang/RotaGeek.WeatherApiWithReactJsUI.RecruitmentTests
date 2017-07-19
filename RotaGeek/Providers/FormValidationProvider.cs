using System;
using System.Linq;
using System.Threading.Tasks;
using RotaGeek.Services;
using RotaGeek.Services.Models;

namespace RotaGeek.Providers
{
    public class FormValidationProvider : IFormValidationProvider
    {
        public async Task<OperationResult> ValidateAsync(ContactForm form)
        {
            return await Task.Factory.StartNew<OperationResult>(() =>
            {
                var result = new OperationResult();

                if (String.IsNullOrWhiteSpace(form.Name))
                {
                 result.Errors.Add("Name can not be empty");   
                }
                if (String.IsNullOrWhiteSpace(form.Email))
                {
                    result.Errors.Add("Email can not be empty");
                }
                if (String.IsNullOrWhiteSpace(form.Message))
                {
                    result.Errors.Add("Message can not be empty");
                }

                if (result.Errors.Any())
                {
                    result.Success = false;
                }

                return new OperationResult();
            });
        }
    }
}
