﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Data;
using MVCPersonList.Models.Service;
using MVCPersonList.Models.ViewModel;

namespace MVCPersonList.Controllers
{
    public class PeopleController : Controller
    {

        IPeopleService _personService = new PeopleService();

        [HttpGet]
        public IActionResult Index()                // Normally shows all persons available here
        {
            return View(_personService.All());      // Returns a PersonIndexViewModel
        }

        [HttpPost]
        public IActionResult Index(PersonIndexViewModel indexViewModel)   // Normally shows all filtered persons here
        {
            indexViewModel.PersonList = _personService.FindByCity(indexViewModel.FilterText);
         
            return View(indexViewModel);            // Returns an indexViewModel
        }
               
        
        [HttpPost]
        public IActionResult Create(CreatePerson createPerson)
        {
            if (ModelState.IsValid)
            {
                _personService.Add(createPerson);

                return RedirectToAction(nameof(Index));
            }

            PersonIndexViewModel personIndexView = new PersonIndexViewModel();
            personIndexView.CreatePerson = createPerson;
            personIndexView.PersonList = new List<Person>();


            return View("Index", personIndexView);              // If a person is not properly created it will return back to the same view
        
            
        }


        public IActionResult Details(int id)
        {
            Person person = _personService.FindByID(id);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            return View(person);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Person person = _personService.FindByID(id);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            EditPerson editPerson = new EditPerson();
            editPerson.Id = id;
            editPerson.CreatePerson = _personService.PersonToCreatePerson(person);

            return View(editPerson);
        }

        [HttpPost]
        public IActionResult Edit(int id, CreatePerson createPerson)
        {
            if (ModelState.IsValid)
            {
                Person person = _personService.Edit(id, createPerson);

                return RedirectToAction(nameof(Index));
            }

            EditPerson editPerson = new EditPerson();
            editPerson.Id = id;
            editPerson.CreatePerson = createPerson;

            return View(editPerson);
        }
    }
}
