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
    public class UsuariosController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.DadoFinanceiros).Include(u => u.Perfis);
            return View(usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.DadoFinanceiroID = new SelectList(db.DadoFinanceiros, "DadoFinanceiroID", "DadoFinanceiroID");
            ViewBag.PerfilID = new SelectList(db.Perfis, "PerfilID", "Descricao");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioID,Nome,CPF,RG,Endereco,Login,Senha,DataCadastro,DataUltimoAcesso,PerfilID,DadoFinanceiroID")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DadoFinanceiroID = new SelectList(db.DadoFinanceiros, "DadoFinanceiroID", "DadoFinanceiroID", usuarios.DadoFinanceiroID);
            ViewBag.PerfilID = new SelectList(db.Perfis, "PerfilID", "Descricao", usuarios.PerfilID);
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.DadoFinanceiroID = new SelectList(db.DadoFinanceiros, "DadoFinanceiroID", "DadoFinanceiroID", usuarios.DadoFinanceiroID);
            ViewBag.PerfilID = new SelectList(db.Perfis, "PerfilID", "Descricao", usuarios.PerfilID);
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioID,Nome,CPF,RG,Endereco,Login,Senha,DataCadastro,DataUltimoAcesso,PerfilID,DadoFinanceiroID")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DadoFinanceiroID = new SelectList(db.DadoFinanceiros, "DadoFinanceiroID", "DadoFinanceiroID", usuarios.DadoFinanceiroID);
            ViewBag.PerfilID = new SelectList(db.Perfis, "PerfilID", "Descricao", usuarios.PerfilID);
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarios);
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
