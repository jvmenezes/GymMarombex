using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GymMarombex.DAL;
using GymMarombex.Models;

namespace GymMarombex.Controllers {
  public class PerfisController : BaseController
    {
        private EFContext db = new EFContext();

        // GET: Perfis
        public ActionResult Index()
        {
            return View(db.Perfis.ToList());
        }

        // GET: Perfis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfis perfis = db.Perfis.Find(id);
            if (perfis == null)
            {
                return HttpNotFound();
            }
            return View(perfis);
        }

        // GET: Perfis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perfis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PerfilID,Descricao")] Perfis perfis)
        {
            if (ModelState.IsValid)
            {
                db.Perfis.Add(perfis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perfis);
        }

        // GET: Perfis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfis perfis = db.Perfis.Find(id);
            if (perfis == null)
            {
                return HttpNotFound();
            }
            return View(perfis);
        }

        // POST: Perfis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PerfilID,Descricao")] Perfis perfis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perfis);
        }

        // GET: Perfis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfis perfis = db.Perfis.Find(id);
            if (perfis == null)
            {
                return HttpNotFound();
            }
            return View(perfis);
        }

        // POST: Perfis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perfis perfis = db.Perfis.Find(id);
            db.Perfis.Remove(perfis);
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
