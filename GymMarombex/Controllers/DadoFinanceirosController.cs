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
    public class DadoFinanceirosController : Controller
    {
        private EFContext db = new EFContext();

        // GET: DadoFinanceiros
        public ActionResult Index()
        {
            var dadoFinanceiros = db.DadoFinanceiros.Include(d => d.AvisoFerias).Include(d => d.FormasPagmtos).Include(d => d.Planos);
            return View(dadoFinanceiros.ToList());
        }

        // GET: DadoFinanceiros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DadoFinanceiros dadoFinanceiros = db.DadoFinanceiros.Find(id);
            if (dadoFinanceiros == null)
            {
                return HttpNotFound();
            }
            return View(dadoFinanceiros);
        }

        // GET: DadoFinanceiros/Create
        public ActionResult Create()
        {
            ViewBag.AvisoFeriasID = new SelectList(db.AvisoFerias, "AvisoFeriasID", "DescricaoMotivo");
            ViewBag.FormaPagmtoID = new SelectList(db.FormasPagmtos, "FormaPagmtoID", "Descricao");
            ViewBag.PlanoID = new SelectList(db.Planos, "PlanoID", "Descricao");
            return View();
        }

        // POST: DadoFinanceiros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DadoFinanceiroID,ValorTotal,NumeroParcelaAtual,MelhorDiaMesPagmto,DataPrimeiroPagmto,DataUltimoPagmto,DataRealizacao,ValorJaPago,ValorParcela,QtdParcelas,PlanoID,FormaPagmtoID,AvisoFeriasID")] DadoFinanceiros dadoFinanceiros)
        {
            if (ModelState.IsValid)
            {
                db.DadoFinanceiros.Add(dadoFinanceiros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AvisoFeriasID = new SelectList(db.AvisoFerias, "AvisoFeriasID", "DescricaoMotivo", dadoFinanceiros.AvisoFeriasID);
            ViewBag.FormaPagmtoID = new SelectList(db.FormasPagmtos, "FormaPagmtoID", "Descricao", dadoFinanceiros.FormaPagmtoID);
            ViewBag.PlanoID = new SelectList(db.Planos, "PlanoID", "Descricao", dadoFinanceiros.PlanoID);
            return View(dadoFinanceiros);
        }

        // GET: DadoFinanceiros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DadoFinanceiros dadoFinanceiros = db.DadoFinanceiros.Find(id);
            if (dadoFinanceiros == null)
            {
                return HttpNotFound();
            }
            ViewBag.AvisoFeriasID = new SelectList(db.AvisoFerias, "AvisoFeriasID", "DescricaoMotivo", dadoFinanceiros.AvisoFeriasID);
            ViewBag.FormaPagmtoID = new SelectList(db.FormasPagmtos, "FormaPagmtoID", "Descricao", dadoFinanceiros.FormaPagmtoID);
            ViewBag.PlanoID = new SelectList(db.Planos, "PlanoID", "Descricao", dadoFinanceiros.PlanoID);
            return View(dadoFinanceiros);
        }

        // POST: DadoFinanceiros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DadoFinanceiroID,ValorTotal,NumeroParcelaAtual,MelhorDiaMesPagmto,DataPrimeiroPagmto,DataUltimoPagmto,DataRealizacao,ValorJaPago,ValorParcela,QtdParcelas,PlanoID,FormaPagmtoID,AvisoFeriasID")] DadoFinanceiros dadoFinanceiros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dadoFinanceiros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AvisoFeriasID = new SelectList(db.AvisoFerias, "AvisoFeriasID", "DescricaoMotivo", dadoFinanceiros.AvisoFeriasID);
            ViewBag.FormaPagmtoID = new SelectList(db.FormasPagmtos, "FormaPagmtoID", "Descricao", dadoFinanceiros.FormaPagmtoID);
            ViewBag.PlanoID = new SelectList(db.Planos, "PlanoID", "Descricao", dadoFinanceiros.PlanoID);
            return View(dadoFinanceiros);
        }

        // GET: DadoFinanceiros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DadoFinanceiros dadoFinanceiros = db.DadoFinanceiros.Find(id);
            if (dadoFinanceiros == null)
            {
                return HttpNotFound();
            }
            return View(dadoFinanceiros);
        }

        // POST: DadoFinanceiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DadoFinanceiros dadoFinanceiros = db.DadoFinanceiros.Find(id);
            db.DadoFinanceiros.Remove(dadoFinanceiros);
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
