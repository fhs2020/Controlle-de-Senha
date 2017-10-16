using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Controlle_de_Senha.Models;

namespace Controlle_de_Senha.Controllers
{
    public class HistoricoSenhasController : Controller
    {
        private Controlle_de_SenhaContext db = new Controlle_de_SenhaContext();

        // GET: HistoricoSenhas
        public ActionResult Index()
        {
            return View(db.HistoricoSenhas.ToList());
        }

        // GET: HistoricoSenhas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricoSenha historicoSenha = db.HistoricoSenhas.Find(id);
            if (historicoSenha == null)
            {
                return HttpNotFound();
            }
            return View(historicoSenha);
        }

        // GET: HistoricoSenhas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistoricoSenhas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Senha,Guiche,DateTime")] HistoricoSenha historicoSenha)
        {
            if (ModelState.IsValid)
            {
                db.HistoricoSenhas.Add(historicoSenha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(historicoSenha);
        }

        // GET: HistoricoSenhas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricoSenha historicoSenha = db.HistoricoSenhas.Find(id);
            if (historicoSenha == null)
            {
                return HttpNotFound();
            }
            return View(historicoSenha);
        }

        // POST: HistoricoSenhas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Senha,Guiche,DateTime")] HistoricoSenha historicoSenha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historicoSenha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(historicoSenha);
        }

        // GET: HistoricoSenhas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricoSenha historicoSenha = db.HistoricoSenhas.Find(id);
            if (historicoSenha == null)
            {
                return HttpNotFound();
            }
            return View(historicoSenha);
        }

        // POST: HistoricoSenhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistoricoSenha historicoSenha = db.HistoricoSenhas.Find(id);
            db.HistoricoSenhas.Remove(historicoSenha);
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
