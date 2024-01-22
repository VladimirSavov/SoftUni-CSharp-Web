using Microsoft.AspNetCore.Mvc;
using MusicSystem.Data;
using MusicSystem.Entities;
using MusicSystem.ExtensionMethods;
using MusicSystem.ViewModels.Home;
using MusicSystem.ViewModels.User;

namespace MusicSystem.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            MusicSystemDbContext context = new MusicSystemDbContext();
            Users loggedUser = context.Users.Where(u => u.Username == model.Username
                                                      && u.Password == model.Password).FirstOrDefault();

            if (loggedUser == null)
            {
                this.ModelState.AddModelError("authErr", "Wrong Credentials");
                return View(model);
            }

            HttpContext.Session.SetObject("loggedUser", loggedUser);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        // GET: Albums/Create
        public IActionResult Register(CreateVM model)
        {
            if (!ModelState.IsValid) { return View(model); }
            if(model.Password != model.ConfirmPassword)
            {
                this.ModelState.AddModelError("authErr", "Wrong Credentials");
                return View(model);
            }
            MusicSystemDbContext context = new MusicSystemDbContext();
            Users loggedUser = new Users();
            loggedUser.Username = model.Username;
            loggedUser.Password = model.Password;

            context.Users.Add(loggedUser);
            context.SaveChanges();

            HttpContext.Session.SetObject("loggedUser", loggedUser);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {

            HttpContext.Session.Remove("loggedUser");
            return RedirectToAction("Index", "Home");

        }
    }
}
