using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TripAdvisory_.Models;
using PagedList;

namespace Tripadvisory_.Controllers
{
    public class BienViewModelController : Controller
    {
        private TripAdvisorEntities db = new TripAdvisorEntities();
        int pageSize = 5;

        // GET: BienViewModel
        public ActionResult Index(int? page, string CodeBien, string LibelleBien)
        {
            ViewBag.LibelleBien = string.IsNullOrEmpty(LibelleBien) ? string.Empty : LibelleBien;
            ViewBag.CodeBien = string.IsNullOrEmpty(CodeBien) ? string.Empty : CodeBien;
            List<BienViewModel> liste = new List<BienViewModel>();
            var list = db.Biens.ToList();

            if (!string.IsNullOrEmpty(CodeBien))
            {
                list = list.Where(a => a.code.ToUpper() == CodeBien.ToUpper()).ToList();
            }
            if (!string.IsNullOrEmpty(LibelleBien))
            {
                list = list.Where(a => a.libelle.ToUpper().Contains(LibelleBien.ToUpper())).ToList();
            }

            foreach (var i in list)
            {
                BienViewModel t = new BienViewModel();
                t.id = i.id;
                t.code = i.code;
                t.libelle = i.libelle;
                t.prix_unitaire = i.prix_unitaire;
                t.nbr_places_dispo = (int)i.nbr_places_dispo;
                t.nbr_places_total = (int)i.nbr_places_total;
                liste.Add(t);

            }
            page = page.HasValue ? page : 1;
            return View(liste.ToPagedList((int)page, pageSize));
        }

        // GET: BienViewModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var i = db.Biens.Find(id);
            BienViewModel bienViewModel = new BienViewModel();
            bienViewModel.id = i.id;
            bienViewModel.code = i.code;
            bienViewModel.libelle = i.libelle;
            bienViewModel.prix_unitaire = i.prix_unitaire;
            bienViewModel.nbr_places_dispo = (int)i.nbr_places_dispo;
            bienViewModel.nbr_places_total = (int)i.nbr_places_total;
            if (bienViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bienViewModel);
        }

        // GET: BienViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BienViewModel/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,code,libelle,prix_unitaire,nbr_places_dispo,nbr_places_total")] BienViewModel bienViewModel)
        {
            if (ModelState.IsValid)
            {
                Bien t = new Bien();
                t.code = bienViewModel.code;
                t.libelle = bienViewModel.libelle;
                t.prix_unitaire = bienViewModel.prix_unitaire;
                t.nbr_places_dispo = (int)bienViewModel.nbr_places_dispo;
                t.nbr_places_total = (int)bienViewModel.nbr_places_total;
                db.Biens.Add(t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bienViewModel);
        }

        // GET: BienViewModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var i = db.Biens.Find(id);
            BienViewModel bienViewModel = new BienViewModel();
            bienViewModel.id = i.id;
            bienViewModel.code = i.code;
            bienViewModel.libelle = i.libelle;
            bienViewModel.prix_unitaire = i.prix_unitaire;
            bienViewModel.nbr_places_dispo = (int)i.nbr_places_dispo;
            bienViewModel.nbr_places_total = (int)i.nbr_places_total;
            //BienViewModel bienViewModel = db.BienViewModel.Find(id);
            if (bienViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bienViewModel);
        }

        // POST: BienViewModel/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,code,libelle,prix_unitaire,nbr_places_dispo,nbr_places_totaln")] BienViewModel bienViewModel)
        {
            if (ModelState.IsValid)
            {
                Bien t = db.Biens.Find(bienViewModel.id);
                t.id = bienViewModel.id;
                t.code = bienViewModel.code;
                t.libelle = bienViewModel.libelle;
                t.prix_unitaire = bienViewModel.prix_unitaire;
                t.nbr_places_dispo = (int)bienViewModel.nbr_places_dispo;
                t.nbr_places_total = (int)bienViewModel.nbr_places_total;
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bienViewModel);
        }

        // GET: BienViewModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var i = db.Biens.Find(id);
            BienViewModel bienViewModel = new BienViewModel();
            //BienViewModel bienViewModel = db.BienViewModel.Find(id);
            if (bienViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bienViewModel);
        }

        // POST: BienViewModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //BienViewModel bienViewModel = db.BienViewModel.Find(id);
            Bien t = db.Biens.Find(id);
            db.Biens.Remove(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
