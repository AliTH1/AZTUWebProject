using DataAccess;
using Entities.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Areas.Koica.ViewComponents
{
    public class ListTeacherSubjectViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public ListTeacherSubjectViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            TeacherInfo teacherInfo = await _context.TeachersInfo
                    .Where(c => c.AppUser.UserName == User.Identity.Name).FirstAsync();

            return View(await _context.Subjects.Where(c => teacherInfo.Id == c.TeacherInfoId).ToListAsync());
        }
    }
}
