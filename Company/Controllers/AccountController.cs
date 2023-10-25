using Company.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM login )
        {
            return RedirectToAction("Index","Home");
        }
    }
}
