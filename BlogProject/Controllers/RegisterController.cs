using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
            //Kontrol için oluşturduğumuz class ile bir nesne oluşturuyoruz. Oluşturduğumuz nesne aracılığyla Writer parametresini göndererek kontrol sağlıyoruz.
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);

            if(results.IsValid)
            {
                p.WriterStatus = true;
                p.WriterAbout = "Deneme Test";
                wm.WriterAdd(p);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                //Hata varsa hatanın gerçekleştiği özelliğin ismi ve hata değerini dön.
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}