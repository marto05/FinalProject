using LDBeauty.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LDBeauty.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return View("Status404");
                case 500:
                    return View("Status500");
                default:
                    return View("Status500");
            }
        }
    }
}