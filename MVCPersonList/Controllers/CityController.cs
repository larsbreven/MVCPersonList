using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Data;
using MVCPersonList.Models.Repo;
using MVCPersonList.Models.Service;
using MVCPersonList.Models.ViewModel;

namespace MVCPersonList.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly IPeopleRepo _peopleRepo;


        public CityController(IPeopleRepo peopleRepo, ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
            _peopleRepo = peopleRepo;
        }

        public IActionResult Index()                     // 
        {
            return View(_cityService.All());            // "All" provides a list of all cities from CityService
        }

        //// GET: CityController/Details/5
        //public ActionResult Details(int id)
        //{
        //    City city = _cityService.FindById(id);

        //    if (city == null)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(city);
        //}

        public IActionResult Create()                    // This is the first to be called
        {
            CreateCity createCity = new CreateCity();
            createCity.CountryList = _countryService.All();

            return View(createCity);
        }

        // POST: CityController/Create

        public IActionResult Create(CreateCity createCity)       // This is the second to be called
        {
            if (ModelState.IsValid)
            {
                _cityService.Add(createCity);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createCity);                        // If it fails send it back to ActionResult Create
            }
        }


    }
}
