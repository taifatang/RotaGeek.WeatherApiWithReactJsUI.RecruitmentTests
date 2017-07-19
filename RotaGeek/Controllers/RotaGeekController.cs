using Microsoft.AspNetCore.Mvc;

namespace RotaGeek.Controllers
{
    [Route("")]
    public class RotaGeekController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
