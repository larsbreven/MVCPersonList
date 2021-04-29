using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExampleOne(string messageText)             // Get a form from the Index-page that trigger ExampleOne
        {
            ViewBag.Msg = messageText;                                  // Gets the dynamic ViewBag with the text in the string "messageText"
            return View("Index");                                       // The view will navigate to Index
        }

        public IActionResult ExampleTwo(string messageText)             // Get a form from the Index-page that trigger ExampleTwo
        {
            ViewBag.Msg = messageText;                                  // Gets the dynamic ViewBag with the text in the string "messageText"
            return RedirectToAction("Index");                           // The "messagetext" will be redirected to Index and reload the full page
        }
    }
}
