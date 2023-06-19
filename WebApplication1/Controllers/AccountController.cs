using DataAccess;
using Entities.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels.Account;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult RegisterStudent()
        {
            return View(new RegisterStudentVM());
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudent(RegisterStudentVM registerStudent)
        {
            if (!ModelState.IsValid) return View(registerStudent);

            AppUser newUser = new AppUser()
            {
                UserName = registerStudent.UserName,
                Email = registerStudent.Email
            };

            IdentityResult registerResult = await _userManager.CreateAsync(newUser, registerStudent.Password);
            if (!registerResult.Succeeded)
            {
                foreach (IdentityError error in registerResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerStudent);
            }

            StudentInfo studentInfo = new StudentInfo()
            {
                UserId = newUser.Id,
                FullName = registerStudent.FullName,
                Group = registerStudent.Group,
            };

            await _context.AddAsync(studentInfo);
            await _context.SaveChangesAsync();

            return Json("Ok");

        }



        [HttpGet]
        public IActionResult RegisterTeacher()
        {
            return View(new RegisterTeacherVM());
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTeacher(RegisterTeacherVM registerTeacher)
        {
            if (!ModelState.IsValid) return View(registerTeacher);

            AppUser newUser = new AppUser()
            {
                UserName = registerTeacher.UserName,
                Email = registerTeacher.Email
            };

            IdentityResult registerResult = await _userManager.CreateAsync(newUser, registerTeacher.Password);
            if (!registerResult.Succeeded)
            {
                foreach (IdentityError error in registerResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            TeacherInfo teacherInfo = new()
            {
                UserId = newUser.Id,
                FullName = registerTeacher.FullName,
                Degree = registerTeacher.Degree,
                Profession = registerTeacher.Profession
            };

            await _context.AddAsync(teacherInfo);
            await _context.SaveChangesAsync();

            return Json("Ok");

        }

        public IActionResult Login()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View(login);

            AppUser user = await _userManager.FindByNameAsync(login.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "Username or password is wrong");
                return View(login);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is wrong");
                return View(login);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            return RedirectToAction("Index", "Home", new {Area = "Koica"});
        }
    }
}
