using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlockListWithCategory();
            return View(values);
        }
        
        public IActionResult BlogReadAll(int id)
        {
            //Blog id'sini buradan alarak yorumların getirilmesi için BlogReadAll View'inin içerisinde gönderiyoruz.
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }
    }
}
