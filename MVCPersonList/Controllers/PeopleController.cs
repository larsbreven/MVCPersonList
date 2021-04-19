using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.ViewModel;

namespace MVCPersonList.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()                // Normally shows all persons available
        {
            return View();
        }


        [HttpGet]                                   // Create a new person to the list
        public IActionResult Create()                
        {
            return View(new CreatePerson());
        }
        [HttpPost]
        public IActionResult Create(CreatePerson createPerson)
        {
            if (ModelState.IsValid)
            {
                // code save person
            }
            return View(createPerson); // If a person is not properly created it will return back to the same view
        }



    }
}
