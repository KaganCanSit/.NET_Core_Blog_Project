using BlogProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID = 1,
                    Username = "Kağan"
                },
                new UserComment
                {
                    ID = 2,
                    Username = "Mesut"
                },
                new UserComment
                {
                    ID = 3,
                    Username = "Merve"
                }
            };
            return View(commentValues);
        }
    }
}
