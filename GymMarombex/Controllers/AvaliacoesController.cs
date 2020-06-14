using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GymMarombex.DAL;
using GymMarombex.Models;

namespace GymMarombex.Controllers {
  public class AvaliacoesController : BaseController
    {
        private EFContext db = new EFContext();

        // GET: Avaliacoes
        public ActionResult Index()
        {
            var avaliacoes = db.Avaliacoes.Include(a => a.Alunos).Include(a => a.Funcionarios);
            return View(avaliacoes.ToList());
        }

        // GET: Avaliacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacoes avaliacoes = db.Avaliacoes.Find(id);
            if (avaliacoes == null)
            {
                return HttpNotFound();
            }
            return View(avaliacoes);
        }

        // GET: Avaliacoes/Create
        public ActionResult Create()
        {
            ViewBag.AlunoID = new SelectList(db.Alunos, "AlunoID", "Nome");
            ViewBag.FisioterapeutaID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome");
            return View();
        }

        // POST: Avaliacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AvaliacaoID,InfoAnamnese,ExameDobrasCutaneas,ExameErgometrico,DataRealizacao,AlunoID,FisioterapeutaID")] Avaliacoes avaliacoes)
        {
            if (ModelState.IsValid)
            {
                db.Avaliacoes.Add(avaliacoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlunoID = new SelectList(db.Alunos, "AlunoID", "Nome", avaliacoes.AlunoID);
            ViewBag.FisioterapeutaID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", avaliacoes.FisioterapeutaID);
            return View(avaliacoes);
        }

        // GET: Avaliacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacoes avaliacoes = db.Avaliacoes.Find(id);
            if (avaliacoes == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlunoID = new SelectList(db.Alunos, "AlunoID", "Nome", avaliacoes.AlunoID);
            ViewBag.FisioterapeutaID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", avaliacoes.FisioterapeutaID);
            return View(avaliacoes);
        }

        // POST: Avaliacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AvaliacaoID,InfoAnamnese,ExameDobrasCutaneas,ExameErgometrico,DataRealizacao,AlunoID,FisioterapeutaID")] Avaliacoes avaliacoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avaliacoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlunoID = new SelectList(db.Alunos, "AlunoID", "Nome", avaliacoes.AlunoID);
            ViewBag.FisioterapeutaID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", avaliacoes.FisioterapeutaID);
            return View(avaliacoes);
        }

        // GET: Avaliacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacoes avaliacoes = db.Avaliacoes.Find(id);
            if (avaliacoes == null)
            {
                return HttpNotFound();
            }
            return View(avaliacoes);
        }

        // POST: Avaliacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Avaliacoes avaliacoes = db.Avaliacoes.Find(id);
            db.Avaliacoes.Remove(avaliacoes);
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
