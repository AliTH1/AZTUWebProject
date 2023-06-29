using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Koica.Controllers
{
    [Area("Koica")]
    [Authorize]
    public class PersonalInformationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
