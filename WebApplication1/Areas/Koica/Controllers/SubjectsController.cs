using DataAccess;
using Entities.Koica;
using Entities.Koica.SubjectMaterials;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using WebApplication1.Areas.Koica.ViewModels;

namespace WebApplication1.Areas.Koica.Controllers
{
    [Area("Koica")]
    [Authorize]
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



        #region Forum
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
        public async Task<IActionResult> CreateForum(CreateSubjectVM createForum)
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
        #endregion


        #region Didactic Materials
        public async Task<IActionResult> DidacticMaterials(int id)
        {
            HomeVM homeVM = new HomeVM()
            {
                DidacticMaterials = await _context.DidacticMaterials.Where(c => c.SubjectId == id).ToListAsync(),
                Subject = await _context.Subjects.FirstOrDefaultAsync(c => c.Id == id)
            };

            return View(homeVM);
        }


        [HttpPost]
        public async Task<IActionResult> CreateDidacticMaterial(CreateSubjectVM createDidacticMaterial)
        {
            string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "koica", "files");
            string fileName = Guid.NewGuid().ToString() + createDidacticMaterial.File.FileName;
            string resultPath = Path.Combine(rootPath, fileName);


            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                await createDidacticMaterial.File.CopyToAsync(fileStream);
            }

            DidacticMaterial newDidactic = new DidacticMaterial()
            {
                Topic = createDidacticMaterial.Topic,
                Content = createDidacticMaterial.Content,
                Author = User.Identity.Name,
                FilePath = fileName,
                NumOfApplications = 0,
                Date = DateTime.Now,
                SubjectId = createDidacticMaterial.RouteId
            };

            await _context.DidacticMaterials.AddAsync(newDidactic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DidacticMaterials), new { id = createDidacticMaterial.RouteId });
        }

        #endregion



        public async Task<IActionResult> Evaluation(int id)
        {
            HomeVM homeVM = new HomeVM()
            {
                Evaluations = await _context.Evaluations.Where(c => c.SubjectId == id).Include(c => c.StudentInfos)
                .Include(c => c.StudentEvaluations).ToListAsync(),
                Subject = await _context.Subjects.FirstOrDefaultAsync(c => c.Id == id)
            };

            return View(homeVM);
        }

        public async Task<IActionResult> CreateEvaluation(CreateEvaluationVM createEvaluation)
        {
            if (createEvaluation.File == null)
            {
                Evaluation newEvaluationWithoutFile = new Evaluation()
                {
                    Topic = createEvaluation.Topic,
                    TypeOfTeaching = createEvaluation.TypeOfTeaching,
                    Start = createEvaluation.Start,
                    End = createEvaluation.End,
                    Content = createEvaluation.Content,
                    Author = User.Identity.Name,
                    SubjectId = createEvaluation.RouteId
                };

                await _context.Evaluations.AddAsync(newEvaluationWithoutFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Evaluation), new { id = createEvaluation.RouteId });
            }



            string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "koica", "files");
            string fileName = Guid.NewGuid().ToString() + createEvaluation.File.FileName;
            string resultPath = Path.Combine(rootPath, fileName);


            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                await createEvaluation.File.CopyToAsync(fileStream);
            }

            Evaluation newEvaluation = new Evaluation()
            {
                Topic = createEvaluation.Topic,
                TypeOfTeaching = createEvaluation.TypeOfTeaching,
                Start = createEvaluation.Start,
                End = createEvaluation.End,
                Content = createEvaluation.Content,
                Author = User.Identity.Name,
                FilePath = fileName,
                SubjectId = createEvaluation.RouteId
            };

            await _context.Evaluations.AddAsync(newEvaluation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DidacticMaterials), new { id = createEvaluation.RouteId });
        }




        public async Task<IActionResult> Progress(int id)
        {
            HomeVM homeVM = new HomeVM()
            {
                Progresses = await _context.Progresses.Where(c => c.SubjectId == id).ToListAsync(),
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
