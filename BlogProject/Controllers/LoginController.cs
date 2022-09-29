using BlogProject.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProject.Controllers
{
    [AllowAnonymous] //Authentication Islemlerinden Muaf Ol!
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if(ModelState.IsValid)
            {
                //Kullanıcı  adı - sifre - cerezlerde hatirlasin - yanlis girme durumu(engel)
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }
    }
}
