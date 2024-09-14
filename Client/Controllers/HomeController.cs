﻿using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            var html = System.IO.File.ReadAllText("wwwroot/landing.html");
            return Content(html, "text/html");
        }
    }
}
