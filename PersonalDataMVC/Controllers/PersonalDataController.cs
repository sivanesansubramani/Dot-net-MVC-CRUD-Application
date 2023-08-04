using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonalDataMVC.Controllers
{
    public class PersonalDataController : Controller
    {
        // GET: PersonalDataController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonalDataController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonalDataController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
