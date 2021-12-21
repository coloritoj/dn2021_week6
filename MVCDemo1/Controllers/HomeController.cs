using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCDemo1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo1.Controllers
{
    public class HomeController : Controller
    {
        public static string username = "";


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            ViewBag.RightNow = DateTime.Now;
            return View();
        }

        public IActionResult GetForm()
        {
            return View();
        }

        // [HttpGet] or [HttpPost] to make them accept one or the other. Put right above the FormResponse. If you don't put either, it accepts both.
        // By default, all links you click are Gets. Posts really only come into play when you're entering data.
        // ... Get put the form info in the URL and work it from there
        // ... Post means the form data goes through the form data into the function
        // ... The majority of what happens on a website is a Get.
        public IActionResult FormResponse(string first, string last, string pword)
        {
            if (first == "Sally" || first == "Fred")
            {
                ViewBag.first = first;
                ViewBag.last = last;
                ViewBag.pword = pword;
                HomeController.username = $"{first} {last}";
                return View();
            }
            else
            {
                return View("FormError");
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
