using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Areas.Koica.Controllers
{
    [Area("Koica")]
    public class SubjectsController : Controller
    {
        private readonly AppDbContext _context;

        public SubjectsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Notification(int id)
        {
            return View(await _context.Subjects.FirstOrDefaultAsync(c => c.Id == id));
        }

        public async Task<IActionResult> Forum(int id)
        {
            return View(await _context.Subjects.FirstOrDefaultAsync(c => c.Id == id));

        }

        public async Task<IActionResult> DidacticMaterials(int id)
        {
            return View(await _context.Subjects.FirstOrDefaultAsync(c => c.Id == id));
        }

        public async Task<IActionResult> Evaluation(int id)
        {
            return View(await _context.Subjects.FirstOrDefaultAsync(c => c.Id == id));
        }
    }
}
