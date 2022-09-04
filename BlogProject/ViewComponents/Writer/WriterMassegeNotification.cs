using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterMassegeNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
           return View();
        }
    }
}
