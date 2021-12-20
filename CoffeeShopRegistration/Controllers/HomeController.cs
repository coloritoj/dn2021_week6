using CoffeeShopRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopRegistration.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult RegistrationConfirmation(string first, string last, string email, string password)
        {
            if(password.Length >= 8 && password.Contains("!") || password.Contains("#") || password.Contains("%"))
            {
                ViewBag.first = first;
                ViewBag.last = last;
                ViewBag.email = email;
                ViewBag.password = password;
                HomeController.username = $"{first} {last}";
                return View();
            }
            else
            {
                return View("ErrorPage");
            }

        }

        public IActionResult ErrorPage()
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
