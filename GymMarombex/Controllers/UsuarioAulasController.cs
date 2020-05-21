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
    public class UsuarioAulasController : Controller
    {
        private EFContext db = new EFContext();

        // GET: UsuarioAulas
        public ActionResult Index()
        {
            var usuarioAula = db.UsuarioAula.Include(u => u.Aulas).Include(u => u.Usuarios);
            return View(usuarioAula.ToList());
        }

        // GET: UsuarioAulas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioAula usuarioAula = db.UsuarioAula.Find(id);
            if (usuarioAula == null)
            {
                return HttpNotFound();
            }
            return View(usuarioAula);
        }

        // GET: UsuarioAulas/Create
        public ActionResult Create()
        {
            ViewBag.AulaID = new SelectList(db.Aulas, "AulaID", "Descricao");
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nome");
            return View();
        }

        // POST: UsuarioAulas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioAulaID,UsuarioID,AulaID")] UsuarioAula usuarioAula)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioAula.Add(usuarioAula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AulaID = new SelectList(db.Aulas, "AulaID", "Descricao", usuarioAula.AulaID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nome", usuarioAula.UsuarioID);
            return View(usuarioAula);
        }

        // GET: UsuarioAulas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioAula usuarioAula = db.UsuarioAula.Find(id);
            if (usuarioAula == null)
            {
                return HttpNotFound();
            }
            ViewBag.AulaID = new SelectList(db.Aulas, "AulaID", "Descricao", usuarioAula.AulaID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nome", usuarioAula.UsuarioID);
            return View(usuarioAula);
        }

        // POST: UsuarioAulas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioAulaID,UsuarioID,AulaID")] UsuarioAula usuarioAula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioAula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AulaID = new SelectList(db.Aulas, "AulaID", "Descricao", usuarioAula.AulaID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nome", usuarioAula.UsuarioID);
            return View(usuarioAula);
        }

        // GET: UsuarioAulas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioAula usuarioAula = db.UsuarioAula.Find(id);
            if (usuarioAula == null)
            {
                return HttpNotFound();
            }
            return View(usuarioAula);
        }

        // POST: UsuarioAulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioAula usuarioAula = db.UsuarioAula.Find(id);
            db.UsuarioAula.Remove(usuarioAula);
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
