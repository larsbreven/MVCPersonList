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

        IPeopleService _peopleService;

        public AjaxController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }


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
            Person person = _peopleService.FindById(id);                // .All() gets the ViewModel

            if (person == null)                                         // If there is no person in the list
            {
                return NotFound();                                      // Status code 404 (premade method)
            }

            return PartialView("_APersonRowPartialView", person);       // Return a partial view

        }

        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return NotFound();//404
            }

            if (_peopleService.Remove(id))
            {
                return Ok("person" + id);//200
            }

            return BadRequest();
        }

    }
}
