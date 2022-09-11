using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterMassegeNotification : ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());

        public IViewComponentResult Invoke()
        {
            //Session eklendiğinde değiştirilecek
            string p = "kagancansit@hotmail.com";
            var values = mm.GetInboxListByWriter(p);
           return View(values);
        }
    }
}
