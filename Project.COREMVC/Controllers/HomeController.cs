using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models;
using Project.COREMVC.Models.AppUsers.RequestModels;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System.Diagnostics;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;


namespace Project.COREMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly UserManager<AppUser> _userManager;
        readonly RoleManager<IdentityRole<int>> _roleManager;
        readonly SignInManager<AppUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager, SignInManager<AppUser> signInManager)
        {

            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    
                };
                IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    IdentityRole<int> appRole = await _roleManager.FindByNameAsync("Employee");
                    if (appRole == null) await _roleManager.CreateAsync(new() { Name = "Employee" });
                    await _userManager.AddToRoleAsync(appUser, "Employee");
                    return RedirectToAction("Register");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SignIn(UserSignInRequestModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await _userManager.FindByNameAsync(model.UserName);

                SignInResult result = await _signInManager.PasswordSignInAsync(appUser, model.Password, true, true);
               
                if (result.Succeeded)
                {
                    IList<string> roles = await _userManager.GetRolesAsync(appUser);
                    if (roles.Contains("Manager"))
                    {
                        return RedirectToAction("Index", new { Area = "Manager" });
                    }
                    else if (roles.Contains("Employee"))
                    {
                        return RedirectToAction("EmployeePanel");
                    }
                    return RedirectToAction("Panel");
                }
                TempData["Message"] = "Kullanýcý bulunamadý";
                return RedirectToAction("SignIn");
            }

            return View(model);
        }
        [Authorize(Roles = "Manager")]
        public IActionResult ManagerPanel()
        {
            return View();
        }

        [Authorize(Roles = "Member")]
        public IActionResult MemberPanel()
        {
            return View();
        }


    }

    
}   
