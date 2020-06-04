using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GymMarombex.DAL;
using GymMarombex.Models;

namespace GymMarombex.Controllers
{
    public class FormasPagmtosController : BaseController {
        private EFContext db = new EFContext();

        // GET: FormasPagmtos
        public ActionResult Index()
        {
            return View(db.FormasPagmtos.ToList());
        }

        // GET: FormasPagmtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormasPagmtos formasPagmtos = db.FormasPagmtos.Find(id);
            if (formasPagmtos == null)
            {
                return HttpNotFound();
            }
            return View(formasPagmtos);
        }

        // GET: FormasPagmtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormasPagmtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormaPagmtoID,Descricao")] FormasPagmtos formasPagmtos)
        {
            if (ModelState.IsValid)
            {
                db.FormasPagmtos.Add(formasPagmtos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formasPagmtos);
        }

        // GET: FormasPagmtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormasPagmtos formasPagmtos = db.FormasPagmtos.Find(id);
            if (formasPagmtos == null)
            {
                return HttpNotFound();
            }
            return View(formasPagmtos);
        }

        // POST: FormasPagmtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormaPagmtoID,Descricao")] FormasPagmtos formasPagmtos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formasPagmtos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formasPagmtos);
        }

        // GET: FormasPagmtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormasPagmtos formasPagmtos = db.FormasPagmtos.Find(id);
            if (formasPagmtos == null)
            {
                return HttpNotFound();
            }
            return View(formasPagmtos);
        }

        // POST: FormasPagmtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormasPagmtos formasPagmtos = db.FormasPagmtos.Find(id);
            db.FormasPagmtos.Remove(formasPagmtos);
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
