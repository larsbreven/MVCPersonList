using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Data;
using MVCPersonList.Models.Service;
using MVCPersonList.Models.ViewModel;

namespace MVCPersonList.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IPeopleService _peopleService;

        public CityController(ICityService cityService, IPeopleService peopleService)
        {
            this._cityService = cityService;
            this._peopleService = peopleService;
        }


        // GET: CityController
        public ActionResult Index()
        {
            return View(_cityService.All());            // List of all cities
        }

        // GET: CityController/Details/5
        public ActionResult Details(int id)
        {
            City city = _cityService.FindById(id);

            if (city == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            CreateCity createCity = new CreateCity();
            createCity.PersonList = _peopleService.All().PersonList;

            return View(createCity);
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]                      // Antipirate - feature
        public ActionResult Create(CreateCity createCity)       // Use the modelbinder here
        {
            if(ModelState.IsValid)
            {
                _cityService.Add(createCity);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createCity);                        // If it fails send it back to ActionResult Create
            }
        }

        // GET: CityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]                        // Antipirate - feature
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
