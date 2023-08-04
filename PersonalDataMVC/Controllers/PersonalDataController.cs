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
            var res = ObjRepository.SelectSP(id);
            return View("Ubdate", res);
        }

        // POST: PersonalDataController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PersonalDataModel Reg)
        {
            try
            {
                Reg.id = id;
                ObjRepository.ubdate(Reg);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: Registration/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var res = ObjRepository.SelectSP(id);
            return View("Delete", res);
        }

        // POST: Registration/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int Id)
        {
            try
            {
                ObjRepository.delete(Id);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
