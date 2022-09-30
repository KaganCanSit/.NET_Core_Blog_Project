using BlogProject.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]

    public class AdminMessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
        public AdminMessageController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerID);

            return View(values);
        }
        
        public IActionResult Sendbox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetSendBoxListByWriter(writerID);

            return View(values);
        }
        
        
        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ComposeMessage(Message2 model)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            model.SenderID = writerID;
            model.ReceiverID = 2;
            model.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            model.MessageStatus = true;
            model.Subject = model.Subject;
            mm.TAdd(model);

            return RedirectToAction("Sendbox", "AdminMessage");
        }

        /*
        [HttpPost]
        public IActionResult ComposeMessage(SendMessageModelView model)
        {
            
            Message2 message = new Message2();
            var reciever = _userManager.FindByEmailAsync(model.Email);

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            message.SenderID = writerID;
            message.ReceiverID = reciever.Id;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.MessageStatus = false;
            message.Subject = model.Subject;
            message.MessageDetails = model.Detail;
            message.IsDelete = false;
            mm.TAdd(message);

            return RedirectToAction("Sendbox", "AdminMessage");
        }
        
        public async Task<IActionResult> MessageDetail(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var inboxMessageCount = mm.GetInboxListByWriter(user.Id).Count();
            var sendMessageCount = mm.GetSendboxListByWriter(user.Id).Count();
            ViewBag.imc = inboxMessageCount;
            ViewBag.smc = sendMessageCount;

            var value = mm.TGetById(id);
            if (value.MessageStatus == false)
            {
                value.MessageStatus = true;
                mm.TUpdate(value);
            }

            return View(value);
        }*/

    }
}
