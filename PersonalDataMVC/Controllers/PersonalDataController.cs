using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalDataMVC.Repository;
using PersonalDataMVC.Models;



namespace PersonalDataMVC.Controllers
{
    public class PersonalDataController : Controller
    {
        // GET: PersonalDataController

        PersonalBioRepository ObjRepository;

        public PersonalDataController()
        {
            ObjRepository = new PersonalBioRepository();
        }

        public ActionResult List()
        {
            return View("Select", ObjRepository.Select());
        }

        // GET: Registration/Details/5
        public ActionResult Details(int id)
        {
            var res = ObjRepository.SelectSP(id);
            return View("Details", res);
        }

        // GET: PersonalDataController/Create
        public ActionResult InsertRecord()
        {
            return View("Insert", new PersonalDataModel());
        }

        // POST: PersonalDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonalDataModel data)
        {
            try
            {
                ObjRepository.InsertPersonalData(data);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonalDataController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonalDataController/Edit/5
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

        // GET: PersonalDataController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonalDataController/Delete/5
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
