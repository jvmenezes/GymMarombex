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
    public class AulasController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Aulas
        public ActionResult Index()
        {
            var aulas = db.Aulas.Include(a => a.Funcionarios);
            return View(aulas.ToList());
        }

        // GET: Aulas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aulas aulas = db.Aulas.Find(id);
            if (aulas == null)
            {
                return HttpNotFound();
            }
            return View(aulas);
        }

        // GET: Aulas/Create
        public ActionResult Create()
        {
            ViewBag.InstrutorID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome");
            return View();
        }

        // POST: Aulas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AulaID,Descricao,HoraInicio,DuracaoMinutos,DiasDaSemana,InstrutorID")] Aulas aulas)
        {
            if (ModelState.IsValid)
            {
                db.Aulas.Add(aulas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstrutorID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", aulas.InstrutorID);
            return View(aulas);
        }

        // GET: Aulas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aulas aulas = db.Aulas.Find(id);
            if (aulas == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstrutorID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", aulas.InstrutorID);
            return View(aulas);
        }

        // POST: Aulas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AulaID,Descricao,HoraInicio,DuracaoMinutos,DiasDaSemana,InstrutorID")] Aulas aulas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aulas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstrutorID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", aulas.InstrutorID);
            return View(aulas);
        }

        // GET: Aulas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aulas aulas = db.Aulas.Find(id);
            if (aulas == null)
            {
                return HttpNotFound();
            }
            return View(aulas);
        }

        // POST: Aulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aulas aulas = db.Aulas.Find(id);
            db.Aulas.Remove(aulas);
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
