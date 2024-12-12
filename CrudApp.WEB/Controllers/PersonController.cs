using CrudApp.DAL.Context;
using CrudApp.DAL.Interfaces;
using CrudApp.DAL.Models.Person;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.WEB.Controllers
{
    public class PersonController : Controller
    {
        private readonly IDaoPerson _daoPerson;
        
        public PersonController(IDaoPerson daoPerson)
        {
            _daoPerson = daoPerson;
        }


        // GET: PersonController
        public ActionResult Index()
        {
            var Persons = _daoPerson.GetAll();
            return View(Persons);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            var PersonByID = _daoPerson.GetByID(id);
            return View(PersonByID);
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonCreateModel personCreate)
        {
            try
            {
                _daoPerson.Create(personCreate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            var getPersonByid = _daoPerson.GetByID(id);
            return View(getPersonByid);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GetPersonModel personUpdate)
        {
            try
            {
                _daoPerson.Update(personUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            var DeletePerson = _daoPerson.GetByID(id);
            return View(DeletePerson);
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(GetPersonModel personRemove)
        {
            try
            {
                _daoPerson.Delete(personRemove);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
