using DataAccess;
using Entities.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Areas.Koica.ViewComponents
{
	public class ListSubjectViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public ListSubjectViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            StudentInfo result = await _context.StudentsInfo
                .Where(c => c.AppUser.UserName == User.Identity.Name).FirstAsync();



            return View(
                await _context.GroupSubjects.Where(c => result.Group == c.Group.Name)
                .Include(c => c.Subject).ToListAsync()
                );
        }
    }
}
