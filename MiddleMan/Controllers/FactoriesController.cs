using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiddleMan.DAL;

namespace MiddleMan.Controllers
{
    public class FactoriesController : Controller
    {
        private MiddleManDbEntities db = new MiddleManDbEntities();

        // GET: Factories
        public ActionResult Index()
        {
            return View(db.Factories.ToList());
        }

        // GET: Factories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factories factories = db.Factories.Find(id);
            if (factories == null)
            {
                return HttpNotFound();
            }
            return View(factories);
        }

        // GET: Factories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Factories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FactoryId,Name,Address,ABN,LegalName,isDeleted,CreatedDate,ModifiedDate")] Factories factories)
        {
            if (ModelState.IsValid)
            {
                db.Factories.Add(factories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(factories);
        }

        // GET: Factories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factories factories = db.Factories.Find(id);
            if (factories == null)
            {
                return HttpNotFound();
            }
            return View(factories);
        }

        // POST: Factories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FactoryId,Name,Address,ABN,LegalName,isDeleted,CreatedDate,ModifiedDate")] Factories factories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(factories);
        }

        // GET: Factories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factories factories = db.Factories.Find(id);
            if (factories == null)
            {
                return HttpNotFound();
            }
            return View(factories);
        }

        // POST: Factories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factories factories = db.Factories.Find(id);
            db.Factories.Remove(factories);
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
