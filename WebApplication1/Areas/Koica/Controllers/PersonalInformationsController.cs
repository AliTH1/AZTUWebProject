using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Koica.Controllers
{
    [Area("Koica")]
    public class PersonalInformationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
