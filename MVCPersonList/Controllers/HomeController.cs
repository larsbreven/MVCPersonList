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

        public IActionResult Index()                                    // Index page, this is the first page shown
        {
                                                                            // Only for demonstation purpose
            List<Person> indexPersonList = _peopleService.All().PersonList; // Only the personlist is needed
            Person lastPerson = null;                                       // Null by default
            if (indexPersonList.Count > 0)                                  // Must be one person in the list
            {
                lastPerson = indexPersonList[indexPersonList.Count - 1];    // The last (newest) person in the list
            }                                                               // End of demonstration purpose

            return View(lastPerson);                                    // Last person is returned to Home Index
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
