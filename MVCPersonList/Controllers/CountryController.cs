﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Service;
using MVCPersonList.Models.ViewModel;

namespace MVCPersonList.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }


        public IActionResult Index()
        {
            return View(_countryService.All());
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCountry createCountry)
        {
            if (ModelState.IsValid)
            {
                _countryService.Add(createCountry);
                return RedirectToAction(nameof(Index));
            }
            return View(createCountry);
        }
    }
}
