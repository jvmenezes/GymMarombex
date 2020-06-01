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
    public class AlunoAulasController : Controller
    {
        private EFContext db = new EFContext();

        // GET: AlunoAulas
        public ActionResult Index()
        {
            var alunoAula = db.AlunoAula.Include(a => a.Alunos).Include(a => a.Aulas);
            return View(alunoAula.ToList());
        }

        // GET: AlunoAulas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoAula alunoAula = db.AlunoAula.Find(id);
            if (alunoAula == null)
            {
                return HttpNotFound();
            }
            return View(alunoAula);
        }

        // GET: AlunoAulas/Create
        public ActionResult Create()
        {
            ViewBag.AlunoID = new SelectList(db.Alunos, "AlunoID", "Nome");
            ViewBag.AulaID = new SelectList(db.Aulas, "AulaID", "Descricao");
            return View();
        }

        // POST: AlunoAulas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlunoAulaID,AulaID,AlunoID")] AlunoAula alunoAula)
        {
            if (ModelState.IsValid)
            {
                db.AlunoAula.Add(alunoAula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlunoID = new SelectList(db.Alunos, "AlunoID", "Nome", alunoAula.AlunoID);
            ViewBag.AulaID = new SelectList(db.Aulas, "AulaID", "Descricao", alunoAula.AulaID);
            return View(alunoAula);
        }

        // GET: AlunoAulas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoAula alunoAula = db.AlunoAula.Find(id);
            if (alunoAula == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlunoID = new SelectList(db.Alunos, "AlunoID", "Nome", alunoAula.AlunoID);
            ViewBag.AulaID = new SelectList(db.Aulas, "AulaID", "Descricao", alunoAula.AulaID);
            return View(alunoAula);
        }

        // POST: AlunoAulas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlunoAulaID,AulaID,AlunoID")] AlunoAula alunoAula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alunoAula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlunoID = new SelectList(db.Alunos, "AlunoID", "Nome", alunoAula.AlunoID);
            ViewBag.AulaID = new SelectList(db.Aulas, "AulaID", "Descricao", alunoAula.AulaID);
            return View(alunoAula);
        }

        // GET: AlunoAulas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoAula alunoAula = db.AlunoAula.Find(id);
            if (alunoAula == null)
            {
                return HttpNotFound();
            }
            return View(alunoAula);
        }

        // POST: AlunoAulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlunoAula alunoAula = db.AlunoAula.Find(id);
            db.AlunoAula.Remove(alunoAula);
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
