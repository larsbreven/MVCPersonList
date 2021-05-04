using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models;
using MVCPersonList.Models.Data;
using MVCPersonList.Models.Service;

namespace MVCPersonList.Controllers
{
    public class HomeController : Controller
    {
     
        IPeopleService _peopleService;

        public HomeController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

       
        public IActionResult Index()                                    // Index page
        {
                                                                        // Only for demonstation purpose
            List<Person> personList = _peopleService.All().PersonList;  // Only the personlist is needed
            Person lastPerson = null;                                   // Null by default
            if(personList.Count > 0)                                    // Must be one person in the list
            {
                lastPerson = personList[personList.Count - 1];          // The last (newest) person in the list
            }                                                         
                                                                        // End of demonstration purpose

            return View(lastPerson);                                    // Last person is returned to Home Index
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
