﻿using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Areas.Admin.Controllers
{
    public class AdminCommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}