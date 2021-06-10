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
        private readonly IPeopleService _peopleService;
        private readonly ILanguageService _languageService;
        private readonly IPersonLanguageRepo _personLanguageRepo;
        private readonly IPersonGroupRepo _personGroupRepo;
        private readonly ICityService _cityService;

        public PeopleController(IPeopleService peopleService,                       // Constructor dependency injection
            ILanguageService languageService,
            IPersonLanguageRepo personLanguageRepo,
            IPersonGroupRepo personGroupRepo,
            ICityService cityService)           
        {
            _peopleService = peopleService;
            _languageService = languageService;
            _personLanguageRepo = personLanguageRepo;
            _personGroupRepo = personGroupRepo;
            _cityService = cityService;
        }
// ----------------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]                                                       // The method will only respond to the get request
        public IActionResult Index()                                    // Normally shows all persons available here
        {
            return View(_peopleService.All());                          // Returns the created ViewResult for the response
        }

        [HttpPost]                                                      // The method will only respond to the post request
        public IActionResult Index(PersonIndex indexViewModel)          // Normally shows all filtered persons here
        {
            indexViewModel.PersonList = _peopleService.FindByName(indexViewModel.FilterText);
            return View(indexViewModel);                                // Returns an indexViewModel
        }


        [HttpGet]   
        public IActionResult Create()                                   
        {
            return View(new CreatePerson(_cityService));
        }

        [HttpPost]
        public IActionResult Create(CreatePerson createPerson)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(createPerson);

                return RedirectToAction(nameof(Index));
            }
            PersonIndex personIndexView = new PersonIndex();
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
        public IActionResult ManagePersonLanguage(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            PersonLanguagesVM vm = new PersonLanguagesVM();
            vm.Person = person;
            vm.Languages = _languageService.All();

            return View(vm);
        }

        [HttpGet]
        public IActionResult AddLanguageToPerson(int personId, int languageId)  //  personId and languageId is needed for the binding
        {
            Person person = _peopleService.FindById(personId);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            PersonLanguage personLanguage = _personLanguageRepo.Create(
                new PersonLanguage() { PersonId = personId, LanguageId = languageId }
                );

            return RedirectToAction("ManagePersonLanguages", new { id = personId });
        }

        [HttpGet]
        public IActionResult RemoveLanguageToPerson(int personId, int languageId)  //  personId and languageId is needed for the binding
        {
            Person person = _peopleService.FindById(personId);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            _personLanguageRepo.Delete(personId, languageId);

            return RedirectToAction("ManagePersonLanguages", new { id = personId });
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