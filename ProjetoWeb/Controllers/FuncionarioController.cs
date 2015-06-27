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
    public class FuncionarioController : Controller
    {
         
        private IFuncionarioService service = new FuncionarioService(new FuncionarioRepository());

        // GET: /Blog/
        public ActionResult Index()
        {
            return View(service.RetrieveAll());
        }

        // GET: /Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Funcionario funcionario = service.Retrieve(id.Value);
         
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: /Funcionario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Funcionario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,DataAdmissao,DataNascimento,Cpf,Funcao")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                service.Create(funcionario);
                return RedirectToAction("Index");
            }

            return View(funcionario);
        }

        // GET: /Funcionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int i = (int)id;

            Funcionario funcionario = service.Retrieve(i);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: /Funcionario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,DataAdmissao,DataNascimento,Cpf,Funcao")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                service.Update(funcionario);
                return RedirectToAction("Index");
            }
          
            return View(funcionario);
        }

        // GET: /Funcionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int i = (int)id;

            Funcionario funcionario = service.Retrieve(i);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: /Funcionario/Delete/5
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
