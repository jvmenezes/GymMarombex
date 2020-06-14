using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GymMarombex.DAL;
using GymMarombex.Models;

namespace GymMarombex.Controllers {
  public class AlunosController : BaseController {
        private EFContext db = new EFContext();

        // GET: Alunos
        public ActionResult Index()
        {
            var alunos = db.Alunos.Include(a => a.FormasPagmtos).Include(a => a.Planos);
            return View(alunos.ToList());
        }

        // GET: Alunos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunos alunos = db.Alunos.Find(id);
            if (alunos == null)
            {
                return HttpNotFound();
            }
            return View(alunos);
        }

        // GET: Alunos/Create
        public ActionResult Create()
        {
            ViewBag.FormaPagmtoID = new SelectList(db.FormasPagmtos, "FormaPagmtoID", "Descricao");
            ViewBag.PlanoID = new SelectList(db.Planos, "PlanoID", "Descricao");
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlunoID,Nome,CPF,RG,Endereco,Login,Senha,DataCadastro,DataUltimoAcesso,MelhorDiaMesPagmto,DataUltimoPagmto,DataProximoPagmto,ValorTotalPago,QtdParcelas,ValorParcela,NumeroParcelaAtual,FeriasDescricaoMotivo,FeriasDataInicio,FeriasDataFim,Ativo,PlanoID,FormaPagmtoID")] Alunos alunos)
        {
            if (ModelState.IsValid)
            {
                db.Alunos.Add(alunos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormaPagmtoID = new SelectList(db.FormasPagmtos, "FormaPagmtoID", "Descricao", alunos.FormaPagmtoID);
            ViewBag.PlanoID = new SelectList(db.Planos, "PlanoID", "Descricao", alunos.PlanoID);
            return View(alunos);
        }

        // GET: Alunos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunos alunos = db.Alunos.Find(id);
            if (alunos == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormaPagmtoID = new SelectList(db.FormasPagmtos, "FormaPagmtoID", "Descricao", alunos.FormaPagmtoID);
            ViewBag.PlanoID = new SelectList(db.Planos, "PlanoID", "Descricao", alunos.PlanoID);
            return View(alunos);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlunoID,Nome,CPF,RG,Endereco,Login,Senha,DataCadastro,DataUltimoAcesso,MelhorDiaMesPagmto,DataUltimoPagmto,DataProximoPagmto,ValorTotalPago,QtdParcelas,ValorParcela,NumeroParcelaAtual,FeriasDescricaoMotivo,FeriasDataInicio,FeriasDataFim,Ativo,PlanoID,FormaPagmtoID")] Alunos alunos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alunos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormaPagmtoID = new SelectList(db.FormasPagmtos, "FormaPagmtoID", "Descricao", alunos.FormaPagmtoID);
            ViewBag.PlanoID = new SelectList(db.Planos, "PlanoID", "Descricao", alunos.PlanoID);
            return View(alunos);
        }

        // GET: Alunos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunos alunos = db.Alunos.Find(id);
            if (alunos == null)
            {
                return HttpNotFound();
            }
            return View(alunos);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alunos alunos = db.Alunos.Find(id);
            db.Alunos.Remove(alunos);
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
