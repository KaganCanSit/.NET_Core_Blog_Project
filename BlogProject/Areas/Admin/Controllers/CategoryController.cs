using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
//Listeleme islemi icin ekledigimiz Nuget paketi
using X.PagedList;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            //Sayfalamanin baslayacagi ve sayfada bulunan deger sayisi
            var values = cm.GetList().ToPagedList(page,5);
            return View(values);
        }
    }
}
