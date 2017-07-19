using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RotaGeek.Services;

namespace RotaGeek.Controllers
{
    [Route("api/[controller]")]
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
            if (form == null)
            {
                return BadRequest();
            }

            var result = await _formService.SubmitAsync(form);

            if (!result.Success)
            {
                return new JsonResult(result)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }

            return Ok();
        }
    }
}
