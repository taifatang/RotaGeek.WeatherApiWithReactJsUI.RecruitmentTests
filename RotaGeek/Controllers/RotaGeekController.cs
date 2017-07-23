using Microsoft.AspNetCore.Mvc;

namespace RotaGeek.Controllers
{
    public class RotaGeekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}
