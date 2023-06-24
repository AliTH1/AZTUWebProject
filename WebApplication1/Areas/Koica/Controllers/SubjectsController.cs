using DataAccess;
using Entities.Koica;
using Entities.Koica.SubjectMaterials;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using WebApplication1.Areas.Koica.ViewModels;

namespace WebApplication1.Areas.Koica.Controllers
{
    [Area("Koica")]
    public class SubjectsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SubjectsController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Notification(int id)
        {
            HomeVM homeVM = new HomeVM()
            {
                Notifications = await _context.Notifications.Where(c => c.SubjectId == id).ToListAsync(),
                Subject = await _context.Subjects.FirstOrDefaultAsync(c => c.Id == id)
            };
            return View(homeVM);
        }


        public async Task<IActionResult> Forum(int id)
        {
            HomeVM homeVM = new HomeVM()
            {
                Forums = await _context.Forums.Where(c => c.SubjectId == id).ToListAsync(),
                Subject = await _context.Subjects.FirstOrDefaultAsync(c => c.Id == id)
            };

            return View(homeVM);
        }


        [HttpPost]
        public async Task<IActionResult> CreateForum(CreateForumVM createForum)
        {
            string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "koica", "files");
            string fileName = Guid.NewGuid().ToString() + createForum.File.FileName;
            string resultPath = Path.Combine(rootPath, fileName);


            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                await createForum.File.CopyToAsync(fileStream);
            }

            Forum newForum = new Forum()
            {
                Topic = createForum.Topic,
                Content = createForum.Content,
                Author = User.Identity.Name,
                FilePath = fileName,
                NumOfApplications = 0,
                Date = DateTime.Now,
                SubjectId = createForum.RouteId
            };

            await _context.Forums.AddAsync(newForum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Forum), new { id = createForum.RouteId });
        }


        public async Task<IActionResult> DidacticMaterials(int id)
        {
            HomeVM homeVM = new HomeVM()
            {
                DidacticMaterials = await _context.DidacticMaterials.Where(c => c.SubjectId == id).ToListAsync(),
                Subject = await _context.Subjects.FirstOrDefaultAsync(c => c.Id == id)
            };

            return View(homeVM);
        }

        public async Task<IActionResult> Evaluation(int id)
        {
            HomeVM homeVM = new HomeVM()
            {
                Evaluations = await _context.Evaluations.Where(c => c.SubjectId == id).ToListAsync(),
                Subject = await _context.Subjects.FirstOrDefaultAsync(c => c.Id == id)
            };

            return View(homeVM);
        }
        public IActionResult DownloadFile(string fileName)
        {
            var filepath = Path.Combine(_webHostEnvironment.WebRootPath, "koica", "files", fileName);
            return File(System.IO.File.ReadAllBytes(filepath), System.Net.Mime.MediaTypeNames.Application.Octet,
                Path.GetFileName(filepath));
        }
    }
}
