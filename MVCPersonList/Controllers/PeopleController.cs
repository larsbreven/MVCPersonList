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
    public class PeopleController : Controller
    {

        IPeopleService _peopleService;
        private readonly IPersonGroupRepo _personGroupRepo;

        public PeopleController(IPeopleService peopleService, IPersonGroupRepo personGroupRepo)           // Constructor dependency injection
        {
            _peopleService = peopleService;
            _personGroupRepo = personGroupRepo;
        }

        [HttpGet]
        public IActionResult Index()                                    // Normally shows all persons available here
        {
            return View(_peopleService.All());                          // Returns a PersonIndexViewModel
        }

        [HttpPost]
        public IActionResult Index(PersonIndexViewModel indexViewModel) // Normally shows all filtered persons here
        {
            indexViewModel.PersonList = _peopleService.FindByName(indexViewModel.FilterText);
         
            return View(indexViewModel);                                // Returns an indexViewModel
        }
            
        
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreatePerson(_personGroupRepo));
        }
        
        [HttpPost]
        public IActionResult Create(CreatePerson createPerson)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(createPerson);

                return RedirectToAction(nameof(Index));
            }

            PersonIndexViewModel personIndexView = new PersonIndexViewModel();
            personIndexView.CreatePerson = createPerson;
            personIndexView.PersonList = new List<Person>();


            return View("Index", personIndexView);              // If a person is not properly created it will return back to the same view
        
            
        }


        public IActionResult Details(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            return View(person);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            EditPerson editPerson = new EditPerson();
            editPerson.Id = id;
            editPerson.CreatePerson = _peopleService.PersonToCreatePerson(person);

            return View(editPerson);
        }

        [HttpPost]
        public IActionResult Edit(int id, CreatePerson createPerson)
        {
            if (ModelState.IsValid)
            {
                Person person = _peopleService.Edit(id, createPerson);

                return RedirectToAction(nameof(Index));
            }

            EditPerson editPerson = new EditPerson();
            editPerson.Id = id;
            editPerson.CreatePerson = createPerson;

            return View(editPerson);
        }
    }
}
