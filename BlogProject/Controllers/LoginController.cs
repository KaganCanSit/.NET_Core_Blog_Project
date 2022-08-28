using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class LoginController : Controller
    {
        //Authentication Islemlerinden Muaf Ol!
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
