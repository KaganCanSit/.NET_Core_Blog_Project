using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    // Ekleme işlemi yapılırkem HttpGet ve HttpPost attributlerinin tanımlandığı metotların isimleri aynı olmak zorundadır.
    // HttpGet -> Sayfa Yüklenince / HttpPost -> Sayfa Buton Tetiklenince (Parametre alması gerekir.)

    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer p)
        {
            p.WriterStatus = true;
            p.WriterAbout = "Deneme Test";
            wm.WriterAdd(p);
            return RedirectToAction("Index", "Blog");
        }
    }
}
