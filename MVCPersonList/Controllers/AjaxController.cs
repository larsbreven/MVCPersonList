using Microsoft.AspNetCore.Mvc;
using MVCPersonList.Models.Data;
using MVCPersonList.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Controllers
{
    public class AjaxController : Controller
    {

        static readonly IPeopleService _peopleService = new PeopleService();

        public IActionResult Index()                                    // Go to an action
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

        [HttpGet]
        public IActionResult AllPersonsPartialView()
        {
            List<Person> personList = _peopleService.All().PersonList;  // .All() gets the ViewModel, set up the data for the viewmodel

            return PartialView("_AllPersonPartialView", personList);    // Return and send it as a partial view 
        }

        [HttpPost]
        public IActionResult DetailsPartialView(int id)
        {
            Person person = _peopleService.FindById(id);  // .All() gets the ViewModel

            return PartialView("_APersonRowPartialView", person);    // Return a partial view

            // return NotFound(); // Status code 404 premade method
            // return BadRequest(); // Status code 400
        }
    }
}
