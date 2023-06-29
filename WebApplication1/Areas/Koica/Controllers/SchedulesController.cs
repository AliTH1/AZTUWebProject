using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Koica.Controllers
{
    [Area("Koica")]
    [Authorize]
    public class SchedulesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
