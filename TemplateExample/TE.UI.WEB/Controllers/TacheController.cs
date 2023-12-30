using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TE.Core.Domain;
using TE.Core.Services;

namespace TE.UI.WEB.Controllers
{
    public class TacheController : Controller
    {
        readonly IService<Tache> tacheservice;
        public TacheController(IService<Tache> tacheservice)
        {
            this.tacheservice = tacheservice;
        }
        // GET: TacheController
        public ActionResult Index()
        {
            return View(tacheservice.GetAll()
                .Where(h=>h.Etat==EtatTache.Ouvert)
                .OrderBy(h => h.Titre));
        }

        // GET: TacheController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult houssem(string id)
        {
            return View(tacheservice.GetAll()
                .Where(h => h.MembreKey == id)
                .Select(h => h.MyMembre).First());
        }

        // GET: TacheController/Create
        public ActionResult Create()
        {
            var houssem = tacheservice.GetAll();
            ViewBag.e = new SelectList(houssem, "Etat", "Etat");
            ViewBag.s = new SelectList(houssem, "SprintKey", "SprintKey");
            ViewBag.m = new SelectList(houssem, "MembreKey", "MembreKey");
            return View();
        }

        // POST: TacheController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection,Tache houssem)
        {
            try
            {
                tacheservice.Add(houssem);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TacheController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TacheController/Edit/5
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

        // GET: TacheController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TacheController/Delete/5
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
