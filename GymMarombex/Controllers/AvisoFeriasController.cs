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
    public class AvisoFeriasController : BaseController {
        private EFContext db = new EFContext();

        // GET: AvisoFerias
        public ActionResult Index()
        {
            return View(db.AvisoFerias.ToList());
        }

        // GET: AvisoFerias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvisoFerias avisoFerias = db.AvisoFerias.Find(id);
            if (avisoFerias == null)
            {
                return HttpNotFound();
            }
            return View(avisoFerias);
        }

        // GET: AvisoFerias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvisoFerias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AvisoFeriasID,DescricaoMotivo,DataInicio,DataFim")] AvisoFerias avisoFerias)
        {
            if (ModelState.IsValid)
            {
                db.AvisoFerias.Add(avisoFerias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(avisoFerias);
        }

        // GET: AvisoFerias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvisoFerias avisoFerias = db.AvisoFerias.Find(id);
            if (avisoFerias == null)
            {
                return HttpNotFound();
            }
            return View(avisoFerias);
        }

        // POST: AvisoFerias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AvisoFeriasID,DescricaoMotivo,DataInicio,DataFim")] AvisoFerias avisoFerias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avisoFerias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(avisoFerias);
        }

        // GET: AvisoFerias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvisoFerias avisoFerias = db.AvisoFerias.Find(id);
            if (avisoFerias == null)
            {
                return HttpNotFound();
            }
            return View(avisoFerias);
        }

        // POST: AvisoFerias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AvisoFerias avisoFerias = db.AvisoFerias.Find(id);
            db.AvisoFerias.Remove(avisoFerias);
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
