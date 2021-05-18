using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCPersonList.Models.Service;
using MVCPersonList.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        // GET: InsuranceController
        public ActionResult Index()
        {
            return View(_languageService.All());
        }

        // GET: InsuranceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InsuranceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsuranceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLanguage createLanguage)
        {
            if(ModelState.IsValid)
            {
                _languageService.Add(createLanguage);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createLanguage);
            }
        }

        // GET: InsuranceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InsuranceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: InsuranceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InsuranceController/Delete/5
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
