using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        
        //Mesajların Tamamı
        public IActionResult InBox()
        {
            int id = 1;
            var values = mm.GetInboxListByWriter(id);
            return View(values);
        }


        public IActionResult MessageDetails(int id)
        {
            //Kategori ID yerine kategori isimlerini yazdırılması
            var value = mm.TGetById(id);
            return View(value);
        }
    }
}
