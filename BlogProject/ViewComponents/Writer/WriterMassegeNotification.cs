using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterMassegeNotification : ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());

        public IViewComponentResult Invoke()
        {
            //Session eklendiğinde değiştirilecek
            int id = 1;
            var values = mm.GetInboxListByWriter(id);
           return View(values);
        }
    }
}
