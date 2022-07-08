using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    // Ekleme işlemi yapılırkem HttpGet ve HttpPost attributlerinin tanımlandığı metotların isimleri aynı olmak zorundadır.
    // HttpGet -> Sayfa Yüklenince / HttpPost -> Sayfa Buton Tetiklenince (Parametre alması gerekir.)

    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
    }
}
