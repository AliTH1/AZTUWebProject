using DataAccess;
using Entities.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static WebApplication1.Controllers.AccountController;

namespace WebApplication1.Areas.Koica.ViewComponents
{
    public class ListStudentSubjectViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public ListStudentSubjectViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            StudentInfo studentInfo = await _context.StudentsInfo
                .Where(c => c.AppUser.UserName == User.Identity.Name).FirstAsync();

            return View(
                await _context.GroupSubjects.Where(c => studentInfo.Group == c.Group.Name)
                .Include(c => c.Subject).ToListAsync()
                );
        }
    }
}
