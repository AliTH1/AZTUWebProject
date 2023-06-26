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
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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

            await _userManager.AddToRoleAsync(newUser, UserRoles.Student.ToString());


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

            await _userManager.AddToRoleAsync(newUser, UserRoles.Teacher.ToString());

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


        
        //public async Task AddRoles()
        //{
        //    foreach (UserRoles role in Enum.GetValues(typeof(UserRoles)))
        //    {
        //        if (!await _roleManager.RoleExistsAsync(role.ToString()))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole<int> { Name = role.ToString() });
        //        }
        //    }
        //}



        public enum UserRoles
        {
            Teacher,
            Student,
            Admin
        }
    }
}
