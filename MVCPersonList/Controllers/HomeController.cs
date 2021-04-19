using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCPersonList.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;               // Diagnostic tool

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()                                    // Index page
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
