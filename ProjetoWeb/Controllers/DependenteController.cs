using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Empresa.Dominio;
using Empresa.Infra.Data;
using Empresa.Aplicacai;

namespace ProjetoWeb.Controllers
{
    public class DependenteController : Controller
    {
        private IDependenteService service = new DependenteService(new DependenteRepository());
        private IFuncionarioService funcionarioService = new FuncionarioService(new FuncionarioRepository());

        // GET: /Dependente/
        public ActionResult Index()
        {
            return View(service.RetrieveAll());
        }

        // GET: /Dependente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int i = (int)id;
            Dependente dependente = service.Retrieve(i);

            if (dependente == null)
            {
                return HttpNotFound();
            }
            return View(dependente);
        }

        // GET: /Dependente/Create
        public ActionResult Create()
        {
            ViewData["FuncionarioId"] = GetFuncionarios();

            return View();
        }

        private SelectList GetFuncionarios()
        {
            var xpto = funcionarioService.RetrieveAll();
            return new SelectList(xpto, "Id", "Nome");
        }

        // POST: /Dependente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,DataNascimento,Cpf, FuncionarioId")] Dependente dependente)
        {
            if (ModelState.IsValid)
            {
                service.Create(dependente);
                return RedirectToAction("Index");
            }

            return View(dependente);
        }

        // GET: /Dependente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int i = (int)id;

            Dependente dependente = service.Retrieve(i);
            if (dependente == null)
            {
                return HttpNotFound();
            }

            ViewData["FuncionarioId"] = GetFuncionarios();
            return View(dependente);
        }

        // POST: /Dependente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,DataNascimento,Cpf, FuncionarioId")] Dependente dependente)
        {
            if (ModelState.IsValid)
            {
                service.Update(dependente);
                return RedirectToAction("Index");
            }
            return View(dependente);
        }

        // GET: /Dependente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int i = (int)id;

            Dependente dependente = service.Retrieve(i);
            if (dependente == null)
            {
                return HttpNotFound();
            }
            return View(dependente);
        }

        // POST: /Dependente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
