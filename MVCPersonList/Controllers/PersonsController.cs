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
    public class PersonsController : Controller
    {

        IPersonService _personService = new PersonService();

        [HttpGet]
        public IActionResult Index()                // Normally shows all persons available here
        {
            return View(_personService.All());      // Returns a PersonIndexViewModel
        }

        [HttpPost]
        public IActionResult Index(PersonIndexViewModel indexViewModel)   // Normally shows all persons available here
        {
            indexViewModel.PersonList = _personService.FindByCity(indexViewModel.FilterText);
         
            return View(indexViewModel);            // Returns an indexViewModel
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
                _personService.Add(createPerson);

                return RedirectToAction(nameof(Index));
            }
            return View(createPerson);              // If a person is not properly created it will return back to the same view
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
