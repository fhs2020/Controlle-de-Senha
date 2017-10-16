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
    public class SenhaController : Controller
    {
        private Controlle_de_SenhaContext db = new Controlle_de_SenhaContext();

        // GET: Senha
        public ActionResult Index()
        {
            return View(db.Password.ToList());
        }

        // GET: Senha/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Password senha = db.Password.Find(id);
            if (senha == null)
            {
                return HttpNotFound();
            }

            var historico = db.HistoricoSenhas.ToList();

            var listasSenhasAtual = db.Password.ToList();

            var ultimaSenhaNormal = listasSenhasAtual.LastOrDefault();

            var ultimaSenhaPreferencial = listasSenhasAtual.LastOrDefault();

            List<HistoricoSenha> listaSenhas = historico.OrderByDescending(x => x.Id).Take(3).ToList();

            //listaSenhas.Add(listasSenhasAtual);

            ViewBag.UltimaPreferenical = "N" + (ultimaSenhaPreferencial.NumSenhaPreferencial).ToString();
            ViewBag.UltimaSenhaNormal = "P" + (ultimaSenhaNormal.NumeroSenha);

            ViewBag.ListaSenhas = listaSenhas;

            ViewBag.Horario = DateTime.Now.ToString("HH:mm");

            return View(senha);
        }

        // GET: Senha/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Senha/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroSenha")] Password senha)
        {
            if (ModelState.IsValid)
            {
                db.Password.Add(senha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(senha);
        }

        public ActionResult ChamarCliente()
        {
            ViewBag.ListOfTipos = new SelectList(new[]
            {
                new { Id = "Normal", Name = "Senha Normal" },
                new { Id = "Preferencial", Name = "Senha Preferencial" },
            }, "Id", "Name");

            ViewBag.Message = null;

            return View();
        }


        [HttpPost]
        public ActionResult ChamarCliente(Password senha)
        {

            if (senha.Tipo != null)
            {
                if (senha.Tipo == "Normal")
                {
                    var senhaAtual = db.Password.ToList().LastOrDefault();

                    var imprimirSenha = senhaAtual.NumeroSenha;

                    var historico = new HistoricoSenha();

                    historico.DateTime = DateTime.Now;
                    historico.Guiche = 3;
                    historico.Senha = "N"  + String.Concat(imprimirSenha);

                    senhaAtual.NumeroSenha += 1;

                    db.HistoricoSenhas.Add(historico);
                    db.Entry(senhaAtual).State = EntityState.Modified;
                    db.SaveChanges();

                }
                else
                {
                    var senhaAtual = db.Password.ToList().LastOrDefault();

                    var imprimirSenhaPreferencial = senhaAtual.NumSenhaPreferencial;


                    var historico = new HistoricoSenha();

                    historico.DateTime = DateTime.Now;
                    historico.Guiche = 4;
                    historico.Senha = "P" + String.Concat(imprimirSenhaPreferencial);


                    senhaAtual.NumSenhaPreferencial += 1;



                    db.HistoricoSenhas.Add(historico);

                    db.Entry(senhaAtual).State = EntityState.Modified;
                    db.SaveChanges();

                }
            }
            else
            {
                throw new ApplicationException("Por favor selecione um tipo");
            }

            ViewBag.ListOfTipos = new SelectList(new[]
            {
                new { Id = "Normal", Name = "Senha Normal" },
                new { Id = "Preferencial", Name = "Senha Preferencial" },
            }, "Id", "Name");

            ViewBag.Message = "Senha impressa com sucesso!";

            return View();

        }


        // GET: Senha/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Password senha = db.Password.Find(id);
            if (senha == null)
            {
                return HttpNotFound();
            }

            return View(senha);
        }

        // POST: Senha/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroSenha,NumSenhaPreferencial,Guiche")] Password senha)
        {
            if (ModelState.IsValid)
            {
                senha.DataHora = DateTime.Now;

                db.Entry(senha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(senha);
        }


        // GET: Senha/Edit/5
        public ActionResult ChamarSenha(int? id)
        {
            ViewBag.SenhaChamada = false;

            return View();
        }

        // POST: Senha/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChamarSenha(bool SenhaNormal)
        {
            var senhaLista = db.Password.ToList();

            var senha = senhaLista.LastOrDefault();

            ViewBag.SenhaChamada = true;

            if (SenhaNormal == true)
            {
                senha.DataHora = DateTime.Now;
                senha.Preferencial = false;

                var historico = new HistoricoSenha();

                historico.DateTime = DateTime.Now;
                historico.Guiche = 3;
                historico.Senha = "N" + String.Concat(senha.NumeroSenha);

                senha.NumeroSenha += 1;

                ViewBag.NumeroSenha = "N" + (senha.NumeroSenha).ToString();

                db.HistoricoSenhas.Add(historico);
                db.Entry(senha).State = EntityState.Modified;
                db.SaveChanges();

                return View(senha);
            }
            else
            {
                senha.DataHora = DateTime.Now;
                senha.Preferencial = true;

                var historico = new HistoricoSenha();

                historico.DateTime = DateTime.Now;
                historico.Guiche = 5;
                historico.Senha = "P" + String.Concat(senha.NumSenhaPreferencial);

                ViewBag.NumeroSenha = "P" + (senha.NumSenhaPreferencial).ToString();

                senha.NumSenhaPreferencial += 1;

                db.HistoricoSenhas.Add(historico);
                db.Entry(senha).State = EntityState.Modified;
                db.SaveChanges();

                return View(senha);
            }
        }

        // GET: Senha/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Password senha = db.Password.Find(id);
            if (senha == null)
            {
                return HttpNotFound();
            }
            return View(senha);
        }

        // POST: Senha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Password senha = db.Password.Find(id);
            db.Password.Remove(senha);
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
