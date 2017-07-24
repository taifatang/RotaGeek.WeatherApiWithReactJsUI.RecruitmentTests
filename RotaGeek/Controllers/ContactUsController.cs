using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using RotaGeek.Services;
using RotaGeek.Services.Models;

namespace RotaGeek.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IFormService _formService;

        public ContactUsController(IFormService formService)
        {
            _formService = formService;
        }
        [HttpPost]
        public async Task<IActionResult> SubmitForm([FromBody]ContactForm form)
        {

            var result = await _formService.SubmitAsync(form);

            if (!result.Success)
            {
                return BadRequestWithErrors(result);
            }

            return StatusCode((int) HttpStatusCode.Created);
        }

        [HttpGet]
        public async Task<IActionResult> Forms()
        {
            try
            {
                var forms = await _formService.GetAllFormsAsync();
                return Json(forms);
            }
            catch (DocumentClientException)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        private static IActionResult BadRequestWithErrors(OperationResult result)
        {
            return new JsonResult(result)
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
    }
}
