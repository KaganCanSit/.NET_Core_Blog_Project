using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic2 : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            //Bloglari sirala en daha sonra listenin sonundakini al.
            ViewBag.v1 = c.Blogs.OrderByDescending(X=>X.BlogID).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.v2 = c.Comments.Count();
            return View();
        }
    }
}
